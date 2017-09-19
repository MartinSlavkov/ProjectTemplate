using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pixel.Pool
{
    [System.Serializable]
    public class ObjectPool
    {
        private ObjectPoolManager _manager;
        private int _initialSize;
        private Stack<GameObject> _freeStack;
        private List<GameObject> _usedPool;
        private GameObject objectPrototype;

        public int maxSize;
        public bool expandable = true;
        public bool dontDestroyOnLoad = false;

        public int GetUsedCount()
        {
            return _usedPool.Count;
        }

        public int GetFreeCount()
        {
            return _freeStack.Count;
        }

        public ObjectPool(ObjectPoolManager p_manager, int p_initialSize, GameObject p_objectPrototype, bool p_dontDestroyOnLoad)
        {
            if (p_objectPrototype == null) throw new System.Exception("Cannot use null as pool prototype.");

            _manager = p_manager;
            _initialSize = p_initialSize;
            objectPrototype = p_objectPrototype;
            dontDestroyOnLoad = p_dontDestroyOnLoad;

            _freeStack = new Stack<GameObject>();
            _usedPool = new List<GameObject>();

            for (int i = 0; i < _initialSize; ++i)
            {
                CreateInstance();
            }
        }

        private void CreateInstance()
        {
            GameObject instance = Object.Instantiate(objectPrototype);
            if (dontDestroyOnLoad) GameObject.DontDestroyOnLoad(instance);
            instance.SetActive(false);
            _freeStack.Push(instance);
        }

        public GameObject GetInstance()
        {
            GameObject instance = null;
            if (_freeStack.Count == 0 && expandable && (_usedPool.Count < maxSize || maxSize == 0))
            {
                CreateInstance();
            }

            if (_freeStack.Count > 0)
            {
                instance = _freeStack.Pop();
                _usedPool.Add(instance);
            }

            return instance;
        }

        public GameObject GetTimedInstance(bool p_activate, float p_reuseInTime)
        {
            GameObject instance = GetInstance();
            if (instance != null)
            {
                if (p_activate) instance.SetActive(true);
                _manager.StartCoroutine(Reuse(instance, p_reuseInTime));
            }
            return instance;
        }

        IEnumerator Reuse(GameObject p_instance, float p_time)
        {
            yield return new WaitForSeconds(p_time);
            ReturnInstance(p_instance);
        }

        public T GetInstance<T>() where T : Component
        {
            GameObject go = GetInstance();
            return (go != null) ? go.GetComponent<T>() : null;
        }

        public void ReturnInstance(GameObject p_instance)
        {
            p_instance.SetActive(false);
            p_instance.transform.SetParent(null);
            _usedPool.Remove(p_instance);
            _freeStack.Push(p_instance);
        }

        public bool HasUsedInstance(GameObject p_instance)
        {
            return _usedPool.Contains(p_instance);
        }

        public void ReturnInstance<T>(T p_instance) where T : Component
        {
            ReturnInstance(p_instance.gameObject);
        }

        public void Dispose()
        {
            while (_freeStack.Count > 0) Object.Destroy(_freeStack.Pop());
            while (_usedPool.Count > 0)
            {
                GameObject instance = _usedPool[0];
                GameObject.Destroy(instance);
                _usedPool.Remove(instance);
            }
        }
    }
}