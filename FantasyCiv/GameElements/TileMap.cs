using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    class TileMap: GameObject// : GameObjectContainer<ArrayList>
    {
        ArrayList map = new ArrayList();
        public TileMap(int x, int y, int widthTiles, int heightTiles, ContentListener contentListener): base(x,y)
        {
            this.setContentListener(contentListener);
            initialize( x, y, widthTiles, heightTiles);
        }
        
        private void initialize(int x, int y, int widthTiles, int heightTiles)
        {
            GrassTile grass = new GrassTile(0, 0);
            grass.setContentListener(contentListener);
            grass.load();
            int yVar = y;
            int xVar;
            for(int i = 0; i < heightTiles; i++)
            {
                if (i % 2 == 0)
                {
                    xVar = x;
                }
                else
                {
                    xVar = grass.getWidth() / 2 + x;
                }
                map.Add(createArrayOfTiles(widthTiles, xVar, yVar));
                yVar += (grass.getHeight() * 3 / 4);
            }
            
        }

        private ArrayList createArrayOfTiles(int nmbOfTiles, int x, int y)
        {
            GrassTile grass = new GrassTile(0, 0);
            grass.setContentListener(contentListener);
            grass.load();
            ArrayList array = new ArrayList();
            for (int i = 0; i < nmbOfTiles; i++)
            {
                GrassTile tile = new GrassTile(i * grass.getWidth() + x,y);
                tile.setContentListener(contentListener);
                tile.load();
                array.Add(tile);
            }
            return array;
        }

        public override void load()
        {
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            foreach(ArrayList array in map)
            {
                foreach(HexTile tile in array)
                {
                    tile.draw(spriteBatch, graphics);
                }
            }
        }
    }
}
