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
        public Seeker(Vector2 position, Vector2 frames, int ownerId) 
            : base("2d\\Units\\Mobs\\seeker", position, new Vector2(60, 60), frames, ownerId)        //seeker enemy image and size
        {
            speed = 2.0f;   //seeker enemy movement speed
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            base.Update(offset, enemy);  //update the seeker enemey
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);  //draw the seeker enemy
        }
    }
}