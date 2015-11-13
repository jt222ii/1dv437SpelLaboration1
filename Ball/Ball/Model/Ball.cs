using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ball.Model
{
    class Ball
    {
        float _radius = 0.05f;
        Vector2 _speed = new Vector2(0.5f, 0.7f);
        Vector2 _position;
        public Ball()
        {
            _position = new Vector2(0.3f, 0.2f);
        }
        public float radius
        {
            get
            {
                return _radius;
            }
        }
        public Vector2 speed
        {
            get
            {
                return _speed;
            }
        }
        public Vector2 position
        {
            get
            {
                return _position;
            }
        }
        public void setNewPos(float newPosX, float newPosY)
        {
            _position.X = newPosX;
            _position.Y = newPosY;
        }

        public void setNewSpeedX()
        {
            _speed.X = -speed.X;
        }
        public void setNewSpeedY()
        {
            _speed.Y = -speed.Y;
        }
    }
}
