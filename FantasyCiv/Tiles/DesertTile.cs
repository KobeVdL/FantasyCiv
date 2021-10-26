﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public DesertTile(int x, int y) : base(x, y)
        {

        }
        public override void handleMouseClick(int x, int y)
        {
            this.setSelected(!this.isSelected());
        }
        public override void load()
        {
            standardTexture = contentListener.retrieveImage("Tiles/desert");
            selectedTexture = contentListener.retrieveImage("Tiles/selectedTile");
        }

        public override HexTile createTile(int x, int y)
        {
            return new DesertTile(x, y);
        }
    }
}
