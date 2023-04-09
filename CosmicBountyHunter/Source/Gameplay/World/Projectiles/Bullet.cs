using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Bullet : Projectile2d
    {
        public Bullet(Vector2 position, Unit owner, Vector2 target)
            : base("2d\\Projectiles\\bullet", position, new Vector2(20, 20), owner, target)
        {

        }

        public override void Update(Vector2 offset, List<Unit> units)
        {
            base.Update(offset, units);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}