using System;
using RC_Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShoota
{
    public class EnemyShip

    {
        public Sprite3 ship;
        public Vector2 position;
        public Vector2 texSize;
        public float speed;
        public Vector2 newSize;
        public int type;
        public bool dead = false;

        private int shootDelay = 0;
        private int shootTick = 0;
        public bool canShoot = true;


        public EnemyShip(Texture2D tex, Vector2 position, float speed)
        {
            this.speed = speed;
            this.position = position;
            newSize = new Vector2(tex.Width/4, tex.Height/4);

            ship = new Sprite3(true, tex, position.X, position.Y);
            ship.setWidthHeight(newSize.X, newSize.Y);

            ship.hitPoints = 1;
        }



        public Vector2 getNewSize()
        {
            return newSize;
        }


        public void takeDamage(int damage)
        {
            ship.hitPoints = ship.hitPoints - damage;

            if (ship.hitPoints <= 0)
                dead = true;
                
        }

        
        public Sprite3 getSprite()
        {
            return ship;
        }

        public bool isDead()
        {
            return dead;
        }

        public void resetCanShoot()
        {
            canShoot = false;
            shootTick = 0;
            shootDelay = 200;
    }



        public void Update()
        {
            if (dead == true)
            {
                ship.setPos(new Vector2(Utility.randInt(800, 1100), Utility.randInt(30, 430)));
                dead = false;
            }

            if (!canShoot)
            {
                if (shootTick < shootDelay)
                {
                    shootTick++;
                }
                else
                {
                    canShoot = true;
                }
            }

            ship.setPosX(ship.getPosX() + speed * -3);

            
            if (ship.getPos().X + ship.getWidth() / 2 < 0 || ship.getPos().Y > 550)
                dead = true;




        }



        public void Draw(SpriteBatch spriteBatch)
        {
            ship.draw(spriteBatch);
        }
    }
}
