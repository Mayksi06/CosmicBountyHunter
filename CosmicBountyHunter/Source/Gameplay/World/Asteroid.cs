using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace CosmicHunter
{
    public class Asteroid
    {
        private Texture2D texture;
        private Rectangle bounds;

        public Asteroid(Texture2D texture, Vector2 position, int size)
        {
            this.texture = texture;
            bounds = new Rectangle((int)position.X, (int)position.Y, size, size);
        }

        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}