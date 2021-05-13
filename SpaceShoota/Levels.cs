using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RC_Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;


namespace SpaceShoota
{
    public class Levels
    {
       
    }

    class LevelOne : RC_GameStateParent

    {
        public bool showbb = false;
        public Player player;

        public List<EnemyShip> enemyShipList = new List<EnemyShip>();

        private List<Bullet> bullets = new List<Bullet>();
        private List<Bullet> enemyBullets = new List<Bullet>();

        public override void InitializeLevel(GraphicsDevice g, SpriteBatch s, ContentManager c, RC_GameStateManager lm)
        {

            base.InitializeLevel(g, s, c, lm);
        }

        public override void LoadContent()
        {
            player = new Player(Assets.texShip, new Vector2(200, 250));
            enemyShipList = Utility.makeEnemyShipList(4);
        }

        public int coolDownTick = 15;

        public int largeCoolDownTick = 50;
        public override void Update(GameTime gameTime)
        {
            coolDownTick--;
            largeCoolDownTick--;
            // Handle input
            Input.Update();

            if (Input.KeyOldPressed(Keys.B)) showbb = !showbb;

            // skip Level
            if (Input.KeyOldPressed(Keys.N) && Assets.currentLevel == 0)
                gameStateManager.setLevel(1);

            if (Input.KeyOldPressed(Keys.P))
                gameStateManager.pushLevel(3);


            if (Input.KeyOldPressed(Keys.Space))
            {
                if (coolDownTick < 1)

                {
                    coolDownTick = 15;
                    Assets.soundLaser.Play();
                    Bullet bullet = new Bullet(Assets.texPlayerBullet, new Vector2(player.position.X, player.position.Y + player.getNewSize().Y / 2), 8);
                    bullets.Add(bullet);

                }
            }


            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();


                if (bullets[i].getSprite().getPosX() > 800)
                {
                    bullets.Remove(bullets[i]);
                    continue;
                }
            }



            player.Update();


            for (int i = 0; i < enemyBullets.Count; i++)
            {


                if (player.getSprite().collision(enemyBullets[i].getSprite()))
                {
                    //sndExplode[randInt(0, sndExplode.Count - 1)].Play();
                    //Explosion explosion = new Explosion(texExplosion, new Vector2(player.position.X + player.destOrigin.X, player.position.Y + player.destOrigin.Y));
                    //explosions.Add(explosion);
                    Assets.soundPlayerHit.Play();
                    if (enemyBullets.Any())
                    {
                        enemyBullets.Remove(enemyBullets[i]);
                    }

                    player.takeDamage(1);

                }
            }

            for (int i = 0; i < enemyBullets.Count; i++)
            {
                enemyBullets[i].Update();



                if (enemyBullets[i].getSprite().getPosX()<10)
                {
          
                     enemyBullets.Remove(enemyBullets[i]);
                 
                }
            }

            for (int i = 0; i < enemyShipList.Count; i++)
            {
                enemyShipList[i].Update();
                if (enemyShipList[i].canShoot)
                {
                    Bullet bullet = new Bullet(Assets.texEnemyBullet, new Vector2(enemyShipList[i].getSprite().getPosX(), enemyShipList[i].getSprite().getPosY() + enemyShipList[i].getSprite().getHeight() / 2), -4);
                    enemyBullets.Add(bullet);
                    enemyShipList[i].resetCanShoot();
                }

                if (player.getSprite().collision(enemyShipList[i].getSprite()))
                {

                    if (enemyShipList.Any())
                    {
                        enemyShipList[i].dead = true;
                    }

                    player.takeDamage(1);
                }

                for (int j = 0; j < bullets.Count; j++) {
                    if (bullets[j].getSprite().collision(enemyShipList[i].getSprite()))
                    {
                        Assets.soundExplosion.Play();
                        enemyShipList[i].dead = true;
                        bullets.Remove(bullets[j]);


                    }
                }  

            }



        }

        public override void Draw(GameTime gameTime)
        {
            // Set the background, incase different
            graphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            player.Draw(spriteBatch);
            if (showbb) player.getSprite().getBB();

            for (int i = 0; i < enemyShipList.Count; i++)
            {
                enemyShipList[i].Draw(spriteBatch);
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(spriteBatch);
        
            }

            for (int i = 0; i < enemyBullets.Count; i++)
            {
                enemyBullets[i].Draw(spriteBatch);
            }

            spriteBatch.End();
        }
    }

    class LevelTwo : RC_GameStateParent
    {
        

        public override void InitializeLevel(GraphicsDevice g, SpriteBatch s, ContentManager c, RC_GameStateManager lm)
        {

            base.InitializeLevel(g, s, c, lm);
        }

        public override void LoadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            // Handle our player input
            Input.Update();

            if (Input.KeyOldPressed(Keys.P))
                gameStateManager.pushLevel(3);

            // Update our level with modified variables pertaining to our play level
            

        }

        public override void Draw(GameTime gameTime)
        {
            // Set the background, incase different
            graphicsDevice.Clear(Assets.LvlTwoColour);

            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);

           

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


        public override void Update(GameTime gameTime)
        {
            Input.Update();

            if (Input.KeyPressed(Keys.Delete))
                gameStateManager.popLevel();
        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Assets.PauseScreenColour);


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

            spriteBatch.Begin();


            spriteBatch.Draw(texHelpBG, new Vector2(0,0), Color.White);
            spriteBatch.Draw(texControls, new Vector2(290, 50), Color.White);
            spBack.Draw(spriteBatch);
            spriteBatch.End();

        }
    }

    class LevelGameOver : RC_GameStateParent
    {



        public override void Update(GameTime gameTime)
        {
            Input.Update();


            //if (Input.anyPressed())
            //{
            //    gameStateManager.setLevel(4);
            //}

        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            spriteBatch.End();
        }
    }


}
