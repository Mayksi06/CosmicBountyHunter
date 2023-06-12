using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    //draw 2d objects
    public class Basic2d : IUpdatableBasic
    {
        public float rotation;
        public Vector2 position, dimensions, frameSize;    //X and Y coordinates
        public Texture2D myModel;
        public Basic2d(string path, Vector2 position, Vector2 dimensions)
        {
            this.position = new Vector2(position.X, position.Y);
            this.dimensions = new Vector2(dimensions.X, dimensions.Y);
            rotation = 0.0f;

            myModel = Globals.content.Load<Texture2D>(path);
        }

        public virtual void Update(Vector2 offset)
        {

        }

        public virtual bool Hover(Vector2 offset)       //check if you are hovering
        {
            return HoverImg(offset);
        }

        public virtual bool HoverImg(Vector2 offset)    //check if you are hovering over an image
        {
            Vector2 mousePosition = new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y);

            //greater than the top side or less than the bottom side
            if (mousePosition.X >= (position.X + offset.X) - dimensions.X / 2 && mousePosition.X <= (position.X + offset.X) + dimensions.X / 2 && mousePosition.Y >= (position.Y + offset.Y) - dimensions.Y / 2 && mousePosition.Y <= (position.Y + offset.Y) + dimensions.Y / 2)
            {
                return true;
            }

            return false;
        }

        public virtual void Draw(Vector2 offset)
        {
            if (myModel != null)
            {
                //position is the center of the image
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 offset, Color color)   //add shades of color
        {
            if (myModel != null)
            {
                //position is the center of the image
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X, (int)dimensions.Y), null, color, rotation, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 offset, Vector2 origin, Color color)
        {
            //make sure mymodel is set
            if (myModel != null)
            {
                //creates a rectangle of the size of the 2d object, position is given position of image
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X, (int)dimensions.Y), null, color, rotation, new Vector2(origin.X, origin.Y), new SpriteEffects(), 0);
            }
        }
    }
}