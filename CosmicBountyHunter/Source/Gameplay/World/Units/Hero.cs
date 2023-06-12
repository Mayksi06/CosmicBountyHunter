using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Hero : Unit
    {
        private SoundEffectInstance shootingSoundInstance;

        public Hero(string path, Vector2 position, Vector2 dimensions, Vector2 frames, int ownerId)
            : base(path, position, dimensions, frames, ownerId)
        {
            speed = 4.0f;           //change the hero movement speed
            health = 4;             //the health points of the hero
            healthMax = health;
            frameAnimations = true;
            currentAnimation = 0;
            //frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(1, 0), 3, 133, 0, "Boost"));
            frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(1, 0), 3, 133, 0, "Fly"));     //(1,0), 3
            frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 1, 133, 0, "Stand"));   //(0,0), 1
            //initialize a function for the animations
            shootingSoundInstance = Globals.content.Load<SoundEffect>("Audio\\laser").CreateInstance();

        }

        public override void Update(Vector2 offset)
        {
            bool move = false;      //check if the hero is moving

            // if the key A/Q/Left is pressed -> move the hero to the left
            if (Globals.keyboard.GetPress("A") || Globals.keyboard.GetPress("Q") || Globals.keyboard.GetPress("Left"))
            {
                position = new Vector2(position.X - speed, position.Y);
                move = true;    //the hero is moving
            }

            if (Globals.keyboard.GetPress("D") || Globals.keyboard.GetPress("Right"))
            {
                position = new Vector2(position.X + speed, position.Y);
                move = true;
            }

            if (Globals.keyboard.GetPress("W") || Globals.keyboard.GetPress("Z") || Globals.keyboard.GetPress("Up"))
            {
                position = new Vector2(position.X, position.Y - speed);
                move = true;
            }

            if (Globals.keyboard.GetPress("S") || Globals.keyboard.GetPress("Down"))
            {
                position = new Vector2(position.X, position.Y + speed);
                move = true;
            }

            if (Globals.keyboard.GetPress("V"))     //if V gets pressed the hero will get a movement speed boost
            {
                speed = 8.0f;
            }

            if (!Globals.keyboard.GetPress("V"))    //if V doesn't get pressed the hero will have the default movement speed
            {
                speed = 4.0f;
            }

            if (move == true)
            {
                SetAnimationByName("Fly");          //if the hero is moving use the Fly animation
            }
            else
            {
                SetAnimationByName("Stand");        //if the hero is not moving use the Stand animation
            }

            //rotate the top of the hero towards the mouse cursor position
            rotation = Globals.RotateTowards(position, new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y));

            if (Globals.mouse.LeftClick())
            {
                //hero will shoot a bullet by left clicking the mouse
                shootingSoundInstance = Globals.content.Load<SoundEffect>("Audio\\laser").CreateInstance();
                shootingSoundInstance.Play();
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