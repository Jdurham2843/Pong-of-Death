using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TutorialGame
{
    public class gameObject
    {
        public Texture2D sprite;
        protected int xValue;
        protected int yValue;
        protected Rectangle rectangle;
        protected double xVelocity;
        protected double yVelocity;

        public int XValue
        {
            get { return xValue; }

            set { xValue = value; }
        }

        public int YValue
        {
            get { return yValue; }

            set { yValue = value; }
        }

        public double XVelocity
        {
            get { return xVelocity; }
            set { xVelocity = value; }
        }

        public double YVelocity
        {
            get { return yVelocity; }
            set { yVelocity = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        
    }
}
