using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    /// <summary>
    /// DesertTile 
    /// </summary>
    class DesertTile : HexTile
    {
        public DesertTile(int x, int y, int qCoord, int rCoord) : base(x, y, qCoord, rCoord)
        {

        }
        public override void load()
        {
            standardTexture = contentListener.retrieveImage("Tiles/desert");
            selectedTexture = contentListener.retrieveImage("Tiles/selectedTile");
        }

        public override HexTile createTile(int x, int y, int qCoord, int rCoord)
        {
            return new DesertTile(x, y, qCoord, rCoord);
        }
    }
}
