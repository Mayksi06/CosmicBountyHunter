using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Basic2d
    {
        public float rotation;
        public Vector2 position, dimensions;
        public Texture2D myModel;
        public Basic2d(string path, Vector2 position, Vector2 dimensions)
        {
            this.position = position;
            this.dimensions = dimensions;

            myModel = Globals.content.Load<Texture2D>(path);
        }

        public virtual void Update(Vector2 offset)
        {

        }

        public virtual void Draw(Vector2 offset)
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 offset, Vector2 origin)
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(origin.X, origin.Y), new SpriteEffects(), 0);
            }
        }
    }
}