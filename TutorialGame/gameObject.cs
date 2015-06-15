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
        public SpriteBatch spriteBatch;
        public Texture2D sprite;
        protected int xValue;
        protected int yValue;

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
        
    }
}
