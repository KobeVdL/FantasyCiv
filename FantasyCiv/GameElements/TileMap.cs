using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    // This class works with Axial coordinates , generally the arrays behave like normal but the collumns follow a direction of the hexagon
    // more info see https://www.redblobgames.com/grids/hexagons/
    class TileMap : GameObject// : GameObjectContainer<ArrayList>
    {
        private List<List<HexTile>> map = new List<List<HexTile>>();
        private double tileSize;

        public TileMap(int x, int y, int widthTiles, int heightTiles, ContentListener contentListener) : base(x, y)
        {
            this.setContentListener(contentListener);
            initialize(x, y, widthTiles, heightTiles);
        }

        private void initialize(int x, int y, int widthTiles, int heightTiles)
        {
            initializeTileSize();
            int yVar = y;
            int xVar;
            int height = (int)(2 * tileSize);
            int width = (int)(Math.Sqrt(3) * tileSize);
            for (int i = 0; i < heightTiles; i++)
            {
                if (i % 2 == 0)
                {
                    xVar = x;
                }
                else
                {
                    xVar = width / 2 + x;
                }
                map.Add(createArrayOfTiles(widthTiles, xVar, yVar));
                yVar +=(int)((height * 3) / 4);
            }
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            foreach (List<HexTile> array in map)
            {
                foreach (HexTile tile in array)
                {
                    tile.draw(spriteBatch, graphics);
                }
            }
        }

        public override void load()
        {
        }

        // first set the origin in the middle of the first tile
        public override void handleMouseClick(int x, int y)
        {
            double tileMiddleWidth = this.tileSize * (Math.Sqrt(3)/2);
            double tileMiddleHeight = this.tileSize;
            HexTile selectedTile = getTileAtPixel(x - this.getX() - tileMiddleWidth, (int) (y-this.getY()- tileMiddleHeight));
            if (selectedTile != null)
            {
                selectedTile.handleMouseClick(0, 0);//TODO 
            }
        }

        private void initializeTileSize()
        {
            GrassTile grass = new GrassTile(0, 0);
            grass.setContentListener(contentListener);
            grass.load();
            this.tileSize = grass.getHeight() / 2.0;
        }

        private List<HexTile> createArrayOfTiles(int nmbOfTiles, int x, int y)
        {
            GrassTile grass = new GrassTile(0, 0);
            grass.setContentListener(contentListener);
            grass.load();
            List<HexTile> array = new List<HexTile>();
            for (int i = 0; i < nmbOfTiles; i++)
            {
                GrassTile tile = new GrassTile(i * grass.getWidth() + x, y);
                tile.setContentListener(contentListener);
                tile.load();
                array.Add(tile);
            }
            return array;
        }
        /**
         * r is the row number, q is the diagonal column, r can be negative.
         * 
         */
        public HexTile getTileAtCoordinate(int r, int q)
        {
            int[] coordinates = axialToOffset(r, q);
            if(coordinates[0]<0 || coordinates[1] < 0 || coordinates[0]>= map.Count || coordinates[1] >= map[coordinates[0]].Count){
                return null;
            }
            return map[coordinates[0]][coordinates[1]];
        }

        private HexTile getTileAtPixel(double doubleX, double doubleY)
        {
            double doubleQ = ((((Math.Sqrt(3.0) / 3.0) * doubleX - (1.0 / 3.0) * doubleY)) / tileSize);
            double doubleR = (((2.0 /3.0)  * doubleY) / tileSize);
            int[] roundedHex = hexRound(doubleQ, doubleR);
            return getTileAtCoordinate(roundedHex[0], roundedHex[1]);
        }










        private int[] hexRound(double q, double r)
        {
            double x = q;
            double z = r;
            double y = -x - z;
            int[] cubeRounded = cubeRound(x, y, z);
            return cubeToAxial(cubeRounded);
        }

        private int[] cubeRound(double x, double y, double z)
        {
            double rx = Math.Round(x);
            double ry = Math.Round(y);
            double rz = Math.Round(z);

            double x_diff = Math.Abs(rx - x);
            double y_diff = Math.Abs(ry - y);
            double z_diff = Math.Abs(rz - z);

            if (x_diff > y_diff && x_diff > z_diff) 
            {
                rx = -ry - rz;
            }
            else if (y_diff > z_diff)
            {
                ry = -rx - rz;
            }
            else 
            {
                rz = -rx - ry;
            }

            return new int[] {(int) rx,(int) ry, (int) rz };
        }

        private int[] cubeToAxial(int[] cubeCoord)
        {
            int q = cubeCoord[0];
            int r = cubeCoord[2];
            return new int[] { r, q };
        }



        private int[] axialToOffset(int r, int q)
        {
            int col;
            int row;
            // check if r is even or uneven
            if (r % 2 == 0)
            {
                col = q + ((int)r / 2);
            }
            else
            {
                col = q + (((int)r - 1) / 2);
            }
            row = r;
            return new int[] { row, col };
        }



    }
}
