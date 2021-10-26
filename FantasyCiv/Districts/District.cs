using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    /// <summary>
    /// Base class of a district, describes a kind of building that is placed on tiles.
    /// </summary>
    abstract class District : GameObject
    {
        public District (int x, int y) : base(x, y)
        { 
        }


    }
}
