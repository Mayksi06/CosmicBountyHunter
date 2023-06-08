using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;

namespace CosmicHunter
{
    public class Animated2d : Basic2d
    {
        public Vector2 frames;              //each of the spritesheet frames
        public List<FrameAnimation> frameAnimationList = new List<FrameAnimation>();    //list of the animations
        public Color color;
        public bool frameAnimations;        //check if frame animations are being used
        public int currentAnimation = 0;

        public Animated2d(string path, Vector2 position, Vector2 dimensions, Vector2 frames, Color color) : base(path, position, dimensions)
        {
            Frames = new Vector2(frames.X, frames.Y);

            this.color = color;
        }

        public Vector2 Frames
        {
            set
            {
                frames = value;
                if (myModel != null)
                {
                    //get the size of the frame
                    //frameSize = new Vector2(myModel.Bounds.Width / frames.X, myModel.Bounds.Height / frames.Y);
                }
            }
            get
            {
                return frames;
            }
        }

        public override void Update(Vector2 OFFSET)
        {
            if (frameAnimations && frameAnimationList != null && frameAnimationList.Count > currentAnimation)   //error check
            {
                frameAnimationList[currentAnimation].Update();  //update the animation
            }

            base.Update(OFFSET);    //potentially for tooltips and zoom, etc...
        }

        public virtual int GetAnimationFromName(string ANIMATIONNAME)
        {
            for (int i = 0; i < frameAnimationList.Count; i++)
            {
                if (frameAnimationList[i].name == ANIMATIONNAME)
                {
                    return i;
                }
            }

            return -1;      //same as null
        }

        public virtual void SetAnimationByName(string NAME)
        {
            int tempAnimation = GetAnimationFromName(NAME);

            if (tempAnimation != -1)
            {
                if (tempAnimation != currentAnimation)              //see if it's the same animation we currently have
                {
                    frameAnimationList[tempAnimation].Reset();      //if it's not we reset the animation
                }

                currentAnimation = tempAnimation;
            }
        }

        public override void Draw(Vector2 screenShift)
        {
            if (frameAnimations && frameAnimationList[currentAnimation].Frames > 0)
            {
                //Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X+screenShift.X), (int)(pos.Y+screenShift.Y), (int)dims.X, (int)dims.Y), new Rectangle((int)((currentFrame.X-1)*dims.X), (int)((currentFrame.Y-1)*dims.Y), (int)(currentFrame.X*dims.X), (int)(currentFrame.Y*dims.Y)), color, rot, new Vector2(myModel.Bounds.Width/2, myModel.Bounds.Height/2), new SpriteEffects(), 0);
                //frameAnimationList[currentAnimation].Draw(myModel, dimensions, frameSize, screenShift, position, rotation, color, new SpriteEffects());
            }
            else
            {
                base.Draw(screenShift);
            }
        }
    }
}