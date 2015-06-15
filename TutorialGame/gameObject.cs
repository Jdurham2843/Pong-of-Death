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
        protected int xVelocity;
        protected int yVelocity;

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

        public int XVelocity
        {
            get { return xVelocity; }
            set { xVelocity = value; }
        }

        public int YVelocity
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
