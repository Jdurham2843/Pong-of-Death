using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TutorialGame
{
    class gameObjectManager
    {
        public PlayerPaddle playerPaddle = new PlayerPaddle();
        public EnemyPaddle enemyPaddle = new EnemyPaddle();
        public ball Ball = new ball();
        public int playerScore;
        public int enemyScore;

        public gameObjectManager()
        {
            playerPaddle.XValue = 0;
            playerPaddle.YValue = 0;

            enemyPaddle.XValue = 770;
            enemyPaddle.YValue = 0;

            Ball.XValue = 395;
            Ball.YValue = 237;

            playerScore = 0;
            enemyScore = 0;
        }
    }
}
