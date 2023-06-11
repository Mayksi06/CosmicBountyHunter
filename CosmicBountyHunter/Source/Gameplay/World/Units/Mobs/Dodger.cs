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
        private int zigZagDirection = 1;

        public Dodger(Vector2 position, Vector2 frames, int ownerId)
            : base("2d\\Units\\Mobs\\dodger", position, new Vector2(60, 60), frames, ownerId)        //seeker enemy image and size
        {
            speed = 1.0f;   //seeker enemy movement speed
            health = 5;

            if (MainMenu.hardmode == true)
            {
                speed = 8.0f;
            }
        }

        public override void AI(Hero hero)
        {
            if (hero != null)
            {
                Vector2 direction = Vector2.Normalize(hero.position - position);

                direction.X += zigZagDirection * 1.5f;

                position += direction * speed;
            }

            base.AI(hero);
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