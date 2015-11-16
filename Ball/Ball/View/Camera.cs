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
        private int _borderSize = 32;
        GraphicsDeviceManager graphics;
        public Camera(GraphicsDeviceManager Graphics)
        {
            graphics = Graphics;
        }
        public void setSizeOfField()
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
            sizeOfField -= borderSize*2;
        }

        public Vector2 convertToVisualCoords(float x, float y)
        {
            float visualX = x * sizeOfField + borderSize;
            float visualY = y * sizeOfField + borderSize;
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

        public Rectangle getRect()
        {
            return new Rectangle(borderSize, borderSize, sizeOfField, sizeOfField);
        }
    }
}
