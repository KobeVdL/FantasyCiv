using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    abstract class HexTile : GameObject
    {
        protected Texture2D standardTexture;
        protected Texture2D selectedTexture;

        bool selected;

        public HexTile(int x, int y) : base(x, y)
        {
        }

        public int getImageWidth()
        {
            return standardTexture.Width;
        }

        public int getImageHeight()
        {
            return standardTexture.Height;
        }
        public float getSize()
        {
            return getImageHeight() / 2;
        }

        public override int getWidth()
        {
            return (int) (getSize() * Math.Sqrt(3));
        }

        public override int getHeight()
        {
            return (int)(getSize() * 2);
        }

        protected void setSelected(bool selected)
        {
            this.selected = selected;
        }

        public bool isSelected()
        {
            return this.selected;
        }

        public abstract HexTile createTile(int x, int y);

    }


}
