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
        public int enemiesRemaining;    //number of enemies remaining
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
            hero = new Hero("2d\\ship", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 100 * 70), new Vector2(100, 100)); //hero image, spawn position and size

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;

            offset = new Vector2(0, 0);

            //create 3 spawn points for enemies
            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(50, 50), new Vector2(50, 50)));  //add a mob spawn point at the top left of the screen with given size

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(Globals.screenWidth / 2, 50), new Vector2(50, 50))); //add a mob spawn point at the top half of the screen
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);  //give the last spawnpoint on the list and add a delay of spawning of half a second

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(Globals.screenWidth - 50, 50), new Vector2(50, 50))); //add a mob spawn point at the top right of the screen
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000); //same as the previous, but with 1 second delay of spawning

            userInterface = new UI();
        }

        public virtual void Update()
        {
            hero.Update(offset);

            for (int i = 0; i < spawnPoints.Count; i++)     //create the spawnpoints first
            {
                spawnPoints[i].Update(offset);
            }

            for (int i = 0; i < projectiles.Count; i++)     //create the mobs after
            {
                projectiles[i].Update(offset, mobs.ToList<Unit>());

                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < mobs.Count; i++)            //remove the mobs if they get killed
            {
                mobs[i].Update(offset, hero);

                if (mobs[i].dead)
                {
                    enemiesRemaining--;     //decrement the number of remaining enemies if an enemy gets killed
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
            //anything you pass here will be casted as a projectile and added to the list of projectiles
            projectiles.Add((Projectile2d)info);
        }

        public virtual void Draw(Vector2 offset)
        {
            hero.Draw(offset);  //draw the hero

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);    //draw the projectiles
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(offset);    //draw the spawn points of the mobs
            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(offset);   //draw the mobs
            }

            userInterface.Draw(this);   //draw the user interface
        }
    }
}