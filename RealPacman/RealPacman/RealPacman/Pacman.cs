using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RealPacman
{
    class Pacman : Sprite
    {
        public Pacman(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity) :

            base(location, texture, initialFrame, velocity)
        {

        }
        
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(Keys.Right))
            {
                Velocity = new Vector2(32, 0);
                
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
