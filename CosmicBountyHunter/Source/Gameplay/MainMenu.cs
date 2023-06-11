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
    public class MainMenu
    {
        public Basic2d background;
        public PassObject playClick, exitClick;
        public List<Button2d> buttons = new List<Button2d>();
        public static bool hardmode;

        public MainMenu(PassObject playClick, PassObject exitClick)
        {
            this.playClick = playClick;
            this.exitClick = exitClick;

            //background image, load it on the center of the screen and make it as big as the screen size and width
            background = new Basic2d("2d\\UI\\Backgrounds\\menuBackground", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), 
                new Vector2(Globals.screenWidth, Globals.screenHeight));

            buttons.Add(new Button2d("2d\\Misc\\button", new Vector2(0, 0), new Vector2(144, 48), "Fonts\\Arial16", "EASY", playClick, 1));     //play game on easy difficulty
            buttons.Add(new Button2d("2d\\Misc\\button", new Vector2(0, 0), new Vector2(144, 48), "Fonts\\Arial16", "HARD", playClick, 1));     //play game on hard difficulty
            buttons.Add(new Button2d("2d\\Misc\\button", new Vector2(0, 0), new Vector2(144, 48), "Fonts\\Arial16", "EXIT", exitClick, null));  //exit the game
        }

        public virtual void Update()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                //X and Y position of the button, 45 is size of button, for every button it goes down
                buttons[i].Update(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 45 * i));
            }

            if (buttons[0].isPressed)
            {
                hardmode = false;
            }
            else if (buttons[1].isPressed)
            {
                hardmode = true;
            }
        }

        public virtual void Draw()
        {
            background.Draw(Vector2.Zero);  //draw the background

            for (int i = 0; i < buttons.Count; i++)
            {
                //draw the buttons on the same coordinates as they are being updated
                buttons[i].Draw(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 45 * i));
            }
        }
    }
}