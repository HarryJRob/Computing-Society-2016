using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tron
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Player> PlayerList = new List<Player> { };

        KeyboardState CurKeyState;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

        protected override void Update(GameTime gameTime)
        {
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (Player CurPlayer in PlayerList)
            {
                CurPlayer.Draw(spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
