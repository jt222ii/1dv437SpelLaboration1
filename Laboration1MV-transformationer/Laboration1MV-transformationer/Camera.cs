using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration1MV_transformationer
{
    class Camera
    {
        private int sizeOfTile = 64;
        private int borderSize = 64;
        public Vector2 getVisualCoords(int xCoord, int yCoord)
        {
            int visualX = borderSize + xCoord * sizeOfTile;
            int visualY = borderSize + yCoord * sizeOfTile;
            return new Vector2(visualX, visualY);
        }
        public Vector2 rotateView(int xCoord, int yCoord)
        {
            int visualX = sizeOfTile*8 - (xCoord * sizeOfTile);
            int visualY = sizeOfTile*8 - (yCoord * sizeOfTile);
            return new Vector2(visualX, visualY);
        }
    }
}
