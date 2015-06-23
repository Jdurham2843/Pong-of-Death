using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TutorialGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        gameObjectManager GameObjectManager;
        SpriteFont scoreFont;
        SpriteBatch spriteBatch;
        Vector2 playerScorePos;
        Vector2 enemyScorePos;
        Vector2 winMessagePos;
        string winMessage;
        int playerScore = 0;
        int enemyScore = 0;
        enum GameState { playing, gameOver, splashscreen, menuScreen};
        GameState gameState;

        enum MenuState { Menu1, Menu2 };
        MenuState menuState;

        Texture2D splashScreen;
        Texture2D menuImage1;
        Texture2D menuImage2;
        
        
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            GameObjectManager = new gameObjectManager();
            playerScorePos = new Vector2(200, 50);
            enemyScorePos = new Vector2(600, 50);
            winMessagePos = new Vector2(400, 240);
            scoreFont = Content.Load<SpriteFont>("MyFont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameState = GameState.splashscreen;
            

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            GameObjectManager.playerPaddle.sprite = Content.Load<Texture2D>("paddle");
            GameObjectManager.enemyPaddle.sprite = Content.Load<Texture2D>("paddle");
            GameObjectManager.Ball.sprite = Content.Load<Texture2D>("ball");


            splashScreen = Content.Load<Texture2D>("PongSplashScreen");
            menuImage1 = Content.Load<Texture2D>("PongMenu1");
            menuImage2 = Content.Load<Texture2D>("PongMenu2");
            menuState = MenuState.Menu1;
            
            
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Game Logic

            if (gameState == GameState.splashscreen)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.menuScreen;
                }
            }
            
            else if (gameState == GameState.menuScreen)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (menuState == MenuState.Menu1)
                        menuState = MenuState.Menu2;
                    else if (menuState == MenuState.Menu2)
                        menuState = MenuState.Menu1;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    if (menuState == MenuState.Menu1)
                    {
                        gameState = GameState.playing;
                    }
                    else if (menuState == MenuState.Menu2)
                    {
                        Exit();
                    }
                }

            }

            else if (gameState == GameState.playing)
            {
                GameObjectManager.playerPaddle.movePaddle();
                GameObjectManager.enemyPaddle.movePaddle();
                GameObjectManager.Ball.moveBall();
                GameObjectManager.Ball.ballCollision(GameObjectManager.playerPaddle.Rectangle, GameObjectManager.playerPaddle.player);
                GameObjectManager.Ball.ballCollision(GameObjectManager.enemyPaddle.Rectangle, GameObjectManager.enemyPaddle.player);
                GameObjectManager.Ball.ballCollision(GameObjectManager.screenTop, 0);
                GameObjectManager.Ball.ballCollision(GameObjectManager.screenBottom, 0);
                GameObjectManager.Ball.checkBounds(ref playerScore, ref enemyScore);

                if (playerWin(playerScore))
                {
                    winMessage = "Player 1 Wins!!!";
                    gameState = GameState.gameOver;
                }
                else if (enemyWin(enemyScore))
                {
                    winMessage = "Player 2 Wins!!!";
                    gameState = GameState.gameOver;
                }
            }
            else if (gameState == GameState.gameOver)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.menuScreen;
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            

            if (gameState == GameState.playing)
            {
                spriteBatch.Draw(GameObjectManager.playerPaddle.sprite,
                    GameObjectManager.playerPaddle.Rectangle, Color.White);
                spriteBatch.Draw(GameObjectManager.enemyPaddle.sprite,
                    GameObjectManager.enemyPaddle.Rectangle, Color.White);
                spriteBatch.Draw(GameObjectManager.Ball.sprite,
                    GameObjectManager.Ball.Rectangle, Color.White);
                spriteBatch.DrawString(scoreFont, playerScore.ToString(), playerScorePos, Color.White);
                spriteBatch.DrawString(scoreFont, enemyScore.ToString(), enemyScorePos, Color.White);
            }
            else if (gameState == GameState.gameOver)
            {
                spriteBatch.DrawString(scoreFont, winMessage, winMessagePos , Color.White);
            }
            else if (gameState == GameState.splashscreen)
            {
                spriteBatch.Draw(splashScreen, new Rectangle(0, 0, 800, 480), Color.White);
            }
            else if (gameState == GameState.menuScreen)
            {
                if (menuState == MenuState.Menu1)
                    spriteBatch.Draw(menuImage1, new Rectangle(0, 0, 800, 480), Color.White);
                else
                    spriteBatch.Draw(menuImage2, new Rectangle(0, 0, 800, 480), Color.White);
            }
            spriteBatch.End();

            


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public bool playerWin(int p_playerScore)
        {
            return (playerScore == 10);
        }

        public bool enemyWin(int p_enemyScore)
        {
            return (enemyScore == 10);
        }

        
    }
}

