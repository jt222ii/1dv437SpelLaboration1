using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ball.View
{
    class Camera
    {
        private int _sizeOfField;
        private int _borderSize = 64;
        GraphicsDeviceManager graphics;
        public Camera(GraphicsDeviceManager Graphics)
        {
            graphics = Graphics;
        }
        public void setSizeOfEverything()
        {
            int windowSizeX = graphics.GraphicsDevice.Viewport.Width;
            int windowSizeY = graphics.GraphicsDevice.Viewport.Height;
            if(windowSizeX < windowSizeY)
            {
                sizeOfField = windowSizeX;
            }
            else
            {
                sizeOfField = windowSizeY;
            }
            borderSize = Convert.ToInt32(Math.Round(sizeOfField * 0.05f));
            sizeOfField -= borderSize*2;
        }

        public Vector2 convertToVisualCoords(double x, double y)
        {
            int visualX = Convert.ToInt32(Math.Round(x * sizeOfField + borderSize));
            int visualY = Convert.ToInt32(Math.Round(y * sizeOfField + borderSize));
            return new Vector2(visualX, visualY);

        }
        public int borderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; }
        }
        public int sizeOfField
        {
            get { return _sizeOfField; }
            set { _sizeOfField = value; }
        }
        public float ballScale(int width, float ballRadius)
        {
            return sizeOfField * 2 * ballRadius / (float)width;
        }
    }
}
