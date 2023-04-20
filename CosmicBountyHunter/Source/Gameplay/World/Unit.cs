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
        public bool dead;   //check if the unit died
        public float speed, hitDistance, health, healthMax;
        public Unit(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            dead = false;
            speed = 4.0f;           //unit movement speed

            health = 0;
            healthMax = health;

            hitDistance = 35.0f;    //hitbox of the unit
        }

        public override void Update(Vector2 offset)
        {
            base.Update(offset);    //update the unit
        }

        public virtual void GetHit(float damage)
        {
            health -= damage;

            if (health < 0)
            {
                dead = true;        //the unit dies if it gets hit
            }
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);      //draw the unit
        }
    }
}