using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Core.Utils;
using UnityEngine.SceneManagement;
using Zenject;
using System;

namespace Game
{
    public class AppStateManager : ITickable
    {
        CoreManager core;
        StateMachine topLevelState;

        public AppStateManager(CoreManager core)
        {
            this.core = core;

            core.EventAgreggator.Register<UnityEngineView.OnStartEvent>(OnStartHandler);

            topLevelState = new StateMachine();
            topLevelState.MapState(StateWaitingForInit);
            topLevelState.MapState(StateLoadScenes);
            topLevelState.MapState(StateMainMenu);
            topLevelState.MapState(StateInGame);
        }

        public void Tick()
        {
            topLevelState.Update(Time.deltaTime);
        }

        #region states
        private void StateWaitingForInit()
        {
        }

        private void StateLoadScenes()
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
        }

        private void StateInGame()
        {
        }

        private void StateMainMenu()
        {
        }
        #endregion

        public void UnregisterEvents()
        {
            core.EventAgreggator.Unregister<UnityEngineView.OnStartEvent>(OnStartHandler);
        }

        #region Event Handlers
        public void OnStartHandler(UnityEngineView.OnStartEvent evt)
        {
            topLevelState.SwitchToState(StateLoadScenes);
        }
        #endregion
    }
}
