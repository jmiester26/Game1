using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Collections.Generic;
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
        Map[,] grid = new Map[10, 10];
        List<Map> maplist = new List<Map>();

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


            int[] X_Order = new int[122];
            int[] Y_Order = new int[122];

            X_Order[0] = 5;
            X_Order[1] = 6;
            X_Order[2] = 5;
            X_Order[3] = 4;

            X_Order[4] = 5;
            X_Order[5] = 6;
            X_Order[6] = 7;
            X_Order[7] = 6;
            X_Order[8] = 5;
            X_Order[9] = 4;
            X_Order[10] = 3;
            X_Order[11] = 4;

            X_Order[12] = 5;
            X_Order[13] = 6;
            X_Order[14] = 7;
            X_Order[15] = 8;
            X_Order[16] = 7;
            X_Order[17] = 6;
            X_Order[18] = 5;
            X_Order[19] = 4;
            X_Order[20] = 3;
            X_Order[21] = 2;
            X_Order[22] = 3;
            X_Order[23] = 4;

            X_Order[24] = 5;
            X_Order[25] = 6;
            X_Order[26] = 7;
            X_Order[27] = 8;
            X_Order[28] = 9;
            X_Order[29] = 8;
            X_Order[30] = 7;
            X_Order[31] = 6;
            X_Order[32] = 5;
            X_Order[33] = 4;
            X_Order[34] = 3;
            X_Order[35] = 2;
            X_Order[36] = 1;
            X_Order[37] = 2;
            X_Order[38] = 3;
            X_Order[39] = 4;
            
            X_Order[40] = 5;
            X_Order[41] = 6;
            X_Order[42] = 7;
            X_Order[43] = 8;
            X_Order[44] = 9;
            X_Order[45] = 10;
            X_Order[46] = 9;
            X_Order[47] = 8;
            X_Order[48] = 7;
            X_Order[49] = 6;
            X_Order[50] = 5;
            X_Order[51] = 4;
            X_Order[52] = 3;
            X_Order[53] = 2;
            X_Order[54] = 1;
            X_Order[55] = 0;
            X_Order[56] = 1;
            X_Order[57] = 2;
            X_Order[58] = 3;
            X_Order[59] = 4;

            X_Order[60] = 6;
            X_Order[61] = 7;
            X_Order[62] = 8;
            X_Order[63] = 9;
            X_Order[64] = 10;
            X_Order[65] = 10;
            X_Order[66] = 9;
            X_Order[67] = 8;
            X_Order[68] = 7;
            X_Order[69] = 6;
            X_Order[70] = 4;
            X_Order[71] = 3;
            X_Order[72] = 2;
            X_Order[73] = 1;
            X_Order[74] = 0;
            X_Order[75] = 0;
            X_Order[76] = 1;
            X_Order[77] = 2;
            X_Order[78] = 3;
            X_Order[79] = 4;

            X_Order[80] = 7;
            X_Order[81] = 8;
            X_Order[82] = 9;
            X_Order[83] = 10;
            X_Order[84] = 10;
            X_Order[85] = 9;
            X_Order[86] = 8;
            X_Order[87] = 7;
            X_Order[88] = 3;
            X_Order[89] = 2;
            X_Order[90] = 1;
            X_Order[91] = 0;
            X_Order[92] = 0;
            X_Order[93] = 1;
            X_Order[94] = 2;
            X_Order[95] = 3;

            X_Order[96] = 8;
            X_Order[97] = 9;
            X_Order[98] = 10;
            X_Order[99] = 10;
            X_Order[100] = 9;
            X_Order[101] = 8;
            X_Order[102] = 2;
            X_Order[103] = 1;
            X_Order[104] = 0;
            X_Order[105] = 0;
            X_Order[106] = 1;
            X_Order[107] = 2;

            X_Order[108] = 9;
            X_Order[109] = 10;
            X_Order[110] = 10;
            X_Order[111] = 9;
            X_Order[112] = 1;
            X_Order[113] = 0;
            X_Order[114] = 0;
            X_Order[115] = 1;

            X_Order[116] = 10;
            X_Order[117] = 10;
            X_Order[118] = 0;
            X_Order[119] = 0;





            Y_Order[0] = 4;
            Y_Order[1] = 5;
            Y_Order[2] = 6;
            Y_Order[3] = 5;

            Y_Order[4] = 3;
            Y_Order[5] = 4;
            Y_Order[6] = 5;
            Y_Order[7] = 6;
            Y_Order[8] = 7;
            Y_Order[9] = 6;
            Y_Order[10] = 5;
            Y_Order[11] = 4;

            Y_Order[12] = 2;
            Y_Order[13] = 3;
            Y_Order[14] = 4;
            Y_Order[15] = 5;
            Y_Order[16] = 6;
            Y_Order[17] = 7;
            Y_Order[18] = 8;
            Y_Order[19] = 7;
            Y_Order[20] = 6;
            Y_Order[21] = 5;
            Y_Order[22] = 4;
            Y_Order[23] = 3;

            Y_Order[24] = 1;
            Y_Order[25] = 2;
            Y_Order[26] = 3;
            Y_Order[27] = 4;
            Y_Order[28] = 5;
            Y_Order[29] = 6;
            Y_Order[30] = 7;
            Y_Order[31] = 8;
            Y_Order[32] = 6;
            Y_Order[33] = 8;
            Y_Order[34] = 7;
            Y_Order[35] = 6;
            Y_Order[36] = 5;
            Y_Order[37] = 4;
            Y_Order[38] = 3;
            Y_Order[39] = 2;

            Y_Order[40] = 0;
            Y_Order[41] = 1;
            Y_Order[42] = 2;
            Y_Order[43] = 3;
            Y_Order[44] = 4;
            Y_Order[45] = 5;
            Y_Order[46] = 6;
            Y_Order[47] = 7;
            Y_Order[48] = 8;
            Y_Order[49] = 9;
            Y_Order[50] = 10;
            Y_Order[51] = 9;
            Y_Order[52] = 8;
            Y_Order[53] = 7;
            Y_Order[54] = 6;
            Y_Order[55] = 5;
            Y_Order[56] = 4;
            Y_Order[57] = 3;
            Y_Order[58] = 2;
            Y_Order[59] = 1;

            Y_Order[60] = 0;
            Y_Order[61] = 1;
            Y_Order[62] = 2;
            Y_Order[63] = 3;
            Y_Order[64] = 4;
            Y_Order[65] = 6;
            Y_Order[66] = 7;
            Y_Order[67] = 8;
            Y_Order[68] = 9;
            Y_Order[69] = 10;
            Y_Order[70] = 10;
            Y_Order[71] = 9;
            Y_Order[72] = 8;
            Y_Order[73] = 7;
            Y_Order[74] = 6;
            Y_Order[75] = 4;
            Y_Order[76] = 3;
            Y_Order[77] = 2;
            Y_Order[78] = 1;
            Y_Order[79] = 0;

            Y_Order[80] = 0;
            Y_Order[81] = 1;
            Y_Order[82] = 2;
            Y_Order[83] = 3;
            Y_Order[84] = 7;
            Y_Order[85] = 8;
            Y_Order[86] = 9;
            Y_Order[87] = 10;
            Y_Order[88] = 10;
            Y_Order[89] = 9;
            Y_Order[90] = 8;
            Y_Order[91] = 7;
            Y_Order[92] = 3;
            Y_Order[93] = 2;
            Y_Order[94] = 1;
            Y_Order[95] = 0;

            Y_Order[96] = 0;
            Y_Order[97] = 1;
            Y_Order[98] = 2;
            Y_Order[99] = 8;
            Y_Order[100] = 9;
            Y_Order[101] = 10;
            Y_Order[102] = 10;
            Y_Order[103] = 9;
            Y_Order[104] = 8;
            Y_Order[105] = 2;
            Y_Order[106] = 1;
            Y_Order[107] = 0;

            Y_Order[108] = 0;
            Y_Order[109] = 1;
            Y_Order[110] = 9;
            Y_Order[111] = 10;
            Y_Order[112] = 10;
            Y_Order[113] = 9;
            Y_Order[114] = 1;
            Y_Order[115] = 0;

            Y_Order[116] = 0;
            Y_Order[117] = 10;
            Y_Order[118] = 10;
            Y_Order[119] = 0;


            bool[,] Connect_Top = new bool[11, 11];
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

            while (k < 119)

            {
                if (Connect_Top[X_Order[k], Y_Order[k]] is true)
                {
                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is true)
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                //add top right left bottom
                            }
                            else
                            {
                                //add top left bottom
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                //add top right bottom
                            }
                            else
                            {
                                maplist.Add(Bottom_Top); //top bottom
                            }
                        }
                    }
                    else
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                //add top right left
                            }
                            else
                            {
                                maplist.Add(Left_Top); //top left
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                maplist.Add(Right_Top); //add top right
                            }
                            else
                            {
                                //add top
                            }
                        }
                    }
                }
                else
                {
                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is true)
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                //add right left bottom
                            }
                            else
                            {
                                maplist.Add(Left_Bottom); //left bottom
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                maplist.Add(Right_Bottom); //right bottom
                            }
                            else
                            {
                                //add bottom
                            }
                        }
                    }
                    else
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                maplist.Add(Left_Right); //right left
                            }
                            else
                            {
                                //add left
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                //add right
                            }
                            else
                            {
                                //add blank
                            }
                        }
                    }
                }


                k = k + 1;

            }
            //loop end]
            Random r = new Random();
            grid[X_Order[k], Y_Order[k]] = maplist[r.Next(0, maplist.Count - 1)];


            //grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].Texture = Content.Load<Texture2D>("sprite");
            //viewportPosition = new Vector2(grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].X - 80, grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].Y - 80);

        }

            // TODO: use this.Content to load your game content here

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
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    grid[i, k].Draw(spriteBatch, new Rectangle(i * 176, k * 176, 176, 176), Vector2.Zero);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
