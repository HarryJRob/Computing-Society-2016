using System;
using System.Drawing;
using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tron
{
    class Player
    {
        //The texture and position of the player
        private Texture2D _playerTexture;
        private Vector2 _playerPosition;

        private int velocity = 10;

        private readonly int GameWindowY;
        private readonly int GameWindowX;

        //A list of points for each corner of the wall the player has drawn behind them
        private List<Vector2> WallList = new List<Vector2> { };
        private Vector2 LastVec; //Not sure about this?
        private Color _wallColor; //The colour of the wall to be drawn behind the player

        private byte CurMovement = 0; //0 = up, 1 = right, 2 = down, 3 = left
        private List<Keys> ControlScheme = new List<Keys> { Keys.W, Keys.A, Keys.D, Keys.S}; //Currently hard coded will need to be loaded from a file

        private TimeSpan _aliveTime; //To determine a winner and be able to rank mutiple players we can record the time spent alive and rank according to the longest time spent alive

        private int _playerNum; //ID for a player to determine what controls they use however we may be able to do this over the web looking into it

        //The width and height of the texture. However these should be dependant on the screen resolution
        private static int Width = 100;
        private static int Height = 100;

        //Sets and calculates the playerTexture, Starting Position, Color of the players wall and more (not yet)
        public Player (Texture2D playerTexture, int PlayerNum, Color WallColor, int WindowYSize, int WindowXSize) //Texture, Position, ColorOfWall
        {
            CurMovement = 1;

            _playerTexture = playerTexture;
            _wallColor = WallColor;

            GameWindowX = WindowXSize;
            GameWindowY = WindowYSize;

            _playerPosition = new Vector2(20,20);

            //Calculate starting position based off of ID
            _playerPosition.X += 50*PlayerNum;

        }

        //Based off the keyBoard state do actions e.g if Upward key then move upwards
        //Of course this will contain the validation
        public void Update(KeyboardState CurKeyState)
        {
            //0 = up, 1 = right, 2 = down, 3 = left
            if (CurKeyState.GetPressedKeys().Length != 0)
            {
                switch (CurMovement)
                {
                    //Needs Redoing
                    case 0:
                        if (CurKeyState.IsKeyDown(ControlScheme[1]))
                        {
                            ChangeDirection(ControlScheme[1]);
                        }
                        else if (CurKeyState.IsKeyDown(ControlScheme[2]))
                        {
                            ChangeDirection(ControlScheme[2]);
                        }
                        break;
                    case 1:
                        if (CurKeyState.IsKeyDown(ControlScheme[0]))
                        {
                            ChangeDirection(ControlScheme[0]);
                        }
                        else if (CurKeyState.IsKeyDown(ControlScheme[3]))
                        {
                            ChangeDirection(ControlScheme[3]);
                        }
                        break;
                    case 2:
                        if (CurKeyState.IsKeyDown(ControlScheme[1]))
                        {
                            ChangeDirection(ControlScheme[1]);
                        }
                        else if (CurKeyState.IsKeyDown(ControlScheme[2]))
                        {
                            ChangeDirection(ControlScheme[2]);
                        }
                        break;
                    case 3:
                        if (CurKeyState.IsKeyDown(ControlScheme[0]))
                        {
                            ChangeDirection(ControlScheme[0]);
                        }
                        else if (CurKeyState.IsKeyDown(ControlScheme[3]))
                        {
                            ChangeDirection(ControlScheme[3]);
                        }
                        break;
                }
            }
            UpdatePlayer();
        }

        private void ChangeDirection(Keys CurKey)
        {
            switch (CurKey)
            {
                case Keys.W:
                    CurMovement = 0;
                    break;
                case Keys.D:
                    CurMovement = 1;
                    break;
                case Keys.S:
                    CurMovement = 2;
                    break;
                case Keys.A:
                    CurMovement = 3;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Player
            spriteBatch.Draw(_playerTexture, new Rectangle((int)_playerPosition.X,(int)_playerPosition.Y, Width, Height),Color.White);
            //Draw WallList

            //Draw UI
        }

        public void UpdatePlayer()
        {
            //0 = up, 1 = right, 2 = down, 3 = left
            if (CurMovement == 0 && (_playerPosition.Y - velocity) >= 0)
            {
                _playerPosition.Y -= velocity;
            }
            else if (CurMovement == 1 && (_playerPosition.X + velocity + Width) <= GameWindowX)
            {
                _playerPosition.X += velocity;
            }
            else if (CurMovement == 2 && (_playerPosition.Y + velocity + Height) <= GameWindowY)
            {
                _playerPosition.Y += velocity;
            }
            else if (CurMovement == 3 && (_playerPosition.X - velocity) >= 0)
            {
                _playerPosition.X -= velocity;
            }
        }

        public void StartGame()
        {
            //Starts the AliveTimer for the player
        }

        public void StopGame()
        {
            //Stop the AliveTimer for the player
        }
    }
}
