using CosmicHunter.Source.Gameplay.World.Units;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Mob : Unit
    {
        public Mob(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            speed = 1.0f;
        }

        public virtual void Update(Vector2 offset, Hero hero)
        {
            AI(hero);

            base.Update(offset);
        }

        public virtual void AI(Hero hero)
        {
            position += Globals.RadialMovement(hero.position, position, speed);
            rotation = Globals.RotateTowards(position, hero.position);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}