using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class World
    {
        public Hero hero;
        public World()
        {
            hero = new Hero("2d\\ship", new Vector2(300, 300), new Vector2(100, 100));
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw(Vector2 offset)
        {
            hero.Draw(offset);
        }
    }
}