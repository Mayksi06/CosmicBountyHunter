using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Hero : Unit
    {
        public float speed;
        public Hero(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            speed = 4.0f;   //change the hero movement speed

            health = 5;
            healthMax = health;
        }

        public override void Update(Vector2 offset)
        {
            // if the key A is pressed -> move the hero to the left
            if (Globals.keyboard.GetPress("A") || Globals.keyboard.GetPress("Q") || Globals.keyboard.GetPress("Left"))
            {
                position = new Vector2(position.X - speed, position.Y);
            }

            if (Globals.keyboard.GetPress("D") || Globals.keyboard.GetPress("Right"))
            {
                position = new Vector2(position.X + speed, position.Y);
            }

            if (Globals.keyboard.GetPress("W") || Globals.keyboard.GetPress("Z") || Globals.keyboard.GetPress("Up"))
            {
                position = new Vector2(position.X, position.Y - speed);
            }

            if (Globals.keyboard.GetPress("S") || Globals.keyboard.GetPress("Down"))
            {
                position = new Vector2(position.X, position.Y + speed);
            }

            //rotate the top of the hero towards the mouse cursor position
            rotation = Globals.RotateTowards(position, new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y));

            if (Globals.mouse.LeftClick())
            {
                //hero will shoot a bullet by left clicking the mouse
                GameGlobals.PassProjectile(new Bullet(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y)));
            }

            base.Update(offset);
        }

        public override void Draw(Vector2 offset)
        {
            //draw the hero
            base.Draw(offset);
        }
    }
}
