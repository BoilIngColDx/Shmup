using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Shmup
{
    class MissileSprite : Sprite
    {
        float currentSpeed = 10f;
        float maxSpeed = 1000f;
        float acceleration = 200f;
        public bool dead = false;

        public MissileSprite(Texture2D newTxr, Vector2 newPos, float newMaxSpeed = 1000f) : base(newTxr, newPos)
        {
            maxSpeed = newMaxSpeed;
        }

        public override void Update(GameTime gameTime, Point screenSize)
        {
            currentSpeed += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentSpeed = Math.Min(currentSpeed, maxSpeed);

            spritePos.X -= currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(spritePos.X < -spriteTexture.Width) dead = true;
        }
    }
}