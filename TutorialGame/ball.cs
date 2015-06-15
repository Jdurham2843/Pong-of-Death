using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TutorialGame
{
    class ball: gameObject
    {

        public ball(int p_xValue, int p_yValue, int p_xVelocity, int p_yVelocity)
        {
            xValue = p_xValue;
            yValue = p_yValue;
            xVelocity = p_xVelocity;
            yVelocity = p_yVelocity;
            rectangle = new Rectangle(xValue, yValue, 15, 15);
        }
        public void moveAround(Paddle player, Paddle enemy)
        {
            if (rectangle.Y != 0 && rectangle.Y != 465)
            {
                rectangle.Y += yVelocity;
                rectangle.X += xVelocity;
            }
            else if (rectangle.Y <= 0 || rectangle.Y >= 465)
            {
                yVelocity = -yVelocity;
                rectangle.Y += yVelocity;
                rectangle.X += xVelocity;
            }

            if (rectangle.Intersects(player.Rectangle) || rectangle.Intersects(enemy.Rectangle))
            {
                xVelocity = -xVelocity;
            }
        }

        public void checkBounds()
        {
            if (rectangle.X < 0 || rectangle.X > 800)
                resetBall();
        }

        public void changeXVelocity()
        {
            xVelocity = -xVelocity;
            xValue += xVelocity;
        }

        public void resetBall()
        {
            rectangle.X = 395;
            rectangle.Y = 297;
        }

    }
}
