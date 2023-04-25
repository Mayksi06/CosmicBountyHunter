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

        public override void Update(Vector2 offset, Player enemy)
        {
            AI(enemy.hero);   //use the mob AI

            base.Update(offset);
        }

        public virtual void AI(Hero hero)
        {
            //make the mob go towards the hero position
            position += Globals.RadialMovement(hero.position, position, speed);
            rotation = Globals.RotateTowards(position, hero.position);

            if (Globals.GetDistance(position, hero.position) < 15) //distance from mob before hero gets hit
            {
                hero.GetHit(1);     //hero gets 1 damage when getting hit
                dead = true;        //the mob dies when it hits the hero
            }
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}