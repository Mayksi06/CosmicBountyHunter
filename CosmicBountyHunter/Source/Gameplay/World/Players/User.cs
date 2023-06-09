using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class User : Player
    {
        public User(int id) : base(id)
        {
            //hero spawn X and Y position on screen and hero size
            //X = left and right, Y = up and down
            hero = new Hero("2d\\Units\\mainShipSheet", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 100 * 70), new Vector2(100, 100), new Vector2(4, 1), id); //hero image, spawn position and size
        }

        public override void Update(Player enemy, Vector2 offset)
        {
            base.Update(enemy, offset);
        }

        public override void ChangeScore(int score)
        {

        }
    }
}
