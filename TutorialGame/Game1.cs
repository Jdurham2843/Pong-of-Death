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
        SpriteBatch scoreBatch;
        SpriteBatch enemyBatch;
        Vector2 playerScorePos;
        Vector2 enemyScorePos;
        int playerScore = 0;
        int enemyScore = 0;
        
        
        
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
            scoreFont = Content.Load<SpriteFont>("MyFont");
            scoreBatch = new SpriteBatch(GraphicsDevice);
            enemyBatch = new SpriteBatch(GraphicsDevice);

            // Create a new SpriteBatch, which can be used to draw textures.
            GameObjectManager.playerPaddle.spriteBatch = new SpriteBatch(GraphicsDevice);
            GameObjectManager.enemyPaddle.spriteBatch = new SpriteBatch(GraphicsDevice);
            GameObjectManager.Ball.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            GameObjectManager.playerPaddle.sprite = Content.Load<Texture2D>("paddle");
            GameObjectManager.enemyPaddle.sprite = Content.Load<Texture2D>("paddle");
            GameObjectManager.Ball.sprite = Content.Load<Texture2D>("ball");

            
            
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

            // TODO: Add your update logic here

            GameObjectManager.playerPaddle.movePaddle();
            GameObjectManager.enemyPaddle.movePaddle();
            GameObjectManager.Ball.moveAround();

            if (GameObjectManager.Ball.XValue == 30 && 
                GameObjectManager.Ball.YValue > GameObjectManager.playerPaddle.YValue &&
                GameObjectManager.Ball.YValue < (GameObjectManager.playerPaddle.YValue + 80))
            {
                GameObjectManager.Ball.changeXVelocity();
            }

            if (GameObjectManager.Ball.XValue == 770 &&
                GameObjectManager.Ball.YValue > GameObjectManager.enemyPaddle.YValue &&
                GameObjectManager.Ball.YValue < (GameObjectManager.enemyPaddle.YValue + 80))
            {
                GameObjectManager.Ball.changeXVelocity();
            }

            if (GameObjectManager.Ball.XValue == 0)
                enemyScore++;

            if (GameObjectManager.Ball.XValue == 800)
                playerScore++;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            GameObjectManager.playerPaddle.spriteBatch.Begin();
            GameObjectManager.playerPaddle.spriteBatch.Draw(GameObjectManager.playerPaddle.sprite,
                new Rectangle(GameObjectManager.playerPaddle.XValue,
                GameObjectManager.playerPaddle.YValue, 30, 80), Color.White);
            GameObjectManager.playerPaddle.spriteBatch.End();

            GameObjectManager.enemyPaddle.spriteBatch.Begin();
            GameObjectManager.enemyPaddle.spriteBatch.Draw(GameObjectManager.enemyPaddle.sprite,
                new Rectangle(GameObjectManager.enemyPaddle.XValue,
                GameObjectManager.enemyPaddle.YValue, 30, 80), Color.White);
            GameObjectManager.enemyPaddle.spriteBatch.End();

            GameObjectManager.Ball.spriteBatch.Begin();
            GameObjectManager.Ball.spriteBatch.Draw(GameObjectManager.Ball.sprite,
                new Rectangle(GameObjectManager.Ball.XValue,
                GameObjectManager.Ball.YValue, 15, 15), Color.White);
            GameObjectManager.Ball.spriteBatch.End();

            scoreBatch.Begin();
            scoreBatch.DrawString(scoreFont, playerScore.ToString() ,playerScorePos, Color.White);
            scoreBatch.End();

            enemyBatch.Begin();
            enemyBatch.DrawString(scoreFont, enemyScore.ToString() ,enemyScorePos, Color.White);
            enemyBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        
    }
}

