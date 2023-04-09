using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter.Source.Gameplay.World.Units
{
    public class Hero : Unit
    {
        public float speed;
        public Hero(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            speed = 4.0f;
        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                position = new Vector2(position.X - speed, position.Y);
            }

            if (Globals.keyboard.GetPress("D"))
            {
                position = new Vector2(position.X + speed, position.Y);
            }

            if (Globals.keyboard.GetPress("W"))
            {
                position = new Vector2(position.X, position.Y - speed);
            }

            if (Globals.keyboard.GetPress("S"))
            {
                position = new Vector2(position.X, position.Y + speed);
            }

            rotation = Globals.RotateTowards(position, new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y));

            if (Globals.mouse.LeftClick())
            {
                GameGlobals.PassProjectile(new Bullet(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y)));
            }

            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
