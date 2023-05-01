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

namespace CosmicHunter
{
    public class UI
    {
        public Hero hero;
        public Button2d resetButton;
        public SpriteFont font;
        public DisplayBar healthBar;

        public UI(PassObject reset)
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");          //use given font

            resetButton = new Button2d("2d\\Misc\\simpleButton", new Vector2(0, 0), new Vector2(96, 32), "Fonts\\Arial16", "Restart", reset, null);

            //healthBar = new DisplayBar(new Vector2(104, 16), 2, Color.Red);   //give the healthbar size (big healthbar left corner)
            healthBar = new DisplayBar(new Vector2(50, 8), 2, Color.Red);       //give the healthbar size (small healthbar under hero)
        }

        public void Update(World world)
        {
            healthBar.Update(world.user.hero.health, world.user.hero.healthMax);  //fill the healthbar with the hero's health

            if (world.user.hero.dead)                                             //show the reset button when the hero dies
            {
                resetButton.Update(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 50));
            }
        }

        public void Draw(World world, Hero hero)
        {
            string remainingEnemies = "Enemies Remaining: " + GameGlobals.enemiesRemaining;     //the text for amount of enemies remaining
            string score = "Score: " + GameGlobals.score;                                       //the text for the score
            Vector2 stringDimensionsRemainingEnemies = font.MeasureString(remainingEnemies);    //dimensions of the text
            Vector2 stringDimensionsScore = font.MeasureString(score);

            //draw the text centered in the middle lower side of the screen
            Globals.spriteBatch.DrawString(font, remainingEnemies, new Vector2(Globals.screenWidth / 2 - stringDimensionsRemainingEnemies.X / 2, Globals.screenHeight / 100 * 90), Color.Red);

            //draw the text at the left corner of the screen
            Globals.spriteBatch.DrawString(font, score, new Vector2(Globals.screenWidth / 12 - stringDimensionsScore.X / 2, Globals.screenHeight / 100 * 90), Color.Red);

            //healthBar.Draw(new Vector2(Globals.screenWidth / 30, Globals.screenHeight / 100 * 91));   //put the healthbar at the bottom left of the screen
            healthBar.Draw(new Vector2(hero.position.X - 25, hero.position.Y + 40));                    //put the healthbar under the hero

            if (world.user.hero.dead)
            {
                //if the hero dies, pause the game and show a text that says 'press enter to restart', when enter is pressed the game will restart
                string restartText = "You lost! Press Enter or click the button to restart!";
                stringDimensionsRemainingEnemies = font.MeasureString(restartText);
                Globals.spriteBatch.DrawString(font, restartText, new Vector2(Globals.screenWidth / 2 - stringDimensionsRemainingEnemies.X / 2, Globals.screenHeight / 100 * 40), Color.Red);

                resetButton.Draw(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 50)); // draw the button directly below the text
            }
        }
    }
}