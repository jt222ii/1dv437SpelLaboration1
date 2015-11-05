using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration1MV_transformationer
{
    class Camera
    {
        public Vector2 getVisualCoords(int xCoord, int yCoord)
        {
            int sizeOfTile = 64;
            int borderSize = 64;
            int visualX = borderSize + xCoord * sizeOfTile;
            int visualY = borderSize + yCoord * sizeOfTile;
            return new Vector2(visualX, visualY);
        }
        public Vector2 rotateView(int xCoord, int yCoord)
        {
            int sizeOfTile = 64;
            int visualX = 512 - (xCoord * sizeOfTile);
            int visualY = 512 - (yCoord * sizeOfTile);
            return new Vector2(visualX, visualY);
        }
    }
}
