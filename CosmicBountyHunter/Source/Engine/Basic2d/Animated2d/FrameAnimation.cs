using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace CosmicHunter
{
    public class FrameAnimation : IUpdatable
    {
        public bool hasFired;                                                       //for using a function during an animation
        public int totalFrames, currentFrame, maxPasses, currentPass, fireFrame;    //number of frames in the animation, maxPasses = iterate animation
        public string name;                                                         //name of the animation
        public Vector2 sheetDimensions, startFrame, sheetFrame, spriteDimensions;   //size of the sheet
        public MdTimer frameTimer;                                                  //for how long a frame should show up
        public PassObject fireAction;                                               //the function you want to use during an animation

        public FrameAnimation(Vector2 spriteDimensions, Vector2 sheetDimensions, Vector2 startFrame, int totalFrames, int timePerFrame, int maxPasses, string name = "")
        {
            this.spriteDimensions = spriteDimensions;
            this.sheetDimensions = sheetDimensions;
            this.startFrame = startFrame;
            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
            this.totalFrames = totalFrames;
            currentFrame = 0;
            frameTimer = new MdTimer(timePerFrame);
            this.maxPasses = maxPasses;
            currentPass = 0;
            this.name = name;
            fireAction = null;
            hasFired = false;
            fireFrame = 0;
        }

        //same as the constructor above but with FireAction
        public FrameAnimation(Vector2 spriteDimensions, Vector2 sheetDimensions, Vector2 startFrame, int totalFrames, int timePerFrame, int maxPasses, int fireFrame, PassObject fireAction, string name = "")
        {
            this.spriteDimensions = spriteDimensions;
            this.sheetDimensions = sheetDimensions;
            this.startFrame = startFrame;
            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
            this.totalFrames = totalFrames;
            currentFrame = 0;
            frameTimer = new MdTimer(timePerFrame);
            this.maxPasses = maxPasses;
            currentPass = 0;
            this.name = name;
            this.fireAction = fireAction;
            hasFired = false;
            this.fireFrame = fireFrame;
        }

        public int Frames
        {
            get 
            { 
                return totalFrames; 
            }
        }

        public int CurrentFrame
        {
            get 
            { 
                return currentFrame; 
            }
        }

        public int CurrentPass
        {
            get
            {
                return currentPass;
            }
        }

        public int MaxPasses
        {
            get
            {
                return maxPasses;
            }
        }

        public void Update()
        {
            //backup this function in case you mess up
            if (totalFrames > 1)
            {
                frameTimer.UpdateTimer();
                if (frameTimer.Test() && (maxPasses == 0 || maxPasses > currentPass))
                {
                    currentFrame++;
                    if (currentFrame >= totalFrames)
                    {
                        currentPass++;      //we completed an animation so we add a pass
                    }
                    if (maxPasses == 0 || maxPasses > currentPass)
                    {
                        sheetFrame.X += 1;

                        //count the frames as a list start from 0, 1, 2, 3, (4 doesn't exist?) -> start again from 0
                        if (sheetFrame.X >= sheetDimensions.X)
                        {
                            sheetFrame.X = 0;
                            sheetFrame.Y += 1;
                        }
                        if (currentFrame >= totalFrames)
                        {
                            currentFrame = 0;
                            hasFired = false;
                            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
                        }
                    }
                    frameTimer.Reset();
                }
            }

            if (fireAction != null && fireFrame == currentFrame && !hasFired)   //fire of the timer
            {
                fireAction(null);
                hasFired = true;
            }
        }

        public void Reset()
        {
            currentFrame = 0;
            currentPass = 0;
            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
            hasFired = false;
        }

        public bool IsAtEnd()
        {
            //check if the animation is at the end of the frames
            if (currentFrame + 1 >= totalFrames)
            {
                return true;
            }
            return false;
        }

        public void Draw(Texture2D myModel, Vector2 dims, Vector2 imageDims, Vector2 screenShift, Vector2 pos, float ROT, Color color, SpriteEffects spriteEffect)
        {
            //make sure that we are using the spritesheet information properly
            Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + screenShift.X), (int)(pos.Y + screenShift.Y), (int)Math.Ceiling(dims.X), (int)Math.Ceiling(dims.Y)), new Rectangle((int)(sheetFrame.X * imageDims.X), (int)(sheetFrame.Y * imageDims.Y), (int)imageDims.X, (int)imageDims.Y), color, ROT, imageDims / 2, spriteEffect, 0);
        }
    }
}