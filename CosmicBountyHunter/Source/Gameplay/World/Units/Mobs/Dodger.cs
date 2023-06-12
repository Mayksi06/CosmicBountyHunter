using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Dodger : Mob
    {
        private bool isMoving = true;
        private float zigzagDistance = 50f;
        private float zigzagSpeed = 4f;
        private bool isMovingRight = true;
        private MdTimer zigzagTimer = new MdTimer(1000); // Zigzag direction change timer
        private Vector2 heroPosition;

        public Dodger(Vector2 position, Vector2 frames, int ownerId)
            : base("2d\\Units\\Mobs\\dodger", position, new Vector2(60, 60), frames, ownerId)
        {
            speed = 1.0f;
            attackRange = 10;
            health = 5.0f;

            if (MainMenu.hardmode)
            {
                speed = 6.0f;
            }
        }

        public override void AI(Hero hero)
        {
            if (hero != null && (Globals.GetDistance(position, hero.position) < attackRange * .9f || isAttacking))
            {
                if (!isMoving)
                {
                    isAttacking = true;
                    attackTimer.UpdateTimer();

                    if (attackTimer.Test())
                    {
                        // Perform the attack action
                        // ...

                        attackTimer.ResetToZero();
                        isAttacking = false;
                    }
                }
            }
            else
            {
                isMoving = true;

                // Store the hero's position
                heroPosition = hero.position;

                // Perform the zigzag movement
                ZigZagMovement();

                base.AI(hero);
            }
        }

        private void ZigZagMovement()
        {
            zigzagTimer.UpdateTimer();

            if (zigzagTimer.Test())
            {
                isMovingRight = !isMovingRight; // Change zigzag direction
                zigzagTimer.Reset();
            }

            if (isMovingRight)
            {
                position.X += zigzagSpeed;

                if (position.X >= heroPosition.X + zigzagDistance)
                {
                    position.X = heroPosition.X + zigzagDistance;
                }
            }
            else
            {
                position.X -= zigzagSpeed;

                if (position.X <= heroPosition.X - zigzagDistance)
                {
                    position.X = heroPosition.X - zigzagDistance;
                }
            }
        }

        public override void Update(Vector2 offset, Player enemy)
        {
            base.Update(offset, enemy);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}