using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.GameElements
{
     abstract class Unit : GameObject
    {
        protected Texture2D standardTexture;
        public Unit(int x, int y) : base(x, y)
        {
        }
    }
}
