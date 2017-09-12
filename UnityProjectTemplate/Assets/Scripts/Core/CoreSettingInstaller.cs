using System;
using UnityEngine;
using Zenject;

namespace Core
{
    [CreateAssetMenu(fileName = "CoreSettingInstaller", menuName = "Installers/CoreSettingInstaller")]
    public class CoreSettingInstaller : ScriptableObjectInstaller<CoreSettingInstaller>
    {
        public TestSettings Test;

        [Serializable]
        public class TestSettings
        {
            public int TestInt;
        }

        public override void InstallBindings()
        {
        }
    }
}