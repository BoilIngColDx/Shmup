using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Shmup
{
    class ParticleSprite : Sprite
    {
        Random rando = new Random();
        Vector2 velocity;
        float maxLife;
        public float currentLife;
        Color particleColour;

        public ParticleSprite(Texture2D newTxr, Vector2 newPos) : base(newTxr, newPos)
        {
            maxLife = (float)(rando.NextDouble() / 2 + 0.5);
            currentLife = maxLife;
            
            velocity = new Vector2(
                (float)(rando.NextDouble() * 100 + 50),
                (float)(rando.NextDouble() * 100 + 50)
                );
            if (rando.Next(2) > 0) velocity.X *= -1;
            if (rando.Next(2) > 0) velocity.Y *= -1;

            particleColour = new Color(
                (float)(rando.NextDouble() / 2 + 0.5),
                0.25f,
                (float)(rando.NextDouble() / 2 + 0.5)
                );

        }

        public override void Update(GameTime gameTime, Point screenSize)
        {
            spritePos += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentLife -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                spriteTexture,
                new Rectangle(
                    (int)spritePos.X,
                    (int)spritePos.Y,
                    (int)((float)spriteTexture.Width * (currentLife / maxLife)),
                    (int)((float)spriteTexture.Height * (currentLife / maxLife))
                    ),
                particleColour
                );
        }
    }
}
