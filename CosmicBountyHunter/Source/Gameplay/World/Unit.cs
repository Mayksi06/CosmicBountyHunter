using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Unit : Basic2d
    {
        public float speed;
        public Unit(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            speed = 4.0f;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}