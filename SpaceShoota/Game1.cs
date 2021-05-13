using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RC_Framework;
using Microsoft.Xna.Framework.Media;

namespace SpaceShoota
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        
        public static RC_GameStateManager levelManager;

        public static Vector2 screenSize = new Vector2(800, 600);


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 800;

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
            MediaPlayer.IsRepeating = true;

            MediaPlayer.Play(Assets.mainMusic);




            levelManager = new RC_GameStateManager();

            levelManager.AddLevel(0, new LevelOne());
            levelManager.getLevel(0).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);
            levelManager.getLevel(0).LoadContent();

            levelManager.AddLevel(1, new LevelTwo());
            levelManager.getLevel(1).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);
            levelManager.getLevel(1).LoadContent();

            levelManager.AddLevel(2, new StartScreen());
            levelManager.getLevel(2).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);
            levelManager.getLevel(2).LoadContent();

            levelManager.AddLevel(3, new LevelPause());
            levelManager.getLevel(3).InitializeLevel(GraphicsDevice, spriteBatch, Content, levelManager);
            levelManager.getLevel(3).LoadContent();

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

            if (Assets.closeGame == true) Exit();


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
