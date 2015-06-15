using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TutorialGame
{
    class ball: gameObject
    {
        int xVelocity = 5;
        int yVelocity = 3;

        public int XVelocity
        {
            get {return xVelocity;}

            set { xVelocity = value; }
        }

        public int YVelocity
        {
            get { return yVelocity; }
            set { yVelocity = value; }
        }

        public void moveAround()
        {
            if (yValue != 0 && yValue != 465)
            {
                yValue += yVelocity;
                xValue += xVelocity;
            }
            else
            {
                if (yValue == 0 || yValue == 465)
                {
                    yVelocity = -yVelocity;
                    yValue += yVelocity;
                }

                if (xValue < 0 || xValue > 800)
                {
                    resetBall();
                }
            }
        }

        public void changeXVelocity()
        {
            xVelocity = -xVelocity;
            xValue += xVelocity;
        }

        public void resetBall()
        {
            xValue = 395;
            yValue = 297;
        }
    }
}
