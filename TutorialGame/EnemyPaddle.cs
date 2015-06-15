using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TutorialGame
{
    class EnemyPaddle : Paddle
    {
        
        public EnemyPaddle(int p_yVelocity)
        {
            xValue = 770;
            yValue = 240;
            yVelocity = p_yVelocity;
            rectangle = new Rectangle(xValue, yValue, 30, 80);
            player = 2;
        }
        public void movePaddle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (rectangle.Y != 0)
                    rectangle.Y -= yVelocity;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (rectangle.Y != 400)
                    rectangle.Y += yVelocity;
            }
        }
    }
}
