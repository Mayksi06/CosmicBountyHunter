using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class DisplayBar : IUpdatableDisplay
    {
        public int border;
        public Basic2d bar, barBKG;
        public Color color;
        
        public DisplayBar(Vector2 dimensions, int border, Color color)
        {
            this.border = border;
            this.color = color;

            bar = new Basic2d("2d\\Misc\\solid", new Vector2(0, 0), new Vector2(dimensions.X - border * 2, dimensions.Y - border * 2)); //have the solid border on each side
            barBKG = new Basic2d("2d\\Misc\\shade", new Vector2(0, 0), new Vector2(dimensions.X, dimensions.Y));    //have the shaded border on each side
        }

        public virtual void Update(float current, float max)
        {
            bar.dimensions = new Vector2(current / max * (barBKG.dimensions.X - border * 2), bar.dimensions.Y); //change only the vertical bar
        }

        public virtual void Draw(Vector2 offset)
        {
            barBKG.Draw(offset, new Vector2(0, 0), Color.Black);
            bar.Draw(offset + new Vector2(border, border), new Vector2(0, 0), color);
        }
    }
}
