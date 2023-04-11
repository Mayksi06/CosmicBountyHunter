using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class SpawnPoint : Basic2d
    {
        public bool dead;
        public float hitDistance;
        public MdTimer spawnTimer = new MdTimer(3000);
        public SpawnPoint(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            dead = false;
            hitDistance = 35.0f;
        }

        public override void Update(Vector2 offset)
        {
            spawnTimer.UpdateTimer();

            if (spawnTimer.Test())
            {
                SpawnMob();
                spawnTimer.ResetToZero();
            }

            base.Update(offset);
        }

        public virtual void GetHit()
        {
            dead = true;
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new Seeker(new Vector2(position.X, position.Y)));
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}