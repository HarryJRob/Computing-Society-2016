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

        //A list of points for each corner of the wall the player has drawn behind them
        private List<Vector2> WallList = new List<Vector2> { };
        private Vector2 LastVec; //Not sure about this?
        private Color _wallColor; //The colour of the wall to be drawn behind the player

        private TimeSpan _aliveTime; //To determine a winner and be able to rank mutiple players we can record the time spent alive and rank according to the longest time spent alive

        private int _playerNum; //ID for a player to determine what controls they use however we may be able to do this over the web looking into it

        //The width and height of the texture. However these should be dependant on the screen resolution
        private static int _width = 100;
        private static int _height = 100;

        //Sets and calculates the playerTexture, Starting Position, Color of the players wall and more (not yet)
        public Player (Texture2D playerTexture, int PlayerNum, Color WallColor) //Texture, Position, ColorOfWall
        {
            _playerTexture = playerTexture;
            _wallColor = WallColor;

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
            if (_playerNum == 1)
            {
                
            }
            if (_playerNum == 2)
            {

            }






        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Player
            spriteBatch.Draw(_playerTexture, new Rectangle((int)_playerPosition.X,(int)_playerPosition.Y, _width, _height),Color.White);

            //Draw WallList
            LastVec = WallList[0];
            foreach (Vector2 CurVec in WallList)
            {
                
            }

            //Draw UI
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
