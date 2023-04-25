using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class AIPlayer : Player
    {
        public AIPlayer() : base()
        {
            //create 3 spawn points for enemies
            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(50, 50), new Vector2(50, 50)));  //add a mob spawn point at the top left of the screen with given size

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(Globals.screenWidth / 2, 50), new Vector2(50, 50))); //add a mob spawn point at the top half of the screen
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);  //give the last spawnpoint on the list and add a delay of spawning of half a second

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\portal", new Vector2(Globals.screenWidth - 50, 50), new Vector2(50, 50))); //add a mob spawn point at the top right of the screen
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000); //same as the previous, but with 1 second delay of spawning
        }

        public override void Update(Player enemy, Vector2 offset)
        {
            base.Update(enemy, offset);
        }

        public override void ChangeRemainingEnemies(int amount)
        {
            GameGlobals.enemiesRemaining -= amount;
        }
        public override void ChangeScore(int score)
        {
            GameGlobals.score += score; //in AIPlayer not in User because you don't want to update the score if the hero dies
        }
    }
}
