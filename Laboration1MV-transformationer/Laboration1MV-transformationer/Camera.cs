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
        private float visualX;
        private float visualY;
        public float scale = 1; //sätter den till 100% som standard
        
        public Vector2 getWhiteVisualCoords(int xCoord, int yCoord)
        {
            //Logisk koordinat |Visuell koordinat
            //0,0              | 64, 64
            //7,0              | 512, 64
            //1,7              | 128, 512
            //7,7              | 512, 512
            visualX = (borderSize + xCoord * sizeOfTile) * scale;
            visualY = (borderSize + yCoord * sizeOfTile) * scale;
            return new Vector2(visualX, visualY);
        }
        public Vector2 getBlackVisualCoords(int xCoord, int yCoord)
        {   
            //Logisk koordinat | Visuell koordinat
            //0,0              | 512,512
            //6,0              | 128,512
            //2,7              | 384,64
            //7,7              | 64,64
            visualX = ((sizeOfTile * 8 + borderSize - sizeOfTile) - (xCoord * sizeOfTile)) * scale;
            visualY = ((sizeOfTile * 8 + borderSize - sizeOfTile) - (yCoord * sizeOfTile)) * scale;
            return new Vector2(visualX, visualY);
        }

        //med hjälp av https://msdn.microsoft.com/en-us/library/bb447674.aspx
        public void setScale(GraphicsDeviceManager graphics) //sets the scale
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
        }
    }
}
