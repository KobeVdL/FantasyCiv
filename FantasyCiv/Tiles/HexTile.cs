﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
    /// <summary>
    /// The Hextile superclass of all tiles
    /// </summary>
    abstract class HexTile : GameObject
    {
        protected Texture2D standardTexture;
        protected Texture2D selectedTexture;


        List<District> districts = new List<District>();

        bool selected;

        public HexTile(int x, int y) : base(x, y)
        {
        }

        //https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.SpriteBatch.html

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            this.draw(standardTexture, spriteBatch, graphics, x, y);
            foreach (District element in districts)
            {
                element.draw(spriteBatch,graphics, x+this.getX(), y+this.getY());
            }
            if (isSelected())
            {
                //public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
                this.draw(selectedTexture, spriteBatch, graphics, x, y);
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
