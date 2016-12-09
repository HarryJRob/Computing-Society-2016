using System;
using System.Drawing;
using System.Collections.Generic;
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

        private List<Keys> ControlScheme = new List<Keys> { Keys.W, Keys.A, Keys.D, Keys.S}; //Currently hard coded will need to be loaded from a file
        private List<bool> MoveList = new List<bool> { false, false, false, false}; //Up, Left ,Right ,Down ,Boost, Space

        private TimeSpan _aliveTime; //To determine a winner and be able to rank mutiple players we can record the time spent alive and rank according to the longest time spent alive

        private int _playerNum; //ID for a player to determine what controls they use however we may be able to do this over the web looking into it

        //The width and height of the texture. However these should be dependant on the screen resolution
        private static int Width = 100;
        private static int Height = 100;

        //Sets and calculates the playerTexture, Starting Position, Color of the players wall and more (not yet)
        public Player (Texture2D playerTexture, int PlayerNum, Color WallColor, int WindowYSize, int WindowXSize) //Texture, Position, ColorOfWall
        {
            _playerTexture = playerTexture;
            _wallColor = WallColor;

            GameWindowX = WindowXSize;
            GameWindowY = WindowYSize;

            _playerPosition = new Vector2(20,20);

            //Calculate starting position based off of ID
            if (PlayerNum == 1)
            {
                //Set Pos to X
            } 

        }
        //Based off the keyBoard state do actions e.g if Upward key then move upwards
        //Of course this will contain the validation
        public void Update(KeyboardState CurKeyState)
        {
            for (int i = 0; i < ControlScheme.Count; i++)
            {
                if (CurKeyState.IsKeyDown(ControlScheme[i]))
                {
                    MoveList[i] = true;
                }
                else
                {
                    MoveList[i] = false;
                }
            }

            UpdatePlayer();
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
            if (MoveList[0])
            {
                if ((_playerPosition.Y - velocity) <= 0)
                {
                    _playerPosition.Y = 0;
                }
                else
                {
                    _playerPosition.Y -= velocity;
                }
            }
            if (MoveList[1])
            {
                if ((_playerPosition.X - velocity) <= 0)
                {
                    _playerPosition.X = 0;
                }
                else
                {
                    _playerPosition.X -= velocity;
                }
            }
            if (MoveList[2])
            {
                if ((_playerPosition.X + velocity) >= GameWindowX - Width)
                {
                    _playerPosition.X = GameWindowX - Width;
                }
                else
                {
                    _playerPosition.X += velocity;
                }
            }
            if (MoveList[3])
            {
                if ((_playerPosition.Y + velocity) >= GameWindowY - Height)
                {
                    _playerPosition.Y = GameWindowY - Height;
                }
                else
                {
                    _playerPosition.Y += velocity;
                }
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
