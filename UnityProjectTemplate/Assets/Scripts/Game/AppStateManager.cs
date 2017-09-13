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

        public class OnMainManuPlayPressedEvent : IEvent { }

        public AppStateManager(CoreManager core)
        {
            this.core = core;

            core.EventAgreggator.Register<UnityEngineView.OnStartEvent>(OnStartHandler);
            core.EventAgreggator.Register<OnMainManuPlayPressedEvent>(OnMainManuPlayPressedHandler);

            topLevelState = new StateMachine();
            topLevelState.MapState(StateWaitingForInit);
            topLevelState.MapState(StateLoadScenes);
            topLevelState.MapState(StateMainMenu);
            topLevelState.MapState(StateLoadInGame);
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
            if (!SceneManager.GetSceneByName("CoreScene").IsValid())
            {
                SceneManager.LoadScene("CoreScene", LoadSceneMode.Single);
            }

            SceneManager.LoadSceneAsync("MenuScene", LoadSceneMode.Additive);
            Debug.Log("Main menu ready");
        }

        private void StateInGame()
        {
        }

        private void StateLoadInGame()
        {
            SceneManager.UnloadSceneAsync("MenuScene");
            SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
            topLevelState.SwitchToState(StateInGame);
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

        public void OnMainManuPlayPressedHandler(OnMainManuPlayPressedEvent evt)
        {
            topLevelState.SwitchToState(StateLoadInGame);
        }

        #endregion
    }
}
