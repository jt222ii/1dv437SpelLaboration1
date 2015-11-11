using Microsoft.Xna.Framework;
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
        Texture2D whiteSquare;
        Texture2D blackSquare;
        Texture2D testSquare;
        Camera camera = new Camera();

        public Lab1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 200;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 200;   // set this value to the desired height of your window
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
           
            createTilesVisuals();
            camera.scaleTileAndBorderToFit(graphics);//scales the size of the tiles and borders depending on the window size
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
                        spriteBatch.Draw(whiteSquare, camera.getVisualCoords(x, y), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                    }
                    else
                    {
                        spriteBatch.Draw(blackSquare, camera.getVisualCoords(x, y), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                    }
                    a++;
                }
                a++;
            }
            //test
            spriteBatch.Draw(testSquare, camera.getVisualCoords(1, 3), null, Color.White, 0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
            //slut på test
            spriteBatch.End();

            base.Draw(gameTime);
        }
        public void createTilesVisuals()
        {
            int size = camera.sizeOfTile;
            Color[] data = new Color[size * size];

            this.whiteSquare = new Texture2D(graphics.GraphicsDevice, size, size);
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.whiteSquare.SetData(data);

            this.blackSquare = new Texture2D(graphics.GraphicsDevice, size, size);
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            this.blackSquare.SetData(data);

            //Använder för att testa att måla ut den på vissa koordinater
            this.testSquare = Content.Load<Texture2D>("tile00.png");
            //this.testSquare = new Texture2D(graphics.GraphicsDevice, size, size);
            //for (int i = 0; i < data.Length; ++i) data[i] = Color.Blue;
            //this.testSquare.SetData(data);
        }
    }
}
