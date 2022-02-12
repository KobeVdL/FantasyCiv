using FantasyCiv.GameElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.Units
{
    class Stickmen : Unit
    {

        public Stickmen(int x, int y) : base(x, y)
        {
            this.setX(x);
            this.setY(y);
        }
        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            this.draw(standardTexture, spriteBatch, graphics, x, y,0.25f);
        }

        public override void load()
        {
            standardTexture = contentListener.retrieveImage("Units/Stickmen");
        }

    }
}
