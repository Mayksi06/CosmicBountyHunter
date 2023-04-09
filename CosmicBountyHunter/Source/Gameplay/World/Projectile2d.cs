using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Projectile2d : Basic2d
    {
        public bool done;
        public float speed;
        public Vector2 direction;
        public Unit owner;
        public MdTimer timer;

        public Projectile2d(string path, Vector2 position, Vector2 dimensions, Unit owner, Vector2 target) : base(path, position, dimensions)
        {
            done = false;

            speed = 8.0f;

            this.owner = owner;

            direction = target - owner.position;
            direction.Normalize();

            rotation = Globals.RotateTowards(position, new Vector2(target.X, target.Y));

            timer = new MdTimer(5000);
        }

        public virtual void Update(Vector2 offset, List<Unit> units)
        {
            position += direction * speed;

            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }

            if (HitSomething(units))
            {
                done = true;
            }
        }

        public virtual bool HitSomething(List<Unit> units)
        {
            return false;
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}