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
        public void moveAround(Rectangle player, Rectangle enemy, Rectangle screenTop, Rectangle screenBottom)
        {
            //checks for top/bottom frame collision
            if (rectangle.Intersects(screenTop) || rectangle.Intersects(screenBottom))
            {
                changeYVelocity();
                rectangle.Y += yVelocity;
                rectangle.X += xVelocity;
            }
            else 
            {
                rectangle.Y += yVelocity;
                rectangle.X += xVelocity;
            }

            //checks for paddle collision
            if (rectangle.Intersects(player) || rectangle.Intersects(enemy))
            {
                changeXVelocity();
                rectangle.Y += yVelocity;
                rectangle.X += xVelocity;
            }
            else
            {
                rectangle.Y += yVelocity;
                rectangle.X += xVelocity;
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
        }

        public void changeYVelocity()
        {
            yVelocity *= -1;
        }

        public void resetBall()
        {
            rectangle.X = 395;
            rectangle.Y = 297;
        }

    }
}
