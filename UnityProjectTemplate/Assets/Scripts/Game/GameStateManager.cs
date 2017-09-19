using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class GameStateManager
    {
        private StateMachineSimple gameState;
        private UserData userData;
        private DefinitionsData definitions;
        private Settings settings;

        public GameStateManager(UserData userData, DefinitionsData definitions, Settings settings)
        {
            this.userData = userData;
            this.definitions = definitions;
            this.settings = settings;

            gameState = new StateMachineSimple();
            gameState.MapState(StateInitialize);

            gameState.SwitchToState(StateInitialize);
        }

        private void StateInitialize()
        {
            //GameObject.Instantiate(settings.PlayerPrefab, Vector3.zero, Quaternion.identity);
            


            // need - player prefab / player ship prefab - with view?
            //       - prefab from settings scriptable thing
            // need - ship hull prefab
            //       - from definitions
            //  - create ship for player
            //      - use player ship prefab - visual / data - factory / builder?
            //      - add hull prefab
            //      - add weapon prefab
        }


        [Serializable]
        public class Settings
        {
            //public GameObject PlayerPrefab;
        }
    }
}
