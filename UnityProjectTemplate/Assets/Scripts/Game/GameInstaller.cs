using Game;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<AppStateManager>().AsSingle().NonLazy();
        Container.Bind<ITickable>().To<AppStateManager>().AsSingle();
    }
}