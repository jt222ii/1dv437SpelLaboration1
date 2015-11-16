using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Ball.Model;

namespace Ball.View
{
    class BallView
    {
        private Camera _camera;
        private BallSimulation _ballSimulation;
        private Texture2D _ball;
        private Rectangle _rect;
        private Texture2D _background;
        private Vector2 _ballCenter;

        public BallView(GraphicsDeviceManager graphics, BallSimulation BallSimulation, Texture2D ball)
        {
            _camera = new Camera(graphics);
            _ballSimulation = BallSimulation;
            _ball = ball;
            _ballCenter = new Vector2(_ball.Width / 2, _ball.Height / 2);

            _camera.setSizeOfEverything();
            _rect = _camera.getRect();
            _background = new Texture2D(graphics.GraphicsDevice, 1, 1);
            _background.SetData(new Color[] { Color.Tomato });

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, _rect, Color.White);
            Vector2 ballLogicalLocation = _ballSimulation.getPosition();
            var ballVisualLocation = _camera.convertToVisualCoords(ballLogicalLocation.X, ballLogicalLocation.Y);
            float scale = _camera.ballScale(_ball.Width, _ballSimulation.getBallRadius());
            spriteBatch.Draw(_ball, ballVisualLocation, null, Color.White, 0, _ballCenter, scale, SpriteEffects.None, 0);

            spriteBatch.End();
            
        }
    }
}
