using System;
using UnityEngine;
using Zenject;

namespace Game
{

    public class PlayerShipInstaller : MonoInstaller<PlayerShipInstaller>
    {
        [SerializeField]
        Settings settings = null;

        public override void InstallBindings()
        {
            Container.Bind<PlayerShipModel>().AsSingle()
                .WithArguments(settings.Rigidbody).NonLazy();

            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMovementController>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public Rigidbody2D Rigidbody;
        }
    }
}