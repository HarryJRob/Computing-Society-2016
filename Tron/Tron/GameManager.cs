using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tron
{
    public class GameManager : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private MainGame _mainGame;
        private MainMenu _mainMenu;
        //List of players to allow for them to be added to a near indefinite amount. This allow for multiplayer
        private List<Texture2D> TexList;

        private KeyboardState CurKeyState;
        private MouseState CurMouseState;
        public GameManager()
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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TexList = new List<Texture2D>();
            TexList.Add(Content.Load<Texture2D>("Resources/CollisionArea"));
            TexList.Add(Content.Load<Texture2D>("Resources/BackGround"));
            TexList.Add(Content.Load<Texture2D>("Resources/Tron"));
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
            CurMouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) 
            { 
                Exit();
            }
            else
            {
                switch (Globals.CurrentGameState)
                {
                    case Globals.GameState.MainMenu:
                        if (_mainGame == null)
                        {
                            _mainGame = new MainGame(Window, TexList);
                        }
                        else
                        {
                            _mainGame.Update(gameTime, CurKeyState);
                        }
                        break;

                    case Globals.GameState.PlayingGame:
                        if (_mainMenu == null)
                        {
                            _mainMenu = new MainMenu(Window);
                        }
                        else
                        {
                            _mainMenu.Update(gameTime, CurKeyState, CurMouseState);
                        }
                        break;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Begin and End indicate when the sprite batch should start gather Textures and positions to be drawn to screen and when to push all the infomation it has to the screen
            spriteBatch.Begin();
           spriteBatch.Draw(TexList[1], new Rectangle(0,0,Window.ClientBounds.Width,Window.ClientBounds.Height), Color.White);

            switch (Globals.CurrentGameState)
            {
                case Globals.GameState.MainMenu:
                    _mainGame.Draw(gameTime, spriteBatch);
                    break;

                case Globals.GameState.PlayingGame:
                    _mainMenu.Draw(gameTime, spriteBatch);
                    break;
            }

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
