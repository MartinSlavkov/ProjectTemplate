using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    //model
    //player, asteroids, rockets
    //asteroids and rockets in pool
    //asteroids generated randomly + by controller?
    class GameStateManager
    {
        private StateMachineSimple gameState;
        private UserData userData;
        private DefinitionsData definitions;

        public GameStateManager(UserData userData, DefinitionsData definitions)
        {
            this.userData = userData;
            this.definitions = definitions;

            gameState.MapState(StateInitialize);
        }

        private void StateInitialize()
        {
            // need - player prefab / player ship prefab - with view?
            //       - prefab from settings scriptable thing
            // need - ship hull prefab
            //       - from definitions
            //  - create ship for player
            //      - use player ship prefab - visual / data - factory / builder?
            //      - add hull prefab
            //      - add weapon prefab
        }

        //game state manager

        /*public Player;
            dopisat naco je cv state masine id
premenovat ju na state machine simple abo tak
vyhodit ability z logu*/
    }
}
