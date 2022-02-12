using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    /// <summary>
    /// GrassTile
    /// </summary>
    class GrassTile : HexTile
    {
        public GrassTile(int x, int y, int qCoord, int rCoord) : base(x, y, qCoord, rCoord)
        {

        }

        public override void load()
        {
            standardTexture = contentListener.retrieveImage("Tiles/grass");
            selectedTexture = contentListener.retrieveImage("Tiles/selectedTile");
        }

        public override HexTile createTile(int x, int y, int qCoord, int rCoord)
        {
            return new GrassTile(x, y, qCoord, rCoord);
        }
    }
}
