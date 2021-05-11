using System;
using RC_Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


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


    }
}
