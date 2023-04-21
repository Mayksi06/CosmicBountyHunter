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
        public SpriteFont font;
        public DisplayBar healthBar;

        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");      //use given font
            //healthBar = new DisplayBar(new Vector2(104, 16), 2, Color.Red); //give the healthbar size
            healthBar = new DisplayBar(new Vector2(50, 8), 2, Color.Red);
        }

        public void Update(World world)
        {
            healthBar.Update(world.hero.health, world.hero.healthMax);  //fill the healthbar with the hero's health
        }

        public void Draw(World world, Hero hero)
        {
            string remainingEnemies = "Enemies Remaining: " + world.enemiesRemaining;   //the text
            Vector2 stringDimensions = font.MeasureString(remainingEnemies);            //dimensions of the text

            //draw the text centered in the middle lower side of the screen
            Globals.spriteBatch.DrawString(font, remainingEnemies, new Vector2(Globals.screenWidth / 2 - stringDimensions.X / 2, Globals.screenHeight / 100 * 90), Color.Red);

            //healthBar.Draw(new Vector2(Globals.screenWidth / 30, Globals.screenHeight / 100 * 91));   //put the healthbar at the bottom left of the screen
            healthBar.Draw(new Vector2(hero.position.X - 25, hero.position.Y + 40));                    //put the healthbar under the hero

            if (world.hero.dead)
            {
                string restartText = "Press Enter to Restart!";
                stringDimensions = font.MeasureString(restartText);
                Globals.spriteBatch.DrawString(font, restartText, new Vector2(Globals.screenWidth / 2 - stringDimensions.X / 2, Globals.screenHeight / 100 * 40), Color.Red);
            }
        }
    }
}