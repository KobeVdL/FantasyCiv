using Microsoft.Xna.Framework;
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

        List<District> districts = new List<District>();

        bool selected;

        public HexTile(int x, int y) : base(x, y)
        {
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            spriteBatch.Draw(standardTexture, this.getAbsolutePosition(x, y), Color.White);
            foreach(District element in districts)
            {
                element.draw(spriteBatch,graphics, x+this.getX(), y+this.getY());
            }
            if (isSelected())
            {
                spriteBatch.Draw(selectedTexture, this.getAbsolutePosition(x, y), Color.White);
            }
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

        public void addDistrict(District newDistrict)
        {
            this.districts.Add(newDistrict);
        }

        public abstract HexTile createTile(int x, int y);



    }


}
