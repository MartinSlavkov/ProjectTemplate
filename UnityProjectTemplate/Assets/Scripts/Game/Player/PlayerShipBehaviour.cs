using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerShipBehaviour : MonoBehaviour, IDamagable
    {
        public PlayerShipModel playerShip;

        public PlayerShipBehaviour(PlayerShipModel playerShip)
        {
            this.playerShip = playerShip;
        }

        public void DoDamage(float damage, GameObject damageSource)
        {
            //if(damageSource.teamId && ??damage type??
            playerShip.DoDamage(damage);
        }
    }
}