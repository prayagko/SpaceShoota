using System;
using RC_Framework;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework.Input;


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


        public void drawBB(Sprite3 entity, SpriteBatch spriteBatch)
        {
            entity.drawBB(spriteBatch, Color.Crimson);

        }



// lol this is weird
        public static EnemyShip enemyShip;
        public static List<EnemyShip> makeEnemyShipList(int num) {

            List<EnemyShip> enemyGunShipList = new List<EnemyShip>();

            for (int i = 0; i < num; i++)
            {
                enemyShip = new EnemyShip(Assets.texEnemyGunship, new Vector2(800 + i*Utility.randInt(0, 400), Utility.randInt(30, 430)), 1);
                enemyGunShipList.Add(enemyShip);
            }
            return enemyGunShipList;
        }





    }
}
