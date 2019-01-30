using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Squared.Tiled;
using System.Timers;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 viewportPosition;
        Map map;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public bool CheckBounds()
        {
            bool check = false;

            Rectangle playrec = new Rectangle(
                map.ObjectGroups["Objects"].Objects["Player"].X,
                map.ObjectGroups["Objects"].Objects["Player"].Y,
                map.ObjectGroups["Objects"].Objects["Player"].Width,
                map.ObjectGroups["Objects"].Objects["Player"].Height
                );

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    if (collision.GetTile(x, y) != 0)
                    {
                        Rectangle tile = new Rectangle(
                            (int)x * tilepixel,
                            (int)y * tilepixel,
                            tilepixel,
                            tilepixel
                            );

                        if (playrec.Intersects(tile))
                            check = true;
                    }
                }
            }

            return check;
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = Map.Load(Path.Combine(Content.RootDirectory, "center.tmx"), Content);
            map.ObjectGroups["4Events"].Objects["Spawn"].Texture = Content.Load<Texture2D>("sprite");
            viewportPosition = new Vector2(map.ObjectGroups["4Events"].Objects["Spawn"].X - 80, map.ObjectGroups["4Events"].Objects["Spawn"].Y - 80);

            // TODO: use this.Content to load your game content here
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
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyState = Keyboard.GetState();
            float scrollx = 0, scrolly = 0;
            Timer t = new Timer(1000);



            if (keyState.IsKeyDown(Keys.Left))
                scrollx = -1;
            if (keyState.IsKeyDown(Keys.Right))
                scrollx = 1;
            if (keyState.IsKeyDown(Keys.Up))
                scrolly = 1;
            if (keyState.IsKeyDown(Keys.Down))
                scrolly = -1;


            if (keyState.IsKeyDown(Keys.Enter))
            {
                bool action = true;
            }
            else
            {
                bool action = false;
            }


            if (action == true)
            {
                scrollx += gamePadState.ThumbSticks.Left.X;
                scrolly += gamePadState.ThumbSticks.Left.Y;


                float scrollSpeed = 4.0f;


                map.ObjectGroups["4Events"].Objects["Spawn"].X += (int)(scrollx * scrollSpeed);
                map.ObjectGroups["4Events"].Objects["Spawn"].Y -= (int)(scrolly * scrollSpeed);

                action = false;
            }
            

            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            map.Draw(spriteBatch, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), viewportPosition);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
