using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class AttackableObject : Animated2d
    {
        public bool dead;           //check if the unit died
        public int ownerId;         //id of the owner of the object
        public float speed, hitDistance, health, healthMax;
        public AttackableObject(string path, Vector2 position, Vector2 dimensions, Vector2 frames, int ownerId) 
            : base(path, position, dimensions, frames, Color.White)
        {
            this.ownerId = ownerId;
            dead = false;
            speed = 2.0f;           //unit movement speed

            health = 1;
            healthMax = health;

            hitDistance = 35.0f;    //hitbox of the unit
        }

        public virtual void GetHit(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                dead = true;        //the unit dies if it gets hit
            }
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y);
            }
        }

        public Vector2 Velocity
        {
            get;
            set;
        }

        public virtual void Update(Vector2 offset, Player enemy)
        {
            position += Velocity * speed;
            base.Update(offset);    //update the unit
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);      //draw the unit
        }
    }
}