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
        private int visualX;
        private int visualY;
        public Vector2 getVisualCoords(int xCoord, int yCoord)
        {
            visualX = borderSize + xCoord * sizeOfTile;
            visualY = borderSize + yCoord * sizeOfTile;
            return new Vector2(visualX, visualY);
        }
        public Vector2 rotateView(int xCoord, int yCoord)
        {
            visualX = (sizeOfTile * 8 + borderSize - sizeOfTile) - (xCoord * sizeOfTile);
            visualY = (sizeOfTile * 8 + borderSize - sizeOfTile) - (yCoord * sizeOfTile);
            return new Vector2(visualX, visualY);
        }
    }
}
