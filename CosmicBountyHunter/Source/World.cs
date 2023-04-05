using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicBountyHunter
{
    public class World
    {
        public Basic2d ship;
        public World()
        {
            ship = new Basic2d("2d\\ship", new Vector2(300, 300), new Vector2(100, 100));
        }

        public virtual void Update()
        {
            ship.Update();
        }

        public virtual void Draw()
        {
            ship.Draw();
        }
    }
}
