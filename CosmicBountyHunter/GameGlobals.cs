using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class GameGlobals
    {
        public static int enemiesRemaining = 45;            //number of enemies remaining
        public static int score = 0;                        //the total score

        public static PassObject PassProjectile, PassMob;   //any object can create a projectile

        public void ResetCounters()
        {
            enemiesRemaining = 45;
            score = 0;
        }
    }
}