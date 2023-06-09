using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Unit : AttackableObject
    {
        public Unit(string path, Vector2 position, Vector2 dimensions, Vector2 frames, int ownerId) 
            : base(path, position, dimensions, frames, ownerId)
        {
            speed = 4.0f;           //unit movement speed
            health = 0;
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            base.Update(offset);    //update the unit
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);      //draw the unit
        }
    }
}