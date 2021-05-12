using System;
using RC_Framework;

using Microsoft.Xna.Framework.Audio;


namespace SpaceShoota
{
    public class Utility
    {


        public static bool spriteClicked(Sprite3 sp)
        {
            if (sp.inside(Input.mousePosition.X, Input.mousePosition.Y))
            {
                if (Input.m1OldPressed())
                {
                    return true;
                }
            }
            return false;

        }


        public static void buttonClickSound() {

            Assets.soundSelect.Play();
        }


        public static int randInt(int minNumber, int maxNumber)
        {
            return new Random().Next(minNumber, maxNumber);
        }


        public static float randFloat(float minNumber, float maxNumber)
        {
            return (float)new Random().NextDouble() * (maxNumber - minNumber) + minNumber;
        }

    }
}
