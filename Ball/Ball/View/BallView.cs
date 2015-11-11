using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Ball.View
{
    class BallView
    {
        private SpriteBatch spriteBatch;
        private Camera camera;
        private GraphicsDeviceManager _graphics;
        public BallView(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            camera = new Camera(graphics);
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
            background.SetData(new Color[] { Color.Pink });
            spriteBatch.Draw(background, rect, Color.White);

           
            Texture2D ball = Content.Load<Texture2D>("ball_green.png");
            var ballCenter = new Vector2(ball.Width / 2, ball.Height / 2);
            var ballLocation = camera.convertToVisualCoords(0.5, 0.5);
            float scale = camera.ballScale(ball.Width);
            spriteBatch.Draw(ball, ballLocation, null, Color.White, 0, ballCenter, scale, SpriteEffects.None, 0);
            spriteBatch.End();
            
        }
    }
}
