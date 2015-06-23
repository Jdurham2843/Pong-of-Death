using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TutorialGame
{
    abstract class GameScreen
    {
        private Texture2D screenImage;

        protected void Initialize()
        {
        }

        protected void UnloadContent()
        { }

        protected void LoadContent(string imageName)
        { 
        }

        protected void Update(GameTime gameTime)
        { }

        protected void Draw(SpriteBatch spriteBatch)
        { }
    }
}
