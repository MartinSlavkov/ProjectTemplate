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

        }


        [Serializable]
        public class Settings
        {

        }
    }
}
