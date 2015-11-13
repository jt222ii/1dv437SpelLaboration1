using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ball.Model
{
    class BallSimulation
    {
        Ball ball = new Ball();
        public float getBallRadius()
        {
            return ball.radius;
        }
        public Vector2 getPosition()
        {
            return ball.position;
        }

        public void moveBall(float totalSecs)
        {
            ballCollision();
            ball.setNewPos(ball.position.X + ball.speed.X * totalSecs, ball.position.Y + ball.speed.Y * totalSecs);
        }

        public void ballCollision()
        {
            if (ball.position.X <= 0 + ball.radius || ball.position.X >= 1 - ball.radius)
            {
                ball.setNewSpeedX();
            }
            if (ball.position.Y <= 0 + ball.radius || ball.position.Y >= 1 - ball.radius)
            {
                ball.setNewSpeedY();
            }
        }
    }
}
