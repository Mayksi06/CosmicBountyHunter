using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Player
    {
        public Hero hero;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        public Player()
        {

        }

        public virtual void Update(Player enemy, Vector2 offset)
        {
            if (hero != null)                               //check if hero is initialized
            {
                hero.Update(offset);
            }

            for (int i = 0; i < spawnPoints.Count; i++)     //create the spawnpoints first
            {
                spawnPoints[i].Update(offset);
            }

            for (int i = 0; i < units.Count; i++)           //remove the mobs if they get killed
            {
                units[i].Update(offset, enemy);

                if (units[i].dead)
                {
                    ChangeRemainingEnemies(1);              //decrement the number of remaining enemies if an enemy gets killed
                    ChangeScore(1);                         //increment the score if an enemy gets killed
                    units.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddUnit(object info)
        {
            units.Add((Unit)info);
        }

        public virtual void ChangeRemainingEnemies(int amount)
        {

        }

        public virtual void ChangeScore(int score)
        {

        }

        public virtual void Draw(Vector2 offset)
        {
            if (hero != null)
            {
                hero.Draw(offset);                          //draw the hero
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Draw(offset);                      //draw the mobs
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(offset);                //draw the spawn points of the mobs
            }
        }
    }
}
