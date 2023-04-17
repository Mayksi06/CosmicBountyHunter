using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    //active game logic
    public class World
    {
        public int enemiesRemaining;
        public Vector2 offset;
        public Hero hero;
        public UI userInterface;

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public List<Mob> mobs = new List<Mob>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        public World()
        {
            enemiesRemaining = 15;
            //hero spawn X and Y position on screen and hero size
            //X = left and right, Y = up and down
            hero = new Hero("2d\\ship", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 100 * 70), new Vector2(100, 100));

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;

            offset = new Vector2(0, 0);

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(50, 50), new Vector2(50, 50)));

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(Globals.screenWidth / 2, 50), new Vector2(50, 50)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(Globals.screenWidth - 50, 50), new Vector2(50, 50)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);

            userInterface = new UI();
        }

        public virtual void Update()
        {
            hero.Update(offset);

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(offset);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, mobs.ToList<Unit>());

                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Update(offset, hero);

                if (mobs[i].dead)
                {
                    enemiesRemaining--;
                    mobs.RemoveAt(i);
                    i--;
                }
            }

            userInterface.Update(this);
        }

        public virtual void AddMob(object info)
        {
            mobs.Add((Mob)info);
        }

        public virtual void AddProjectile(object info)
        {
            projectiles.Add((Projectile2d)info);
        }

        public virtual void Draw(Vector2 offset)
        {
            hero.Draw(offset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(offset);
            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(offset);
            }

            userInterface.Draw(this);
        }
    }
}