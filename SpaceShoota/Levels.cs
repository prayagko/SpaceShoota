using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RC_Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Microsoft.Xna.Framework.Audio;

namespace SpaceShoota
{
    public class Levels
    {
        public static string dir = Directory.GetCurrentDirectory();



        public static void handleLevelHotKeys(RC_GameStateManager gameStateManager, int nextLevel)
        {
            // Handle Help Button
            if (Input.KeyOldPressed(Keys.H))
                gameStateManager.pushLevel(4);

            // Handle Pausing
            if (Input.KeyPressed(Keys.P))
                gameStateManager.pushLevel(3);

            // skip Level
            if (Input.KeyPressed(Keys.N))
                gameStateManager.setLevel(nextLevel);
        }

        public static void handleLevelUpdate(GameTime gameTime, RC_GameStateManager gameStateManager, int nxtLevel)
        {

            //if (Resources.score > scoreReq)
            //{
            //    gameStateManager.setLevel(nxtLvl);
            //}

            Levels.handleLevelHotKeys(gameStateManager, nxtLevel);



        }


        public static void handleLevelBasicDrawing(SpriteBatch spriteBatch, int ticksRemaining)
        {

        }
    }

    class LevelOne : RC_GameStateParent
    {

        public override void InitializeLevel(GraphicsDevice g, SpriteBatch s, ContentManager c, RC_GameStateManager lm)
        {


            base.InitializeLevel(g, s, c, lm);
        }

        public override void EnterLevel(int fromLevelNum)
        {

            Assets.currentLevel = 0;
        }

        public override void Update(GameTime gameTime)
        {
            // Handle input
            Input.Update();


            // Update our level with modified variables pertaining to our play level
            Levels.handleLevelUpdate(gameTime, gameStateManager, 1);
        }

        public override void Draw(GameTime gameTime)
        {
            // Set the background, incase different
            graphicsDevice.Clear(Assets.LvlOneColour);

            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);

            Levels.handleLevelBasicDrawing(spriteBatch, -1);

            spriteBatch.End();
        }
    }

    class LevelTwo : RC_GameStateParent
    {

        public override void InitializeLevel(GraphicsDevice g, SpriteBatch s, ContentManager c, RC_GameStateManager lm)
        {

            base.InitializeLevel(g, s, c, lm);
        }

        public override void EnterLevel(int fromLevelNum)
        {
            Assets.currentLevel = 1;
        }

        public override void Update(GameTime gameTime)
        {
            // Handle our player input
            Input.Update();
            // Update our level with modified variables pertaining to our play level
            Levels.handleLevelUpdate(gameTime, gameStateManager, 2);

        }

        public override void Draw(GameTime gameTime)
        {
            // Set the background, incase different
            graphicsDevice.Clear(Assets.LvlTwoColour);

            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);

            Levels.handleLevelBasicDrawing(spriteBatch, -1);

            spriteBatch.End();
        }
    }


    class StartScreen : RC_GameStateParent
    {

        private Texture2D texTitle, texPlay, texHelp;
        private Sprite3 sTitle;


        public override void LoadContent()
        {


        }


        public override void EnterLevel(int fromLevelNum)
        {
            Assets.currentLevel = 0;
            LoadContent();
        }

        public override void ExitLevel()
        {
            UnloadContent();
        }



        public override void Update(GameTime gameTime)
        {

            Input.Update();

            Levels.handleLevelUpdate(gameTime, gameStateManager, 0);

        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Assets.StartScreenColour);

            spriteBatch.Begin(SpriteSortMode.Deferred);

            spriteBatch.End();
        }
    }

    class LevelPause : RC_GameStateParent
    {


        public override void LoadContent()
        {

        }

        public override void EnterLevel(int fromLevelNum)
        {
            int currLevel = gameStateManager.getCurrentLevelNum();

        }

        public override void Update(GameTime gameTime)
        {
            Input.Update();

            if (Input.KeyPressed(Keys.Space))
                gameStateManager.popLevel();
        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Assets.PauseScreenColour);

            //Game1.levelManager.prevStatePlayLevel.Draw(gameTime);

            spriteBatch.Begin();

            spriteBatch.End();

        }
    }

    class LevelHelp : RC_GameStateParent
    {


        public override void LoadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            Input.Update();

            if (Input.KeyPressed(Keys.Space))
                gameStateManager.popLevel();
        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Assets.HelpScreenColour);

            //Game1.levelManager.prevStatePlayLevel.Draw(gameTime);

            spriteBatch.Begin();


            spriteBatch.End();

        }
    }

    class LevelGameOver : RC_GameStateParent
    {
        private int timeWaitTicks = 50;
        private int timeWaitCurrent = 0;

        public override void EnterLevel(int fromLevelNum)
        {
            timeWaitCurrent = timeWaitTicks;

            Assets.currentLevel = 0;
        }

        public override void Update(GameTime gameTime)
        {
            Input.Update();

            if (timeWaitCurrent <= 0)
            {

                if (Input.anyPressed())
                {
                    gameStateManager.setLevel(4);
                }
            }


            if (timeWaitCurrent > 0)
            {
                timeWaitCurrent--;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Assets.GameOverScreenColour);

            spriteBatch.Begin();


            spriteBatch.End();
        }
    }


}
