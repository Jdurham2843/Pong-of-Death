using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TutorialGame
{
    class gameObjectManager
    {
        public PlayerPaddle playerPaddle;
        public EnemyPaddle enemyPaddle;
        public ball Ball;
        public int playerScore;
        public int enemyScore;
        public Rectangle screenTop;
        public Rectangle screenBottom;

        public gameObjectManager()
        {
            playerPaddle = new PlayerPaddle(10.0);
            enemyPaddle = new EnemyPaddle(10.0);
            Ball = new ball(395, 237);
            screenTop = new Rectangle(0, -5, 800, 5);
            screenBottom = new Rectangle(0, 480, 800, 5);
           

            playerScore = 0;
            enemyScore = 0;
        }
    }
}
