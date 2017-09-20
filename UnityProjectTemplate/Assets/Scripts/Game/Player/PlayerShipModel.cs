using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class PlayerShipModel
    {
        public float Health;

        private PlayerInputState inputState;
        private Rigidbody2D rigidBody;
        private DefinitionsData definitions;

        public PlayerShipModel(
            DefinitionsData definitions,
            Rigidbody2D rigidBody,
            PlayerInputState inputState)
        {
            this.rigidBody = rigidBody;
            this.definitions = definitions;
            this.inputState = inputState;
        }

        public float Rotation
        {
            get { return rigidBody.rotation; }
            set { rigidBody.rotation = value; }
        }

        public Vector2 Position
        {
            get { return rigidBody.position; }
            set { rigidBody.position = value; }
        }

        public void AddForce(Vector2 force)
        {
            rigidBody.AddForce(force);
        }

        public void SetVelocity(Vector2 velocity)
        {
            rigidBody.velocity = velocity;
        }

        public void DoDamage(float damage)
        {
            Health -= damage;
        }
    }
}
