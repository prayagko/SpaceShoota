using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RC_Framework;

namespace SpaceShoota
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        public static bool closeGame;
        public static RC_GameStateManager levelManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Assets.LoadContent(Content);
            LineBatch.init(GraphicsDevice);

            levelManager = new RC_GameStateManager();

            levelManager.AddLevel(0, new LevelOne());
            levelManager.getLevel(0).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);

            levelManager.AddLevel(1, new LevelTwo());
            levelManager.getLevel(1).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);

            levelManager.AddLevel(2, new StartScreen());
            levelManager.getLevel(2).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);

            // Preferrable to load in pause content now
            levelManager.AddLevel(3, new LevelPause());
            levelManager.getLevel(3).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);
            levelManager.getLevel(3).LoadContent();

            // Preferrable to load in how to play content now (works on push/pop stack same as pause)
            levelManager.AddLevel(4, new LevelHelp());
            levelManager.getLevel(4).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);
            levelManager.getLevel(4).LoadContent();

            levelManager.AddLevel(5, new LevelGameOver());
            levelManager.getLevel(5).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);

            levelManager.setLevel(2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (closeGame == true) Exit();

            // TODO: Add your update logic here

            levelManager.getCurrentLevel().Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Assets.StartScreenColour);

            // TODO: Add your drawing code here

            levelManager.getCurrentLevel().Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
