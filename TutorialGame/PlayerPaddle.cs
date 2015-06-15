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
        public void movePaddle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (yValue != 0)
                    yValue -= 10;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (yValue != 400)
                    yValue += 10;
            }
        }
    }
}
