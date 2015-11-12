﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ball.Model
{
    class BallSimulation
    {
        Ball ball = new Ball();
        public BallSimulation()
        {

        }
        public float getBallRadius()
        {
            return ball.radius;
        }
        public Vector2 getPosition()
        {
            return ball.position;
        }

        public void moveBall(float deltaTime)
        {
            ball.setNewPos(ball.position.X + ball.speed.X * deltaTime, ball.position.Y + ball.speed.Y * deltaTime);
        }

        public void ballCollision()
        {

        }
    }
}
