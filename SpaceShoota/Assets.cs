
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace SpaceShoota
{

    public static class Assets
    {

        public static int score = 0;
        public static int currentLevel = 0;

        // Textures
        public static Texture2D texHelp;
        public static Texture2D texContinue;

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

        // Strings

        public static string title;

        //Sounds
        public static SoundEffect soundSelect;

        public static void LoadContent(ContentManager content)
        {
            // Load Textures
            texHelp = content.Load<Texture2D>("Help");
            texHelp = content.Load<Texture2D>("Continue");

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
            //fonty = content.Load<SpriteFont>("arialHeading");

            //Load Sound
            //soundSelect = content.Load<SoundEffect>("vgmenuselect");

            // Load Titles
            title = "SPACE SHOOTA";

        }
    }
}
