using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Sharpshooter : Mob
    {
        public Sharpshooter(Vector2 position, Vector2 frames, int ownerId)
            : base("2d\\Units\\Mobs\\sharpshooter", position, new Vector2(60, 60), frames, ownerId)        //seeker enemy image and size
        {
            speed = 2.0f;   //seeker enemy movement speed

            attackRange = 400;

            if (MainMenu.hardmode == true)
            {
                speed = 8.0f;
            }
        }

        public override void AI(Hero hero)
        {
            if (hero != null && (Globals.GetDistance(position, hero.position) < attackRange * .9f || isAttacking))
            {
                isAttacking = true;

                attackTimer.UpdateTimer();

                if (attackTimer.Test())
                {
                    GameGlobals.PassProjectile(new Laser(new Vector2(position.X, position.Y), this, new Vector2(hero.position.X, hero.position.Y)));

                    attackTimer.ResetToZero();
                    isAttacking = false;
                }
            }
            else
            {
                base.AI(hero);
            }
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            base.Update(offset, enemy);  //update the seeker enemey
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);  //draw the seeker enemy
        }
    }
}
