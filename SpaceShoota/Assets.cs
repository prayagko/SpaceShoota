
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
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

        public static void LoadContent(ContentManager Content)
        {

            

            closeGame = false;
            // Load Textures
            texHelp = Content.Load<Texture2D>("Help");
            texMenu = Content.Load<Texture2D>("Menu");
            texContinue = Content.Load<Texture2D>("Continue");
            texExit = Content.Load<Texture2D>("Exit");
            texBack = Content.Load<Texture2D>("Back");

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




        }
    }
}
