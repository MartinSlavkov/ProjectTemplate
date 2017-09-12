using System;
using UnityEngine;
using Zenject;

namespace Core
{
    [CreateAssetMenu(fileName = "CoreSettingInstaller", menuName = "Installers/CoreSettingInstaller")]
    public class CoreSettingInstaller : ScriptableObjectInstaller<CoreSettingInstaller>
    {
        public GameObject UnityEngineViewPrefab;

        public override void InstallBindings()
        {
            Container.Bind<UnityEngineView>().FromComponentInNewPrefab(UnityEngineViewPrefab).AsSingle().NonLazy();
        }
    }
}