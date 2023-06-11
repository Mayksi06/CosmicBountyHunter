using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class GamePlay
    {
        int playState;  //state of the game
        World world;
        PassObject changeGameState;

        public GamePlay(PassObject changeGameState)
        {
            playState = 0;

            this.changeGameState = changeGameState;
            ResetWorld(null);
        }

        public User GetUser()
        {
            return world.GetUser(world);
        }

        public virtual void Update()
        {
            if (playState == 0)
            {
                world.Update();
            }
        }

        public virtual void ResetWorld(object info)
        {
            world = new World(ResetWorld, changeGameState);    //create a new world
        }

        public virtual void Draw()
        {
            if (playState == 0)
            {
                world.Draw(Vector2.Zero);   //draw a new world
            }
        }
    }
}
