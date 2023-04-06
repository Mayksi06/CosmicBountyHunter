using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Hero : Basic2d
    {
        public Hero(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {

        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                position = new Vector2(position.X - 2, position.Y);
            }

            if (Globals.keyboard.GetPress("D"))
            {
                position = new Vector2(position.X + 2, position.Y);
            }

            if (Globals.keyboard.GetPress("W"))
            {
                position = new Vector2(position.X, position.Y - 2);
            }

            if (Globals.keyboard.GetPress("S"))
            {
                position = new Vector2(position.X, position.Y + 2);
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
