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
        int i = 0;
        public bool dead;
        public float hitDistance;
        public MdTimer spawnTimer = new MdTimer(3000);  //enemy spawning speed
        public int ownerId;
        public SpawnPoint(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            dead = false;
            hitDistance = 35.0f;
        }

        public override void Update(Vector2 offset)
        {
            spawnTimer.UpdateTimer();

            if (spawnTimer.Test() && i < 5) //5 waves of enemies, 3 enemies per wave
            //if (spawnTimer.Test())        //unlimited waves of enemies
            {
                i++;
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
            //spawn the mob from the spawnpoint position
            //GameGlobals.PassMob(new Seeker(new Vector2(position.X, position.Y), new Vector2(1, 1), ownerId));
            //GameGlobals.PassMob(new Sharpshooter(new Vector2(position.X, position.Y), new Vector2(1, 1), ownerId));
            GameGlobals.PassMob(new Dodger(new Vector2(position.X, position.Y), new Vector2(1, 1), ownerId));
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);  //draw the spawn point
        }
    }
}