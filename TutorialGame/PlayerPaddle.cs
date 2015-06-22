using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TutorialGame
{
    class PlayerPaddle : Paddle
    {

        
        public PlayerPaddle(double p_yVelocity)
        {
            xValue = 50;
            yValue = 240;
            yVelocity = p_yVelocity;
            rectangle = new Rectangle(xValue, yValue, 30, 80);
            player = 1;
        }
        public void movePaddle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (rectangle.Y != 0)
                    rectangle.Y -= (int)yVelocity;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (rectangle.Y != 400)
                    rectangle.Y += (int)yVelocity;
            }
        }
    }
}
