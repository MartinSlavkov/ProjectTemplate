using UnityEngine;
using Zenject;

namespace Core
{
    public class CoreInstaller : MonoInstaller<CoreInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EventAggregator>().AsSingle().NonLazy();
            Container.Bind<CoreManager>().AsSingle().NonLazy();
        }
    }
}