using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace Game
{
    class PlayerInputHandler : ITickable
    {
        readonly PlayerInputState inputState;
        private Camera mainCamera;

        public PlayerInputHandler(PlayerInputState inputState, Camera mainCamera)
        {
            this.inputState = inputState;
            this.mainCamera = mainCamera;
        }

        public void Tick()
        {
            Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 mousePosWorld = mouseRay.origin;
            mousePosWorld.z = 0;

            inputState.TargetPosition = mousePosWorld;
            inputState.IsFiring = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
        }
    }
}
