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
        private Camera camera;
        private BallSimulation ballSimulation;
        private GraphicsDeviceManager _graphics;
        public BallView(GraphicsDeviceManager graphics, BallSimulation BallSimulation)
        {
            _graphics = graphics;
            camera = new Camera(graphics);
            ballSimulation = BallSimulation;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            spriteBatch.Begin();
            camera.setSizeOfEverything();

            //
            int sizeOfField = camera.sizeOfField;
            int borderSize = camera.borderSize;
            Rectangle rect = new Rectangle(borderSize, borderSize, sizeOfField, sizeOfField);
            Texture2D background = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            background.SetData(new Color[] { Color.Tomato });
            spriteBatch.Draw(background, rect, Color.White);

           
            Texture2D ball = Content.Load<Texture2D>("aqua-ball.png");
            var ballCenter = new Vector2(ball.Width / 2, ball.Height / 2);
            Vector2 ballLogicalLocation = ballSimulation.getPosition();
            var ballVisualLocation = camera.convertToVisualCoords(ballLogicalLocation.X, ballLogicalLocation.Y);
            float scale = camera.ballScale(ball.Width, ballSimulation.getBallRadius());
            spriteBatch.Draw(ball, ballVisualLocation, null, Color.White, 0, ballCenter, scale, SpriteEffects.None, 0);
            spriteBatch.End();
            
        }
    }
}
