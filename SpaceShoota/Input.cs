using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceShoota
{

    public static class Input
    {
        private static KeyboardState kbState;
        private static KeyboardState prevkbState;
        private static MouseState mState;
        private static MouseState prevmState;

        public static Vector2 mousePosition
        {
            get { return new Vector2(mState.X, mState.Y); }
        }

        public static void Update()
        {
            prevkbState = kbState;
            prevmState = mState;

            kbState = Keyboard.GetState();
            mState = Mouse.GetState();
        }



        public static bool m1Pressed()
        {
            if (mState.LeftButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public static bool m1OldPressed()
        {
            if (prevmState.LeftButton == ButtonState.Pressed && mState.LeftButton == ButtonState.Released)
                return true;
            else
                return false;
        }


        public static bool anyPressed()
        {
            if (kbState.GetPressedKeys().Length > 0)
                return true;
            else
                return false;
        }


        public static Vector2 GetDirection()
        {
            Vector2 dir = Vector2.Zero;
            dir.Y *= -1;

            if (kbState.IsKeyDown(Keys.W))
                dir.Y -= 1;
            if (kbState.IsKeyDown(Keys.S))
                dir.Y += 1;
            if (kbState.IsKeyDown(Keys.A))
                dir.X -= 1;
            if (kbState.IsKeyDown(Keys.D))
                dir.X += 1;

            if (dir.LengthSquared() > 1)
            {
                dir.Normalize();
            }

            return dir;
        }



        public static bool KeyPressed(Keys key)
        {
            return (kbState.IsKeyDown(key) && prevkbState.IsKeyUp(key));
        }

        public static bool KeyOldPressed(Keys key)
        {
            return (kbState.IsKeyUp(key) && prevkbState.IsKeyDown(key));
        }


        public static bool keyHeld(Keys key)
        {
            return (kbState.IsKeyDown(key));
        }

    }
}