using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration1MV_transformationer
{
    class Camera
    {
        public int sizeOfTile = 64;
        private int borderSize = 64;
        private int visualX;
        private int visualY;
        public float scale;
        
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

        //med hjälp av https://msdn.microsoft.com/en-us/library/bb447674.aspx
        public void scaleTileAndBorderToFit(GraphicsDeviceManager graphics) //rescales border and sizeoftile depending on the screen size
        {
            float scaleX = (float)graphics.GraphicsDevice.Viewport.Width / (sizeOfTile * 8 + borderSize * 2);
            float scaleY = (float)graphics.GraphicsDevice.Viewport.Height / (sizeOfTile * 8 + borderSize * 2);
            if(scaleX < scaleY)
            {
                scale = scaleX;
            }
            else
            {
                scale = scaleY;
            }
            sizeOfTile = Convert.ToInt32(Math.Round(sizeOfTile * scale));
            borderSize = Convert.ToInt32(Math.Round(borderSize * scale));
        }
    }
}
