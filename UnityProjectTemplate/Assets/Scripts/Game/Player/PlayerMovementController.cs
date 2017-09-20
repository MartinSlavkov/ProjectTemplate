using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerMovementController : ITickable
    {
        private PlayerInputState inputState;
        private PlayerShipModel playerShip;

        public PlayerMovementController(PlayerInputState inputState, PlayerShipModel playerShip)
        {
            this.inputState = inputState;
            this.playerShip = playerShip;
        }

        public void Tick()
        {
            Vector2 diff = inputState.TargetPosition - playerShip.Position;
            playerShip.SetVelocity(diff * 10.0f);
        }
    }
}
