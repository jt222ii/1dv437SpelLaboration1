﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration1MV_transformationer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Lab1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //float scaleForGame;
        Texture2D whiteSquare;
        Texture2D blackSquare;
        Texture2D testSquare;
        Camera camera = new Camera();

        public Lab1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.ApplyChanges();
            graphics.PreferredBackBufferWidth = 632;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 632;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            createTileVisuals();
            //scaleForGame = camera.scaleToFit(graphics);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //blackSquare = Content.Load<Texture2D>("Blacksquare.png");
            //whiteSquare = Content.Load<Texture2D>("Whitesquare.png");
            testSquare = Content.Load<Texture2D>("tile00.png");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            int a = 0;
            for (int x = 0; x < 8; x+=1)
            {
                for (int y = 0; y < 8; y+=1)
                {
                    if (a % 2 == 0)
                    {
                        spriteBatch.Draw(whiteSquare, camera.getVisualCoords(x, y), Color.White);
                        //spriteBatch.Draw(whiteSquare, camera.rotateView(x, y), Color.White);       
                        //spriteBatch.Draw(whiteSquare, camera.getVisualCoords(x, y), null, Color.White, 0, new Vector2(0,0), scaleForGame, SpriteEffects.None, 0);
                    }
                    else
                    {
                        spriteBatch.Draw(blackSquare, camera.getVisualCoords(x, y), Color.White);
                        //spriteBatch.Draw(blackSquare, camera.rotateView(x, y), Color.White);
                        //spriteBatch.Draw(blackSquare, camera.getVisualCoords(x, y), null, Color.White, 0, new Vector2(0, 0), scaleForGame, SpriteEffects.None, 0);
                    }
                    a++;
                }
                a++;
            }
            //spriteBatch.Draw(testSquare, camera.getVisualCoords(0, 0), Color.White);
            //spriteBatch.Draw(testSquare, camera.rotateView(0, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        public void createTileVisuals()
        {
            int size = camera.sizeOfTile;
            this.whiteSquare = new Texture2D(graphics.GraphicsDevice, size, size);
            Color[] data = new Color[size * size];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.whiteSquare.SetData(data);

            this.blackSquare = new Texture2D(graphics.GraphicsDevice, size, size);
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            this.blackSquare.SetData(data);
        }
    }
}
