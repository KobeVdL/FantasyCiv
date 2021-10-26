using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    /// <summary>
    /// Interface of class that could retrieve fonts or images
    /// </summary>
    interface ContentListener
    {

        public SpriteFont retrieveFont(String fontName);

        public Texture2D retrieveImage(String imageName);

    }
}
