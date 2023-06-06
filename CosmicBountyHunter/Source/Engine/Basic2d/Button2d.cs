using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class Button2d : Basic2d
    {
        public bool isPressed, isHovered;   //see if button is being pressed or hovered over
        public string text;                 //button text
        public SpriteFont font;             //text font
        public object info;                 //passing object when button clicked
        public PassObject buttonClicked;

        public Button2d(string path, Vector2 position, Vector2 dimensions, string fontPath, string text, PassObject buttonClicked, object info) : base(path, position, dimensions)
        {
            this.info = info;
            this.text = text;
            this.buttonClicked = buttonClicked;

            if (fontPath != "")             //you should be able to use a button without a font
            {
                font = Globals.content.Load<SpriteFont>(fontPath);
            }

            isPressed = false;
        }

        public override void Update(Vector2 offset)
        {
            if (Hover(offset))                      //if hovered over button
            {
                isHovered = true;

                if (Globals.mouse.LeftClick())      //clicking on button doesn't mean hovering over button
                {
                    isHovered = false;
                    isPressed = true;
                }

                else if (Globals.mouse.LeftClickRelease())
                {
                    RunButtonClick();
                }
            }
            else                                    //not hovered over button
            {
                isHovered = false;
            }

            if (!Globals.mouse.LeftClick() && !Globals.mouse.LeftClickHold())
            {
                isPressed = false;
            }

            base.Update(offset);
        }

        public virtual void Reset()                 //if the buttons get more complicated, you should be able to reset the states
        {
            isPressed = false;
            isHovered = false;
        }

        public virtual void RunButtonClick()
        {
            if (buttonClicked != null)
            {
                buttonClicked(info);
            }

            Reset();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);

            Vector2 stringDimensions = font.MeasureString(text);
            Globals.spriteBatch.DrawString(font, text, position + offset + new Vector2(-stringDimensions.X / 2, -stringDimensions.Y / 2), Color.Black);
        }
    }
}