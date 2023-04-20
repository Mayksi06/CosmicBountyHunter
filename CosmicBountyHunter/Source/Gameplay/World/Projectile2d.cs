using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Projectile2d : Basic2d
    {
        public bool done;           //projectile disappears
        public float speed;         //projectile speed
        public Vector2 direction;   //projectile direction
        public Unit owner;          //projectile needs an owner so it can't hit itself
        public MdTimer timer;       //how long the projectile exists

        public Projectile2d(string path, Vector2 position, Vector2 dimensions, Unit owner, Vector2 target) : base(path, position, dimensions)
        {
            done = false;

            speed = 8.0f;

            this.owner = owner;

            direction = target - owner.position;
            direction.Normalize();

            rotation = Globals.RotateTowards(position, new Vector2(target.X, target.Y));    //rotate the top of the projectile towards the shooting direction

            timer = new MdTimer(5000);  //the projectile will exist for 5 seconds
        }

        public virtual void Update(Vector2 offset, List<Unit> units)
        {
            position += direction * speed;  //movement of the projectile

            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;    //make the projectile disappear if the timer of the projectile runs out
            }

            if (HitSomething(units))
            {
                done = true;    //make the projectile disappear if it hits a unit
            }
        }

        public virtual bool HitSomething(List<Unit> units)
        {
            //collision test if a unit got hit by a projectile
            for (int i = 0; i < units.Count; i++)
            {
                if (Globals.GetDistance(position, units[i].position) < units[i].hitDistance)
                {
                    units[i].GetHit(1);
                    return true;
                }
            }

            return false;
        }

        public override void Draw(Vector2 offset)
        {
            //draw the projectile
            base.Draw(offset);
        }
    }
}