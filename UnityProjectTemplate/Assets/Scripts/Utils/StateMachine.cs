using System.Collections.Generic;
using UnityEngine;

namespace Core.Utils
{
    public class StateMachine
    {
        public delegate void StateChanged(int stateId);
        public event StateChanged OnStateChanged;

        public delegate void StateEnter();
        public delegate void StateUpdate(float deltaTime);
        public delegate void StateExit();

        private struct State
        {
            public int id;
            public StateEnter stateEnter;
            public StateUpdate stateUpdate;
            public StateExit stateExit;
        }

        private int currentStateId;
        private State currentState;

        private Dictionary<StateEnter, int> stateToId;
        private Dictionary<int, State> idToState;

        private int nextStateId;

        public StateMachine()
        {
            idToState = new Dictionary<int, State>();
            stateToId = new Dictionary<StateEnter, int>();
        }

        /// <summary>
        /// Update must be called from somewhere (mono beh. update for example)
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            if (currentState.stateUpdate != null)
            {
                // call state update
                currentState.stateUpdate.Invoke(deltaTime);
            }
        }

        /// <summary>
        /// Use GetCurrentState() like that:
        /// stateMachine.MapState(FireEnter, FireUpdate, FireExit);
        /// if(stateMachine.GetCurrentState() == FireEnter) 
        /// </summary>
        /// <returns>StateEnter of current state</returns>
        public StateEnter GetCurrentState()
        {
            return idToState[currentStateId].stateEnter;
        }

        public StateEnter GetStateById(int id)
        {
            if (idToState.ContainsKey(id) == false)
            {
                Debug.LogError("[StateMachine] Error: This state is not mapped, you must map all ability states in Init(), state id:" + id);
            }

            return idToState[id].stateEnter;
        }

        public int GetStateId(StateEnter stateEnter)
        {
            if (stateToId.ContainsKey(stateEnter) == false)
            {
                Debug.LogError("[StateMachine] Error: This state is not mapped, you must map all ability states in Init(), state:" + stateEnter);
            }

            return stateToId[stateEnter];
        }

        /// <summary>
        /// Swithes state machine to the state
        /// </summary>
        /// <param name="stateEnter"></param>
        public void SwitchToState(StateEnter stateEnter)
        {
            if (stateToId.ContainsKey(stateEnter) == false)
            {
                Debug.LogError("[StateMachine] Error: This state is not mapped, you must map all ability states in Init()");
            }

            // leave old state if exists
            if (currentState.stateExit != null)
            {
                // call state exit
                currentState.stateExit();
            }

            // internal switch state
            currentStateId = stateToId[stateEnter];
            currentState = idToState[currentStateId];

            // send event
            if (OnStateChanged != null)
            {
                OnStateChanged.Invoke(currentStateId);
            }

            // call state enter
            currentState.stateEnter();

            //Debug.LogWarning("[State Machine] Enter state: " + currentStateId + ", " + currentState);
        }

        public void MapState(StateEnter stateEnter)
        {
            MapState(stateEnter, null, null);
        }

        public void MapState(StateEnter stateEnter, StateUpdate stateUpdate)
        {
            MapState(stateEnter, stateUpdate, null);
        }

        public void MapState(StateEnter stateEnter, StateUpdate stateUpdate, StateExit stateExit)
        {
            State state = new State();
            state.id = nextStateId;
            state.stateEnter = stateEnter;
            state.stateUpdate = stateUpdate;
            state.stateExit = stateExit;

            idToState.Add(state.id, state);
            stateToId.Add(stateEnter, state.id);

            nextStateId += 1;
        }
    }
}