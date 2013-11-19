using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RealPacman
{
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    class Pacman : Sprite
    {
        int speed = 92;
        Direction direction;
        Vector2 target;

        public Pacman(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity) :

            base(location, texture, initialFrame, velocity)
        {
            direction = Direction.RIGHT;
            target = location + new Vector2(32, 0);
            UpdateDirection();
        }

        public void UpdateDirection()
        {
           

            switch (direction)
            {
                case Direction.RIGHT:
                    Velocity = new Vector2(speed, 0);
                    Rotation = 0;
                    target = location + new Vector2(32, 0);
                    break;
                case Direction.LEFT:
                    Velocity = new Vector2(-speed,0);
                    Rotation = MathHelper.Pi;
                    target = location + new Vector2(-32, 0);
                    break;
                case Direction.DOWN:
                    Velocity = new Vector2(0, speed);
                    Rotation = MathHelper.PiOver2;
                    target = location + new Vector2(0, 32);
                    break;
                case Direction.UP:
                    Velocity = new Vector2(0, -speed);
                    Rotation = -MathHelper.PiOver2;
                    target = location + new Vector2(0, -32);
                    break;
            }
        }
       
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(Keys.Right))
            {
                direction = Direction.RIGHT;   
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                direction = Direction.LEFT;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                direction = Direction.DOWN;                   
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                direction = Direction.UP;  
            }


            if (velocity.X > 0 && direction == Direction.LEFT ||
                velocity.X < 0 && direction == Direction.RIGHT ||
                velocity.Y < 0 && direction == Direction.DOWN ||
                velocity.Y > 0 && direction == Direction.UP)
            {
                // if target was 32, 0, then we would want it to be 0, 0
                switch (direction)
                {
                    case Direction.LEFT: target = target - new Vector2(32, 0); break;
                    case Direction.RIGHT: target = target + new Vector2(32, 0);  break;
                    case Direction.UP: target = target - new Vector2(0, 32);  break;
                    case Direction.DOWN: target = target + new Vector2(0, 32); break;
                }

                UpdateDirection();
            }

            if ((velocity.X > 0 && location.X >= target.X) ||
                (velocity.X < 0 && location.X <= target.X) ||
                (velocity.Y > 0 && location.Y >= target.Y) ||
                (velocity.Y < 0 && location.Y <= target.Y)
                )
            {
                location = target;
                UpdateDirection();
            }
   
            base.Update(gameTime);
        }
       

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
