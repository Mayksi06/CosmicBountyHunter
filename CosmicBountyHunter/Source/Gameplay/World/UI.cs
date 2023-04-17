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
        public SpriteFont font;

        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");
        }

        public void Update(World world)
        {

        }

        public void Draw(World world)
        {
            string remainingEnemies = "Enemies Remaining: " + world.enemiesRemaining;
            Vector2 stringDimensions = font.MeasureString(remainingEnemies);

            Globals.spriteBatch.DrawString(font, remainingEnemies, new Vector2(Globals.screenWidth / 2 - stringDimensions.X / 2, Globals.screenHeight / 100 * 90), Color.Red);
        }
    }
}