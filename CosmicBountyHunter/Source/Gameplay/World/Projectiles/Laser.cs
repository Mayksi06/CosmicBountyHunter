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
    public class Laser : Projectile2d
    {
        public Laser(Vector2 position, Unit owner, Vector2 target)
            : base("2d\\Projectiles\\bullet", position, new Vector2(20, 20), owner, target)     //image and size of the bullet
        {
            speed = 4.0f;

            timer = new MdTimer(1800);
        }

        public override void Update(Vector2 offset, List<Unit> units)
        {
            base.Update(offset, units); //update the bullet
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);  //draw the bullet
        }
    }
}
