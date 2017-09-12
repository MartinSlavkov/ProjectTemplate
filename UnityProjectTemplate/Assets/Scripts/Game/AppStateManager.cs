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
            //test what is the current scene
            if (!SceneManager.GetSceneByName("MenuScene").IsValid())
            {
                SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
            }
            Debug.Log("Switched to Menu Scene");
        }

        private void StateInGame()
        {
            SceneManager.UnloadSceneAsync("MenuScene");
            SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
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
            topLevelState.SwitchToState(StateInGame);

        }
        #endregion
    }
}
