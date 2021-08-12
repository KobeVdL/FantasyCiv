﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    class WaterTile : HexTile
    {
        public WaterTile(int x, int y) : base(x, y)
        {

        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            spriteBatch.Draw(standardTexture, this.getAbsolutePosition(x, y), Color.White);
            if (isSelected())
            {
                spriteBatch.Draw(selectedTexture, this.getAbsolutePosition(x, y), Color.White);
            }
        }

        public override void load()
        {
            standardTexture = contentListener.retrieveImage("Tiles/water");
            selectedTexture = contentListener.retrieveImage("Tiles/selectedTile");
        }

        public override void handleMouseClick(int x, int y)
        {
            this.setSelected(!this.isSelected());
        }

        public override HexTile createTile(int x, int y)
        {
            return new WaterTile(x, y);
        }
    }
}

