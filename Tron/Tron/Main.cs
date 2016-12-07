using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tron
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //List of players to allow for them to be added to a near indefinite amount. This allow for multiplayer
        List<Player> PlayerList = new List<Player> { };

        KeyboardState CurKeyState;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Sets the resolution of the game window to that of the computers resolution and sets to fullscreen
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();
            graphics.ToggleFullScreen();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        //Update and Draw are called once every tick up to 60Hz (60 times per second)
        protected override void Update(GameTime gameTime)
        {
            //The Keyboard is the input and output device the state is which keys are pressed at any given time.
            CurKeyState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) 
            { 
                Exit();
            }
            else
            {
                foreach (Player CurPlayer in PlayerList)
                {
                    CurPlayer.Update(CurKeyState);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Begin and End indicate when the sprite batch should start gather Textures and positions to be drawn to screen and when to push all the infomation it has to the screen
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (Player CurPlayer in PlayerList)
            {
                CurPlayer.Draw(spriteBatch);
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
