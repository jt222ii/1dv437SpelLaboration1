using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ball.View
{
    class Camera
    {
        private int _sizeOfField;
        private int _borderSize;
        private int _ballDiameter;
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
            ballDiameter = Convert.ToInt32(Math.Round(sizeOfField * 0.1f));
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
        public int ballDiameter
        {
            get { return _ballDiameter; }
            set { _ballDiameter = value; }
        }
        public float ballScale(int width)
        {
            return (float)ballDiameter / (float)width;
        }
    }
}
