using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    class City: District
    {
        protected Texture2D standardTexture;
        public City(int x, int y) : base(x,y)
        {

        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            spriteBatch.Draw(standardTexture, this.getAbsolutePosition(x, y), Color.White);
        }

        public override void load()
        {
            standardTexture = contentListener.retrieveImage("Districts/City");
        }
    }
}
