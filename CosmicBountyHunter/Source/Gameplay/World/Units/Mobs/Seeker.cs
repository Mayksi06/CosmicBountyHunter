using CosmicHunter.Source.Gameplay.World.Units;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Seeker : Mob
    {
        public Seeker(Vector2 position) : base("2d\\Units\\Mobs\\seeker", position, new Vector2(60, 60))
        {
            speed = 2.0f;
        }

        public override void Update(Vector2 offset, Hero hero)
        {
            base.Update(offset, hero);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}