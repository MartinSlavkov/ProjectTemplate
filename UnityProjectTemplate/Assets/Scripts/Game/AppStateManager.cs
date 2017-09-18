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
        StateMachineSimple appState;

        public class OnMainManuPlayPressedEvent : IEvent { }

        public AppStateManager(CoreManager core)
        {
            this.core = core;

            core.EventAgreggator.Register<UnityEngineView.OnStartEvent>(OnStartHandler);
            core.EventAgreggator.Register<OnMainManuPlayPressedEvent>(OnMainManuPlayPressedHandler);

            appState = new StateMachineSimple();
            appState.MapState(StateWaitingForInit);
            appState.MapState(StateLoadScenes);
            appState.MapState(StateMainMenu);
            appState.MapState(StateLoadInGame);
            appState.MapState(StateInGame);
        }

        public void Tick()
        {
            appState.Update(Time.deltaTime);
        }

        #region States

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
            //zavesit na onload a prepnut do mainmenu
        }

        private void StateInGame()
        {
        }

        private void StateLoadInGame()
        {
            SceneManager.UnloadSceneAsync("MenuScene");
            SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
            appState.SwitchToState(StateInGame);

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
            appState.SwitchToState(StateLoadScenes);
        }

        public void OnMainManuPlayPressedHandler(OnMainManuPlayPressedEvent evt)
        {
            appState.SwitchToState(StateLoadInGame);
        }

        #endregion
    }
}
