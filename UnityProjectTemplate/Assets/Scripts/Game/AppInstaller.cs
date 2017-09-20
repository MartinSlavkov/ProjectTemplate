using Game;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller<AppInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<AppStateManager>().AsSingle().NonLazy();
        Container.Bind<ITickable>().To<AppStateManager>().AsSingle();
    }
}