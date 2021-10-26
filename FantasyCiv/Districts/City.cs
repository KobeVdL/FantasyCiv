using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    /// <summary>
    ///  This is a city class discribing a kind of district that could be placed on tiles.
    /// </summary>
    class City: District
    {
        /// <summary>
        /// Standard texture of this city
        /// </summary>
        protected Texture2D standardTexture;
        public City(int x, int y) : base(x,y)
        {

        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            this.draw(standardTexture, spriteBatch, graphics, x, y);
        }

        public override void load()
        {
            standardTexture = contentListener.retrieveImage("Districts/City");
        }
    }
}
