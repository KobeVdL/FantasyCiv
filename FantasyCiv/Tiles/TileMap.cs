using FantasyCiv.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    // This class works with Axial coordinates , generally the arrays behave like normal but the collumns follow a direction of the hexagon
    // more info see https://www.redblobgames.com/grids/hexagons/
    class TileMap : GameObject ,MapListener// : GameObjectContainer<ArrayList>
    {
        private List<List<HexTile>> map = new List<List<HexTile>>();
        private double tileSize;
        private List<HexTile> selectedTiles = new List<HexTile>();
        private int rmax;
        private int qmax;
        public TileMap(int x, int y, int widthTiles, int heightTiles, ContentListener contentListener) : base(x, y)
        {
            this.setContentListener(contentListener);
            initialize(x, y, widthTiles, heightTiles);
        }

        private void initialize(int x, int y, int widthTiles, int heightTiles)
        {
            initializeTileSize();
            int yVar = 0;//y;
            int xVar;
            int height = (int)(2 * tileSize);
            int width = (int)(Math.Sqrt(3) * tileSize);
            for (int i = 0; i < heightTiles; i++)
            {
                if (i % 2 == 0)
                {
                    xVar = 0;
                }
                else
                {
                    xVar = width / 2 ;
                }
                List<HexTile> availableTiles = new List<HexTile>(new HexTile[] {
                    new GrassTile(0,0,0,0),
                    new GrassTile(0,0,0,0),
                    new WaterTile(0,0,0,0),
                    new DesertTile(0,0,0,0)
                    }) ;
                map.Add(createRandomMap(widthTiles, xVar, yVar,availableTiles));
                yVar +=(int)((height * 3) / 4);
            }
            this.addMapListenerToMap();
        }

        private void addMapListenerToMap()
        {
            foreach(List<HexTile> row in map)
            {
                foreach(HexTile tile in row)
                {
                    tile.maplistener = this;
                }
            }
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            foreach (List<HexTile> array in map)
            {
                foreach (HexTile tile in array)
                {
                    tile.draw(spriteBatch, graphics,x + this.getX(), y + this.getY());
                }
            }
        }

        public override void load()
        {
        }

        // first set the origin in the middle of the first tile
        public override void handleMouseClick(int x, int y, KeyboardState kstate)
        {
            double tileMiddleWidth = this.tileSize * (Math.Sqrt(3) / 2);
            double tileMiddleHeight = this.tileSize;
            HexTile selectedTile = getTileAtPixel(x - this.getX() - tileMiddleWidth, (int)(y - this.getY() - tileMiddleHeight));
            if (selectedTiles.Contains(selectedTile))
            {
                selectedTile.unselectTile();
                selectedTiles.Remove(selectedTile);
            }
            else
            {
                if (!kstate.IsKeyDown(Keys.LeftControl)&& !kstate.IsKeyDown(Keys.RightControl))
                {
                    unselectTiles();
                }
                if (selectedTile != null)
                {
                    selectedTiles.Add(selectedTile);
                    selectedTile.handleMouseClick(0, 0, kstate);//TODO 
                }
            }
        }

        private void unselectTiles()
        {
            foreach(HexTile tile in selectedTiles)
            {
                tile.unselectTile();
            }
            selectedTiles.Clear();
        }

        private void initializeTileSize()
        {
            GrassTile grass = new GrassTile(0, 0,0,0);
            grass.setContentListener(contentListener);
            grass.load();
            this.tileSize = (grass.getHeight() / 2.0) -1;
        }

        private List<HexTile> createArrayOfTiles(int nmbOfTiles, int x, int y)
        {
            int tileWidth = (int) Math.Round(this.tileSize * (Math.Sqrt(3)));
            HexTile tile;
            List<HexTile> array = new List<HexTile>();
            for (int i = 0; i < nmbOfTiles; i++)
            {
                int[] hexCoord = realToQRCoord(i * tileWidth + x, y);
                if (i % 3 == 0)
                {
                    tile = new WaterTile(i * tileWidth + x, y,hexCoord[0],hexCoord[1]);
                }
                else if (i % 4 == 0)
                {
                    tile = new DesertTile(i * tileWidth + x, y, hexCoord[0], hexCoord[1]);
                }
                else
                {
                    tile = new GrassTile(i * tileWidth + x, y, hexCoord[0], hexCoord[1]);
                }
                tile.setContentListener(contentListener);
                tile.load();
                array.Add(tile);
            }
            return array;
        }

        public List<HexTile> createRandomMap(int nmbOfTiles, int x, int y, List<HexTile> availableTiles)
        {
            var rand = new Random();
            int sizeAvailable = availableTiles.Count;
            int tileWidth = (int)Math.Round(this.tileSize * (Math.Sqrt(3)));
            HexTile tile;
            List<HexTile> array = new List<HexTile>();
            for (int i = 0; i < nmbOfTiles; i++)
            {
                int indexTile = rand.Next(0, sizeAvailable);
                int[] hexCoord = realToQRCoord(i * tileWidth + x, y);
                tile = availableTiles[indexTile].createTile(i * tileWidth + x, y,hexCoord[0],hexCoord[1]);
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
        public HexTile getTileAtCoordinate( int q, int r)
        {
            int[] coordinates = axialToOffset(q,r);
            if(coordinates[0]<0 || coordinates[1] < 0 || coordinates[0]>= map.Count || coordinates[1] >= map[coordinates[0]].Count){
                return null;
            }
            return map[coordinates[0]][coordinates[1]];
        }

        private HexTile getTileAtPixel(double doubleX, double doubleY)
        {
            int[] roundedHex = realToQRCoord(doubleX,  doubleY);
            return getTileAtCoordinate(roundedHex[0], roundedHex[1]);
        }

        private int[] realToQRCoord(double doubleX, double doubleY)
        {
            double doubleQ = ((((Math.Sqrt(3.0) / 3.0) * doubleX - (1.0 / 3.0) * doubleY)) / tileSize);
            double doubleR = (((2.0 / 3.0) * doubleY) / tileSize);
            return hexRound(doubleQ, doubleR);
        }

        /*
         *Returns a random land tile, not recommended when there are a lot of water tiles. 
         * 
         */
        public HexTile getRandomLandTile()
        {
            var rand = new Random();
            HexTile randomTile;
            int row = rand.Next(0, map.Count);
            int column = rand.Next(0, map[row].Count);
            randomTile = map[row][column];
            while(randomTile is WaterTile)
            {
                row = rand.Next(0, map.Count);
                column = rand.Next(0, map[row].Count);
                randomTile = map[row][column];
            }
            return randomTile;
            
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

        //TODO check special cases
        public List<HexTile> getNeighbours(int qCoord, int rCoord)
        {
            List<HexTile> neighbours = new List<HexTile>();
            neighbours.Add(this.getTileAtCoordinate(qCoord - 1, rCoord));
            neighbours.Add(this.getTileAtCoordinate(qCoord + 1, rCoord));
            neighbours.Add(this.getTileAtCoordinate(qCoord, rCoord -1));
            neighbours.Add(this.getTileAtCoordinate(qCoord, rCoord + 1));
            neighbours.Add(this.getTileAtCoordinate(qCoord - 1, rCoord + 1));
            neighbours.Add(this.getTileAtCoordinate(qCoord + 1, rCoord - 1));
            return neighbours;
           // throw new NotImplementedException();
        }

        //TODO check if no other units
        public void moveUnitTo(HexTile tile, int qCoord, int rCoord)
        {
            Unit unit = tile.removeUnit();
            this.getTileAtCoordinate(qCoord, rCoord).unit = unit;
        }
    }
}
