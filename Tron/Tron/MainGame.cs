using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tron
{
    class MainGame
    {
        private GameWindow window;
        //List of players to allow for them to be added to a near indefinite amount. This allow for multiplayer
        private List<Player> PlayerList = new List<Player> { };
        private Texture2D playerTexture;

        public MainGame(GameWindow Window, Texture2D playerTex)
        {
            playerTexture = playerTex;
            window = Window;
            PlayerList.Add(new Player(playerTexture, 1, Color.Red, Window.ClientBounds.Height, Window.ClientBounds.Width));
            PlayerList.Add(new Player(playerTexture, 2, Color.Red, Window.ClientBounds.Height, Window.ClientBounds.Width));
        }

        //Update and Draw are called once every tick up to 60Hz (60 times per second)
        public void Update(GameTime gameTime, KeyboardState CurKeyState)
        {
            //The Keyboard is the input and output device the state is which keys are pressed at any given time.

                foreach (Player CurPlayer in PlayerList)
                {
                    CurPlayer.Update(CurKeyState);
                }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(backGround, new Rectangle(0,0,Window.ClientBounds.Width,Window.ClientBounds.Height), Color.White);
            foreach (Player CurPlayer in PlayerList)
            {
                CurPlayer.Draw(spriteBatch);
            }

        }
    }
}
