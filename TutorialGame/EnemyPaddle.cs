using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TutorialGame
{
    class EnemyPaddle : Paddle
    {
        public void movePaddle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (yValue != 0)
                    yValue -= 10;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (yValue != 400)
                    yValue += 10;
            }
        }
    }
}
