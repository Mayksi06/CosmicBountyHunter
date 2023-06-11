using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace CosmicHunter
{
    public static class CollisionManager
    {
        public static bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Intersects(rect2);
        }

        public static void PreventCollision(AttackableObject object1, Asteroid asteroid)
        {
            if (object1.Bounds.Intersects(asteroid.Bounds))
            {
                // Resolve collision between the object and asteroid
                // Adjust the object's position or handle the collision accordingly
                // Example: Stop the object's movement
                object1.Velocity = Vector2.Zero;
            }
        }
    }
}