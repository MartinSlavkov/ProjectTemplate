using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class AppStateManager
    {
        CoreManager core;

        public class OnLevelLoadedEvent : IEvent { };

        public AppStateManager(CoreManager core)
        {
            this.core = core;

            core.EventAgreggator.Register<OnLevelLoadedEvent>(OnLoadedHandler);
        }

        #region Event Handlers
        public void OnLoadedHandler(OnLevelLoadedEvent evt)
        {
        }
        #endregion
    }
}
