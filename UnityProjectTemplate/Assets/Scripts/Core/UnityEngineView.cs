using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UnityEngineView : MonoBehaviour
{
    CoreManager coreManager;

    #region events

    public class OnStartEvent : IEvent { };


    #endregion

    [Inject]
    public void Init(CoreManager core)
    {
        coreManager = core;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Unity Started");
        coreManager.EventAgreggator.Trigger(typeof(OnStartEvent));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
