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

        public gameObjectManager()
        {
            playerPaddle = new PlayerPaddle(10);
            enemyPaddle = new EnemyPaddle(10);
            Ball = new ball(395, 237, 9, 3);
           

            playerScore = 0;
            enemyScore = 0;
        }
    }
}
