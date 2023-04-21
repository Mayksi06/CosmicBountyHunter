using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CosmicHunter
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        GamePlay gamePlay;

        World world;

        Basic2d cursor;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //screen size
            Globals.screenWidth = 900; //900-1600-1920
            Globals.screenHeight = 500; //500-900-1080

            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            //load cursor image, set cursor position and size
            cursor = new Basic2d("2d\\Misc\\cursor", new Vector2(0, 0), new Vector2(35, 35)); //28, 28

            Globals.keyboard = new MdKeyboard();
            Globals.mouse = new MdMouseControl();

            gamePlay = new GamePlay();
        }

        protected override void UnloadContent()
        {
            //get rid of anything you don't want
        }

        protected override void Update(GameTime gameTime)
        {
            //updating the game logic, the keyboard and the mouse
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;    //gives number of milliseconds between frames
            Globals.keyboard.Update();
            Globals.mouse.Update();

            gamePlay.Update();

            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.Black);

            //spriteBatch has to open and close, everything that happens in the game should come between it
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            //draw the world
            gamePlay.Draw();

            //cursor.Draw(new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y), new Vector2(0, 0));  //position = top left of image
            cursor.Draw(new Vector2(Globals.mouse.newMousePosition.X, Globals.mouse.newMousePosition.Y), Color.White);   //position = center of image
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        internal class Program
        {
            private static void Main(string[] args)
            {
                using var game = new CosmicHunter.Main();
                game.Run();
            }
        }
    }
}