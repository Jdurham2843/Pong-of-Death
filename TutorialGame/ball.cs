using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TutorialGame
{
    class ball: gameObject
    {
        private bool intersects;
        private double ballSpeed;
        public ball(int p_xValue, int p_yValue)
        {
            xValue = p_xValue;
            yValue = p_yValue;
            xVelocity = Math.Cos(Math.PI / 4.0);
            yVelocity = Math.Sin(Math.PI / 4.0);
            rectangle = new Rectangle(xValue, yValue, 15, 15);
            intersects = false;
            ballSpeed = 5.0;
        }

        public void ballCollision(Rectangle gameObject, int playerNum)
        {
            if (rectangle.Intersects(gameObject) && intersects == false)
            {
                intersects = true;
                if ((gameObject.Y == -5 || gameObject.Y == 480) && gameObject.Width == 800) //top/bottom
                {
                    if (gameObject.Y == -5)//protection against ball getting stuck in wall
                        rectangle.Y = 1;
                    else
                        rectangle.Y = 465;

                    yVelocity *= -1;
                }
                else if ((gameObject.Y == 0) && gameObject.Height == 480) //left/right
                {
                    if (gameObject.X == -5)//protection against ball getting stuck in wall
                        rectangle.X = 1;
                    else
                        rectangle.X = 775;

                    xVelocity *= -1;
                }
                else if (gameObject.Height == 80)
                {
                    if (playerNum == 1)
                    {
                        if ((rectangle.Y + 7.5) >= gameObject.Y && (rectangle.Y + 7.5) < (gameObject.Y + 16)) // tip top part
                        {
                            rectangle.X = gameObject.X + 30; // stuck protection
                            xVelocity = Math.Cos(Math.PI / 4.0);
                            yVelocity = -Math.Sin(Math.PI / 4.0);
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 16) && (rectangle.Y + 7.5) < (gameObject.Y + 32)) //mid top
                        {
                            rectangle.X = gameObject.X + 30; //stuck protection
                            xVelocity = Math.Cos(Math.PI / 12.0);
                            yVelocity = -Math.Sin(Math.PI / 12.0);
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 32) && (rectangle.Y + 7.5) < (gameObject.Y + 48)) //middle section
                        {
                            rectangle.X = gameObject.X + 30; //stuck protection
                            xVelocity = 1;
                            yVelocity = 0;
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 48) && (rectangle.Y + 7.5) < (gameObject.Y + 64)) //bottom mid
                        {
                            rectangle.X = gameObject.X + 30; //stuck protection
                            xVelocity = Math.Cos(Math.PI / 12.0);
                            yVelocity = Math.Sin(Math.PI / 12.0);
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 64) && (rectangle.Y + 7.5) <= (gameObject.Y + 80))// bot bottom
                        {
                            rectangle.X = gameObject.X + 30; //stuck protection
                            xVelocity = Math.Cos(Math.PI / 4.0);
                            yVelocity = Math.Sin(Math.PI / 4.0);
                        }
                    }
                    else if (playerNum == 2)
                    {
                        if ((rectangle.Y + 7.5) >= gameObject.Y && (rectangle.Y + 7.5) < (gameObject.Y + 16)) // tip top part
                        {
                            rectangle.X = gameObject.X - 30; // stuck protection
                            xVelocity = -Math.Cos(Math.PI / 4.0);
                            yVelocity = -Math.Sin(Math.PI / 4.0);
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 16) && (rectangle.Y + 7.5) < (gameObject.Y + 32)) //mid top
                        {
                            rectangle.X = gameObject.X - 30; //stuck protection
                            xVelocity = -Math.Cos(Math.PI / 12.0);
                            yVelocity = -Math.Sin(Math.PI / 12.0);
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 32) && (rectangle.Y + 7.5) < (gameObject.Y + 48)) //middle section
                        {
                            rectangle.X = gameObject.X - 30; //stuck protection
                            xVelocity = -1;
                            yVelocity = 0;
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 48) && (rectangle.Y + 7.5) < (gameObject.Y + 64)) //bottom mid
                        {
                            rectangle.X = gameObject.X - 30; //stuck protection
                            xVelocity = -Math.Cos(Math.PI / 12.0);
                            yVelocity = Math.Sin(Math.PI / 12.0);
                        }
                        else if ((rectangle.Y + 7.5) >= (gameObject.Y + 64) && (rectangle.Y + 7.5) <= (gameObject.Y + 80))// bot bottom
                        {
                            rectangle.X = gameObject.X - 30; //stuck protection
                            xVelocity = -Math.Cos(Math.PI / 4.0);
                            yVelocity = Math.Sin(Math.PI / 4.0);
                        }
                    }
                    ballSpeed += 1.0f;
                }
            }
            else
                intersects = false;
        }

        public void moveBall() 
        {
            rectangle.Y += (int)(yVelocity * ballSpeed);
            rectangle.X += (int)(xVelocity * ballSpeed);
        }

        public void checkBounds(ref int playerScore, ref int enemyScore)
        {
            if (rectangle.X < 0 )
            {
                enemyScore++;
                resetBall();
            }
             
            else if (rectangle.X > 800)
            {
                playerScore++;
                resetBall();
            }
        }


        public void resetBall()
        {
            rectangle.X = 395;
            rectangle.Y = 297;
            ballSpeed = 5.0;
        }

    }
}
