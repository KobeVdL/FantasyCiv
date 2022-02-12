using FantasyCiv.GameElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.Tiles
{
    interface MapListener
    {
        List<HexTile> getNeighbours(int qCoord, int rCoord);

        void moveUnitTo(HexTile tile, int qCoord, int rCoord);
    }
}
