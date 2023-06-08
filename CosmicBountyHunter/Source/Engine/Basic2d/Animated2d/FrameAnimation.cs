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
    public class FrameAnimation
    {
        public bool hasFired;                                                   //for using a function during an animation
        public int frames, currentFrame, maxPasses, currentPass, fireFrame;     //number of frames in the animation, maxPasses = iterate animation
        public string name;
        public Vector2 sheet, startFrame, sheetFrame, spriteDims;               //size of the sheet
        public MdTimer frameTimer;                                              //for how long a frame should show up
        public PassObject FireAction;                                           //the function you want to use during an animation

        public FrameAnimation(Vector2 SpriteDims, Vector2 sheetDims, Vector2 start, int totalframes, int timePerFrame, int MAXPASSES, string NAME = "")
        {
            spriteDims = SpriteDims;
            sheet = sheetDims;
            startFrame = start;
            sheetFrame = new Vector2(start.X, start.Y);
            frames = totalframes;
            currentFrame = 0;
            frameTimer = new MdTimer(timePerFrame);
            maxPasses = MAXPASSES;
            currentPass = 0;
            name = NAME;
            FireAction = null;
            hasFired = false;
            fireFrame = 0;
        }

        //same as the constructor above but with FireAction
        public FrameAnimation(Vector2 SpriteDims, Vector2 sheetDims, Vector2 start, int totalframes, int timePerFrame, int MAXPASSES, int FIREFRAME, PassObject FIREACTION, string NAME = "")
        {
            spriteDims = SpriteDims;
            sheet = sheetDims;
            startFrame = start;
            sheetFrame = new Vector2(start.X, start.Y);
            frames = totalframes;
            currentFrame = 0;
            frameTimer = new MdTimer(timePerFrame);
            maxPasses = MAXPASSES;
            currentPass = 0;
            name = NAME;
            FireAction = FIREACTION;
            hasFired = false;
            fireFrame = FIREFRAME;
        }

        public int Frames
        {
            get 
            { 
                return frames; 
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
            if (frames > 1)
            {
                frameTimer.UpdateTimer();
                if (frameTimer.Test() && (maxPasses == 0 || maxPasses > currentPass))
                {
                    currentFrame++;
                    if (currentFrame >= frames)
                    {
                        currentPass++;      //we completed an animation so we add a pass
                    }
                    if (maxPasses == 0 || maxPasses > currentPass)
                    {
                        sheetFrame.X += 1;

                        //count the frames as a list start from 0, 1, 2, 3, (4 doesn't exist?) -> start again from 0
                        if (sheetFrame.X >= sheet.X)
                        {
                            sheetFrame.X = 0;
                            sheetFrame.Y += 1;
                        }
                        if (currentFrame >= frames)
                        {
                            currentFrame = 0;
                            hasFired = false;
                            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
                        }
                    }
                    frameTimer.Reset();
                }
            }

            if (FireAction != null && fireFrame == currentFrame && !hasFired)   //fire of the timer
            {
                FireAction(null);
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
            if (currentFrame + 1 >= frames)
            {
                return true;
            }
            return false;
        }

        public void Draw(Texture2D myModel, Vector2 dims, Vector2 imageDims, Vector2 screenShift, Vector2 pos, float ROT, Color color, SpriteEffects spriteEffect)
        {
            Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + screenShift.X), (int)(pos.Y + screenShift.Y), (int)Math.Ceiling(dims.X), (int)Math.Ceiling(dims.Y)), new Rectangle((int)(sheetFrame.X * imageDims.X), (int)(sheetFrame.Y * imageDims.Y), (int)imageDims.X, (int)imageDims.Y), color, ROT, imageDims / 2, spriteEffect, 0);
        }
    }
}