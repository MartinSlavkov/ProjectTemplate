using UnityEngine;
using Zenject;

namespace Game
{

    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameStateManager.Settings GameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(GameSettings);
        }
    }
}