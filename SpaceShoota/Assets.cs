
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using RC_Framework;

namespace SpaceShoota
{

    public static class Assets
    {
        //boolean
        public static bool closeGame;


        public static int score = 0;
        public static int currentLevel = 0;

        // Textures
        public static Texture2D texHelp;
        public static Texture2D texContinue;
        public static Texture2D texMenu;
        public static Texture2D texExit;
        public static Texture2D texBack;
        public static Texture2D texShip;
        public static Texture2D texEnemyGunship;
        public static Texture2D texPlayerBullet;
        public static Texture2D texEnemyBullet;


        // Fonts
        public static SpriteFont fonty;

        // Colours
        public static Color StartScreenColour;
        public static Color PlayScreenColour;
        public static Color PauseScreenColour;
        public static Color HelpScreenColour;
        public static Color GameOverScreenColour;
        public static Color LvlOneColour;
        public static Color LvlTwoColour;
        public static Color LvlThreeColour;
        //Strings
        public static string dir;
        //Sounds
        public static SoundEffect soundSelect;
        public static Song mainMusic;
        public static Song helpMusic;
        public static SoundEffect soundLaser;
        public static SoundEffect soundExplosion;
        public static SoundEffect soundPlayerHit;

        public static void LoadContent(ContentManager Content)
        {

            

            closeGame = false;
            // Load Textures
            texHelp = Content.Load<Texture2D>("Help");
            texMenu = Content.Load<Texture2D>("Menu");
            texContinue = Content.Load<Texture2D>("Continue");
            texExit = Content.Load<Texture2D>("Exit");
            texBack = Content.Load<Texture2D>("Back");
            texShip = Content.Load<Texture2D>("SShip10");
            texEnemyGunship = Content.Load<Texture2D>("enemy-ship");
            texPlayerBullet = Content.Load<Texture2D>("player-bullet");
            texEnemyBullet = Content.Load<Texture2D>("enemy-bullet");

            // Load Colours
            StartScreenColour = new Color(216, 182, 227);
            PlayScreenColour = new Color(134, 130, 135);
            PauseScreenColour = new Color(237, 181, 166);
            HelpScreenColour = new Color(74, 139, 140);
            GameOverScreenColour = new Color(Color.Black, 0.75f);
            LvlOneColour = new Color(185, 189, 189);
            LvlTwoColour = new Color(255, 163, 147);
            LvlThreeColour = new Color(136, 15, 199);

            //Load Font
            fonty = Content.Load<SpriteFont>("arialHeading");


            soundSelect = Content.Load<SoundEffect>("buttonClick");
            soundLaser = Content.Load<SoundEffect>("sndLaser");
            soundExplosion = Content.Load<SoundEffect>("sndExplode");
            soundPlayerHit = Content.Load<SoundEffect>("impact");

            mainMusic = Content.Load<Song>("bg-music");
            helpMusic = Content.Load<Song>("help-music");

        }
    }
}
