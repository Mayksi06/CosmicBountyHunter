﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Unit : Basic2d
    {
        public bool dead;
        public float speed, hitDistance;
        public Unit(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            dead = false;
            speed = 4.0f;
            hitDistance = 35.0f;
        }

        public override void Update(Vector2 offset)
        {
            base.Update(offset);
        }

        public virtual void GetHit()
        {
            dead = true;
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}