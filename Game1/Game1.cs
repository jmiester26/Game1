using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Squared.Tiled;
using System.Timers;
using System;

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
        Map Center, Left_Bottom, Bottom_Top, Left_Right, Left_Top, Right_Bottom, Right_Top, map;
        Map[,] grid = new Map[11, 11];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Center = Map.Load(Path.Combine(Content.RootDirectory, "Center.tmx"), Content);
            Left_Bottom = Map.Load(Path.Combine(Content.RootDirectory, "Left_Bottom.tmx"), Content);
            Bottom_Top = Map.Load(Path.Combine(Content.RootDirectory, "Bottom_Top.tmx"), Content);
            Left_Right = Map.Load(Path.Combine(Content.RootDirectory, "Left_Right.tmx"), Content);
            Left_Top = Map.Load(Path.Combine(Content.RootDirectory, "Left_Top.tmx"), Content);
            Right_Bottom = Map.Load(Path.Combine(Content.RootDirectory, "Right_Bottom.tmx"), Content);
            Right_Top = Map.Load(Path.Combine(Content.RootDirectory, "Right_Top.tmx"), Content);

            int a = 6;
            int b = 6;

            Map[] Down = new Map[4];
            Map[] Right = new Map[4];
            Map[] Up = new Map[4];
            Map[] Left = new Map[4];

            Down[1] = Left_Bottom;
            Down[2] = Bottom_Top;
            Down[3] = Right_Bottom;

            Right[1] = Left_Right;
            Right[2] = Right_Bottom;
            Right[3] = Right_Top;

            Up[1] = Left_Top;
            Up[2] = Bottom_Top;
            Up[3] = Right_Top;

            Left[1] = Left_Bottom;
            Left[2] = Left_Right;
            Left[3] = Left_Top;


            int[] X_Order = new int[122] ;
            int[] Y_Order = new int[122];


            X_Order[1] = 6;
            X_Order[2] = 7;
            X_Order[3] = 6;
            X_Order[4] = 5;

            X_Order[5] = 6;
            X_Order[6] = 7;
            X_Order[7] = 8;
            X_Order[8] = 7;
            X_Order[9] = 6;
            X_Order[10] = 5;
            X_Order[11] = 4;
            X_Order[12] = 5;

            X_Order[13] = 6;
            X_Order[14] = 7;
            X_Order[15] = 8;
            X_Order[16] = 9;
            X_Order[17] = 8;
            X_Order[18] = 7;
            X_Order[19] = 6;
            X_Order[20] = 5;
            X_Order[21] = 4;
            X_Order[22] = 3;
            X_Order[23] = 4;
            X_Order[24] = 5;

            X_Order[25] = 6;
            X_Order[26] = 7;
            X_Order[27] = 8;
            X_Order[28] = 9;
            X_Order[29] = 10;
            X_Order[30] = 9;
            X_Order[31] = 8;
            X_Order[32] = 7;
            X_Order[33] = 6;
            X_Order[34] = 5;
            X_Order[35] = 4;
            X_Order[36] = 3;
            X_Order[37] = 2;
            X_Order[38] = 3;
            X_Order[39] = 4;
            X_Order[40] = 5;

            X_Order[41] = 6;
            X_Order[42] = 7;
            X_Order[43] = 8;
            X_Order[44] = 9;
            X_Order[45] = 10;
            X_Order[46] = 11;
            X_Order[47] = 10;
            X_Order[48] = 9;
            X_Order[49] = 8;
            X_Order[50] = 7;
            X_Order[51] = 6;
            X_Order[52] = 5;
            X_Order[53] = 4;
            X_Order[54] = 3;
            X_Order[55] = 2;
            X_Order[56] = 1;
            X_Order[57] = 2;
            X_Order[58] = 3;
            X_Order[59] = 4;
            X_Order[60] = 5;





            Y_Order[1] = 7;
            Y_Order[2] = 6;
            Y_Order[3] = 5;
            Y_Order[4] = 6;

            Y_Order[5] = 7;
            Y_Order[6] = 8;
            Y_Order[7] = 7;
            Y_Order[8] = 6;
            Y_Order[9] = 5;
            Y_Order[10] = 4;
            Y_Order[11] = 5;
            Y_Order[12] = 6;

            Y_Order[13] = 7;
            Y_Order[14] = 8;
            Y_Order[15] = 9;
            Y_Order[16] = 8;
            Y_Order[17] = 7;
            Y_Order[18] = 6;
            Y_Order[19] = 5;
            Y_Order[20] = 4;
            Y_Order[21] = 3;
            Y_Order[22] = 4;
            Y_Order[23] = 5;
            Y_Order[24] = 6;

            Y_Order[25] = 7;
            Y_Order[26] = 8;
            Y_Order[27] = 9;
            Y_Order[28] = 10;
            Y_Order[29] = 9;
            Y_Order[30] = 8;
            Y_Order[31] = 7;
            Y_Order[32] = 6;
            Y_Order[33] = 5;
            Y_Order[34] = 4;
            Y_Order[35] = 3;
            Y_Order[36] = 2;
            Y_Order[37] = 3;
            Y_Order[38] = 4;
            Y_Order[39] = 5;
            Y_Order[40] = 6;

            Y_Order[41] = 7;
            Y_Order[42] = 8;
            Y_Order[43] = 9;
            Y_Order[44] = 10;
            Y_Order[45] = 11;
            Y_Order[46] = 10;
            Y_Order[47] = 9;
            Y_Order[48] = 8;
            Y_Order[49] = 7;
            Y_Order[50] = 6;
            Y_Order[51] = 5;
            Y_Order[52] = 4;
            Y_Order[53] = 3;
            Y_Order[54] = 2;
            Y_Order[55] = 1;
            Y_Order[56] = 2;
            Y_Order[57] = 3;
            Y_Order[58] = 4;
            Y_Order[59] = 5;
            Y_Order[60] = 6;

            
            bool[,] Connect_Top = new bool [11, 11];
            bool[,] Connect_Right = new bool[11, 11];
            bool[,] Connect_Left = new bool[11, 11];
            bool[,] Connect_Bottom = new bool[11, 11];
            grid[6, 6] = Center;


            Connect_Top[a, b] = Convert.ToBoolean(grid[a, b].Properties["Connect_Top"]);
            Connect_Right[a, b] = Convert.ToBoolean(grid[a, b].Properties["Connect_Right"]);
            Connect_Bottom[a, b] = Convert.ToBoolean(grid[a, b].Properties["Connect_Bottom"]);
            Connect_Left[a, b] = Convert.ToBoolean(grid[a, b].Properties["Connect_Left"]);

            Connect_Top[5, 5] = true;
            Connect_Right[5, 5] = true;
            Connect_Bottom[5, 5] = true;
            Connect_Left[5, 5] = true;


            int k = 1;

            //-----------------------------------------------------------------------------------

            while (k < 122)

            {

                if (Connect_Bottom[X_Order[k]-1, Y_Order[k + 1]-1] is true)
                    Connect_Top[X_Order[k]-1, Y_Order[k] - 1] = true;



                if (Connect_Top[X_Order[k] - 1, Y_Order[k - 1] - 1] is true)
                    Connect_Bottom[X_Order[k] - 1, Y_Order[k] - 1] = true;




                if (Connect_Left[X_Order[k] - 1, Y_Order[k] - 1] is true)
                    Connect_Right[X_Order[k - 1] - 1, Y_Order[k] - 1] = true;




                if (Connect_Right[X_Order[k] - 1, Y_Order[k] - 1] is true)
                    Connect_Left[X_Order[k + 1] - 1, Y_Order[k] - 1] = true;


                //---------------------------------------------------------------------------------------------------


                if (Connect_Top[X_Order[k], Y_Order[k]] is true)
                {
                    foreach (Map m in Up)
                    {
                        foreach (Map n in Down)
                        {
                            if (m == n)
                            {
                                grid[X_Order[k], Y_Order[k]] = m;
                                goto loopend;
                            }
                        }
                        foreach (Map n in Right)
                        {
                            if (m == n)
                            {
                                grid[X_Order[k], Y_Order[k]] = m;
                                goto loopend;
                            }
                        }
                        foreach (Map n in Left)
                        {
                            if (m == n)
                            {
                                grid[X_Order[k], Y_Order[k]] = m;
                                goto loopend;
                            }
                        }
                    }
                }
                //-----------------------------------------------------------------------------
                if (Connect_Bottom[X_Order[k], Y_Order[k]] is true)
                {
                    foreach (Map m in Down)
                    {
                        foreach (Map n in Left)
                        {
                            if (m == n)
                            {
                                grid[X_Order[k], Y_Order[k]] = m;
                                goto loopend;
                            }
                        }
                        foreach (Map n in Right)
                        {
                            if (m == n)
                            {
                                grid[X_Order[k], Y_Order[k]] = m;
                                goto loopend;
                            }
                        }
                    }
                }
                //-------------------------------------------------------------------------------
                if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                {
                    foreach (Map m in Left)
                    {
                        foreach (Map n in Right)
                        {
                            if (m == n)
                            {
                                grid[X_Order[k], Y_Order[k]] = m;
                                goto loopend;
                            }
                        }
                    }
                }

                loopend:;

                k = k + 1;

            }
            //loop end]

            grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].Texture = Content.Load<Texture2D>("sprite");
            viewportPosition = new Vector2(grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].X - 80, grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].Y - 80);



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

         //   bool action = true;

         //   if (keyState.IsKeyDown(Keys.Enter))
         //   {
         //      action = false;
         //       scrollx += gamePadState.ThumbSticks.Left.X;
         //       scrolly += gamePadState.ThumbSticks.Left.Y;
         //
                if (gamePadState.IsButtonDown(Buttons.Back) || keyState.IsKeyDown(Keys.Escape))
                    this.Exit();

         //       float scrollSpeed = 4.0f;


         //       map.ObjectGroups["Events"].Objects["Spawn"].X += (int)(scrollx * scrollSpeed);
         //       map.ObjectGroups["Events"].Objects["Spawn"].Y -= (int)(scrolly * scrollSpeed);



            

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
            for (int i = 0; i < 11; i++)
            {
                for (int k = 0; k < 11; k++)
                {
                    grid[i,k].Draw(spriteBatch, new Rectangle(i*176, k*176,176,176),Vector2.Zero);
                }
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}