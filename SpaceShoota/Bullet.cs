using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RC_Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceShoota
{
    class Bullet
    {

        public Sprite3 bullet;
        public Texture2D texture;
        public Vector2 position;
        public int delta;
        public bool active;


        public Bullet(Texture2D texture, Vector2 position, int delta)
        {
            this.texture = texture;
            this.position = position;
            this.delta = delta;
            bullet = new Sprite3(true, texture, position.X, position.Y);

        }

        public Sprite3 getSprite()
        {
            return bullet;
        }

        public void Update()
        {
            bullet.setPosX(bullet.getPosX() + delta);

        }

        public void makeInactive()
        {
            active = false;
        }

        public void Draw(SpriteBatch spriteBatch)

        {
            bullet.Draw(spriteBatch);
        }
    }
}
