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
        public static bool collisionDetected;
        public static void PreventCollision(AttackableObject object1, Asteroid asteroid)
        {
            if (object1.Bounds.Intersects(asteroid.Bounds))
            {
                // Resolve collision between the object and asteroid
                // Adjust the object's position or handle the collision accordingly
                // Example: Stop the object's movement
                Vector2 separationVector = GetSeparationVector(object1.Bounds, asteroid.Bounds);
                object1.position += separationVector;
                object1.Velocity = Vector2.Zero;
                collisionDetected = true;
            }
            else
            {
                collisionDetected = false;
            }
        }

        private static Vector2 GetSeparationVector(Rectangle rect1, Rectangle rect2)
        {
            // Calculate the separation vector to move rect1 outside of rect2
            Vector2 separationVector = Vector2.Zero;

            if (rect1.Right > rect2.Left && rect1.Left < rect2.Right)
            {
                if (rect1.Bottom > rect2.Top && rect1.Top < rect2.Bottom)
                {
                    // Rectangles intersect, calculate separation vector
                    float horizontalSeparation = 0;
                    float verticalSeparation = 0;

                    if (rect1.Center.X < rect2.Center.X)
                    {
                        horizontalSeparation = rect2.Left - rect1.Right;
                    }
                    else
                    {
                        horizontalSeparation = rect2.Right - rect1.Left;
                    }

                    if (rect1.Center.Y < rect2.Center.Y)
                    {
                        verticalSeparation = rect2.Top - rect1.Bottom;
                    }
                    else
                    {
                        verticalSeparation = rect2.Bottom - rect1.Top;
                    }

                    if (Math.Abs(horizontalSeparation) < Math.Abs(verticalSeparation))
                    {
                        separationVector.X = horizontalSeparation;
                    }
                    else
                    {
                        separationVector.Y = verticalSeparation;
                    }
                }
            }

            return separationVector;
        }
    }
}