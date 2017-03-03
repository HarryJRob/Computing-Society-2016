using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tron
{
    class MainGame
    {
        private GameWindow window;
        //List of players to allow for them to be added to a near indefinite amount. This allow for multiplayer
        //Needs to be a object List
        private List<Player> ObjectList = new List<Player> { };
        private List<int>[,] ObjectCollisionList;
        private List<Texture2D> textureList = new List<Texture2D>();

        private const int _columnNum = 10;
        private const int _rowNum = 10;
        private float _tileWidth;
        private float _tileHeight;

        public MainGame(GameWindow Window, List<Texture2D> TexList )
        {
            textureList = TexList;
            Window = Window;

            _tileWidth = (float)Window.ClientBounds.Width / _columnNum;
            _tileHeight = (float)Window.ClientBounds.Height / _rowNum;

            ObjectCollisionList = new List<int>[_columnNum,_rowNum];

            ObjectList.Add(new Player(textureList[2], 1, Color.Red, Window.ClientBounds.Height, Window.ClientBounds.Width));
        }

        //Update and Draw are called once every tick up to 60Hz (60 times per second)
        public void Update(GameTime gameTime, KeyboardState CurKeyState)
        {
            //The Keyboard is the input and output device the state is which keys are pressed at any given time.
            #region Update Shit
            for (int i = 0; i < ObjectList.Count; i++ )
                {
                    if (ObjectList[i].GetType() == typeof(Player))
                    {
                        ObjectList[i].Update(CurKeyState);
                    }
                    Rectangle curObjRec = ObjectList[i].BoundingBox;

                    if (curObjRec.X > 0 && curObjRec.Y > 0 && curObjRec.X < window.ClientBounds.Width &&
                            curObjRec.Y < window.ClientBounds.Height)
                    {
                        //top left
                        ObjectCollisionList[
                            (int)Math.Truncate(curObjRec.X / _tileWidth),
                            (int)Math.Truncate(curObjRec.Y / _tileHeight)].Add(i);
                    }
                    if (curObjRec.X + curObjRec.Width > 0 && curObjRec.Y > 0 &&
                        curObjRec.X + curObjRec.Width < window.ClientBounds.Width &&
                        curObjRec.Y < window.ClientBounds.Height)
                    {
                        //top right
                        ObjectCollisionList[
                            (int)Math.Truncate((curObjRec.X + curObjRec.Width) / _tileWidth),
                            (int)Math.Truncate(curObjRec.Y / _tileHeight)].Add(i);
                    }
                    if (curObjRec.X > 0 && curObjRec.Y + curObjRec.Height > 0 &&
                        curObjRec.X < window.ClientBounds.Width &&
                        curObjRec.Y + curObjRec.Height < window.ClientBounds.Height)
                    {
                        //bottom left
                        ObjectCollisionList[
                            (int)Math.Truncate(curObjRec.X / _tileWidth),
                            (int)Math.Truncate((curObjRec.Y + curObjRec.Height) / _tileHeight)].Add(i);
                    }
                    if (curObjRec.X + curObjRec.Width > 0 && curObjRec.Y + curObjRec.Height > 0 &&
                        curObjRec.X + curObjRec.Width < window.ClientBounds.Width &&
                        curObjRec.Y + curObjRec.Height < window.ClientBounds.Height)
                    {
                        //bottom right
                        ObjectCollisionList[
                            (int)Math.Truncate((curObjRec.X + curObjRec.Width) / _tileWidth),
                            (int)Math.Truncate((curObjRec.Y + curObjRec.Height) / _tileHeight)].Add(i);
                    }
                }

            for (var x = 0; x < _columnNum; x++)
            {
                for (var y = 0; y < _rowNum; y++)
                {
                    if (ObjectCollisionList[x, y].Count >= 2)
                    {
                        foreach (var curPlayer in ObjectList.OfType<Player>())
                        {
                            
                        }
                    }
                }
            }

            #endregion

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(backGround, new Rectangle(0,0,Window.ClientBounds.Width,Window.ClientBounds.Height), Color.White);
            foreach (Player CurPlayer in ObjectList)
            {
                CurPlayer.Draw(spriteBatch);
            }

            #region Drawing Collision Boxes

                for (int x = 0; x < _columnNum; x++)
                {
                    for (int y = 0; y < _rowNum; y++)
                    {
                        spriteBatch.Draw(textureList[0],
                            new Rectangle((int)(x * _tileWidth), (int)(y * _tileHeight), (int)_tileWidth,
                                (int)_tileHeight), Color.White);
                    }
                }

            #endregion


        }
    }
}
