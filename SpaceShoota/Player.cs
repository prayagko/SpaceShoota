using System;
using RC_Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShoota
{
    public class Player

    {

        public Sprite3 ship;

        public Vector2 position;

        public Vector2 newSize;



        public Player(Texture2D tex, Vector2 position)
        {
            this.position = position;
            newSize = new Vector2(tex.Width / 8, tex.Height / 8);
            ship = new Sprite3(true, tex, position.X, position.Y);
            ship.setWidthHeight(newSize.X, newSize.Y);
            ship.hitPoints = 3;
            


        }

        public Vector2 getNewSize()
        {
            return newSize;
        }

        public void movePlayer() {
            position += 4*(Input.GetDirection());

            // my game is screen is getting cropped in the y axis for some reason, need to fix
            position = Vector2.Clamp(position, new Vector2(0,0), new Vector2(750,440));
            ship.setPos(position);
        }

        public void playerDeath()
        {
            Game1.levelManager.setLevel(5);
        }

        public void takeDamage(int damage)
        {
            ship.hitPoints = ship.hitPoints - damage;

            if (ship.hitPoints <= 0)
                playerDeath();
        }

        public Sprite3 getSprite()
        {
            return ship;
        }


        public void Update()
        {

            movePlayer();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ship.draw(spriteBatch);
      
            

        }
    }
}
