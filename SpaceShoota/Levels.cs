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

        


        public static void handleLevelUpdate(GameTime gameTime, RC_GameStateManager gameStateManager, int nxtLevel)
        {

            //if (Resources.score > scoreReq)
            //{
            //    gameStateManager.setLevel(nxtLvl);
            //}

           



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

            // skip Level
            if (Input.KeyOldPressed(Keys.N) && Assets.currentLevel == 0)
                gameStateManager.setLevel(1);

            if (Input.KeyOldPressed(Keys.P))
                gameStateManager.pushLevel(3);

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

            if (Input.KeyOldPressed(Keys.P))
                gameStateManager.pushLevel(3);

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

        private Texture2D texStartBG, texTitle, texPlay;
        private Sprite3 sTitle, sPlay, sHelp, sExit;

        private static Song music;


        private bool moveUp = true;

        public override void LoadContent()
        {
            texStartBG = Content.Load<Texture2D>("menu-bg");
            
            
            texTitle = Content.Load < Texture2D>("Title");
            texPlay = Content.Load<Texture2D>("Play");

        

            sTitle = new Sprite3(true, texTitle, 180, 100); sTitle.setWidthHeight(440, 130);
            sTitle.savePosition();


            sPlay = new Sprite3(true, texPlay, 50, 300); sPlay.setWidthHeight(200, 73);
            
  
            sHelp = new Sprite3(true, Assets.texHelp, 310, 300); sHelp.setWidthHeight(200, 80);

            
            sExit = new Sprite3(true, Assets.texExit, 550, 300); sExit.setWidthHeight(200, 80);


           

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
            // experimenting with moving the title back and forth at different speeds to see to see what it looks like
            if (sTitle.getPosX()>sTitle.savePos.X + 1 || sTitle.getPosX() < sTitle.savePos.X - 1)
            {
                moveUp = !moveUp;

            }

            if (moveUp) sTitle.moveByDeltaXY(new Vector2(1, -1));

            else sTitle.moveByDeltaXY(new Vector2(-1, 1));



            Input.Update();
            if (Utility.spriteClicked(sPlay))
            {
                Utility.buttonClickSound();
                gameStateManager.setLevel(0);
            }
            if (Utility.spriteClicked(sHelp))
            {
                Utility.buttonClickSound();
                gameStateManager.setLevel(4);
                
            }
            if (Utility.spriteClicked(sExit))
            {
                Utility.buttonClickSound();
                Assets.closeGame = true;
            }
            Levels.handleLevelUpdate(gameTime, gameStateManager, 0);

        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred);
            spriteBatch.Draw(texStartBG, new Vector2(0, 0), Color.White);
            sTitle.draw(spriteBatch);
            sPlay.draw(spriteBatch);
            sHelp.draw(spriteBatch);
            sExit.draw(spriteBatch);
            

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

        private Texture2D texHelpBG, texHelpBack, texControls;
        private Sprite3 spBack;

        public override void LoadContent()
        {
            texHelpBG = Content.Load<Texture2D>("help-bg");
            texControls = Content.Load<Texture2D>("howto");
            texHelpBack = Content.Load<Texture2D>("help-back");
            spBack = new Sprite3(true, texHelpBack, 10, 20); spBack.setWidthHeight(80, 80);

        }

        public override void Update(GameTime gameTime)
        {
            Input.Update();

            if (Utility.spriteClicked(spBack))
            {
                Utility.buttonClickSound();
                gameStateManager.setLevel(2);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Assets.HelpScreenColour);

            //Game1.levelManager.prevStatePlayLevel.Draw(gameTime);

            spriteBatch.Begin();


            spriteBatch.Draw(texHelpBG, new Vector2(0,0), Color.White);
            spriteBatch.Draw(texControls, new Vector2(290, 50), Color.White);
            spBack.Draw(spriteBatch);
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
