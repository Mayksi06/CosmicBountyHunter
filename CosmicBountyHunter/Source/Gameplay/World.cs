using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        public Vector2 offset;
        public UI userInterface;

        public User user;
        public AIPlayer aiPlayer;

        public List<Projectile2d> projectiles = new List<Projectile2d>();

        public PassObject resetWorld;
        public GameGlobals globals;

        public World(PassObject resetWorld)
        {
            this.resetWorld = resetWorld;

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;

            user = new User();
            aiPlayer = new AIPlayer();

            offset = new Vector2(0, 0);

            userInterface = new UI(resetWorld);
            globals = new GameGlobals();
        }

        public virtual void Update()
        {
            if (!user.hero.dead)                                //keep updating the game while the hero is still alive, game will pause when the hero dies
            {
                user.Update(aiPlayer, offset);
                aiPlayer.Update(user, offset);

                for (int i = 0; i < projectiles.Count; i++)     //create the mobs after
                {
                    projectiles[i].Update(offset, aiPlayer.units.ToList<Unit>());

                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }
                
                if (Globals.keyboard.GetPress("Enter") || userInterface.playButton.isPressed == true)      //when the hero wins, check if he pressed Enter
                {
                    globals.ResetCounters();                //set enemies remaining and score back to original amount
                    resetWorld(null);                       //restart the world
                }
            }

            else
            {
                if (Globals.keyboard.GetPress("Enter") || userInterface.resetButton.isPressed == true)     //when the hero died, check if he pressed Enter
                {
                    globals.ResetCounters();                //set enemies remaining and score back to original amount
                    resetWorld(null);                       //restart the world
                }
            }

            userInterface.Update(this);
        }

        public virtual void AddMob(object info)
        {
            aiPlayer.AddUnit((Mob)info);
        }

        public virtual void AddProjectile(object info)
        {
            //anything you pass here will be casted as a projectile and added to the list of projectiles
            projectiles.Add((Projectile2d)info);
        }

        public virtual void Draw(Vector2 offset)
        {
            //whatever is on top draws last
            user.Draw(offset);
            aiPlayer.Draw(offset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);        //draw the projectiles
            }

            userInterface.Draw(this, user.hero);    //draw the user interface
        }
    }
}