using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using xTile.Tiles;

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
        xTile.Map map;
        

        public Pacman(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity,
            xTile.Map map) :

            base(location, texture, initialFrame, velocity)
        {
            direction = Direction.RIGHT;
            target = location + new Vector2(32, 0);
            this.map = map;

            UpdateDirection();
        }

        public bool CanMove (Direction dir)
        {
            Vector2 othertarget = Vector2.Zero;

            switch (dir)
            {
                case Direction.RIGHT:
                    othertarget = target + new Vector2(32, 0);
                    break;
                case Direction.LEFT:
                    othertarget = target + new Vector2(-32, 0);
                    break;
                case Direction.DOWN:
                    othertarget = target + new Vector2(0, 32);
                    break;
                case Direction.UP:
                    othertarget = target + new Vector2(0, -32);
                    break;
            }

             Tile tile = map.Layers[0].Tiles[(int)(othertarget.X / 32), (int)(othertarget.Y / 32)];

             if (tile != null)
             {
                 return false;
             }

            return true;
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
                if (CanMove(Direction.RIGHT))
                    direction = Direction.RIGHT;   
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                if(CanMove(Direction.LEFT))
                    direction = Direction.LEFT;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                if(CanMove(Direction.DOWN))
                    direction = Direction.DOWN;                   
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                if(CanMove(Direction.UP))
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

                if (CanMove(direction))
                {
                    UpdateDirection();
                }
            }   
            base.Update(gameTime);
        }
       
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
