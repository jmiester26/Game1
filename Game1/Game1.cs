﻿using Microsoft.Xna.Framework;
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
        Map Center, Left_Bottom, Bottom_Top, Left_Right, Left_Top, Right_Bottom, Right_Top, All, Bottom, Left1, Top, Right1, Left_Bottom_Right, Left_Bottom_Top, Right_Top_Bottom, Right_Top_Left, map;
        Map[,] grid = new Map[13, 13];
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
            All = Map.Load(Path.Combine(Content.RootDirectory, "All.tmx"), Content);
            Right1 = Map.Load(Path.Combine(Content.RootDirectory, "Right.tmx"), Content);
            Left1 = Map.Load(Path.Combine(Content.RootDirectory, "Left.tmx"), Content);
            Top = Map.Load(Path.Combine(Content.RootDirectory, "Top.tmx"), Content);
            Bottom = Map.Load(Path.Combine(Content.RootDirectory, "Bottom.tmx"), Content);
            Left_Bottom_Right = Map.Load(Path.Combine(Content.RootDirectory, "Left_Bottom_Right.tmx"), Content);
            Left_Bottom_Top = Map.Load(Path.Combine(Content.RootDirectory, "Left_Bottom_Top.tmx"), Content);
            Right_Top_Bottom = Map.Load(Path.Combine(Content.RootDirectory, "Right_Top_Bottom.tmx"), Content);
            Right_Top_Left = Map.Load(Path.Combine(Content.RootDirectory, "Right_Top_Left.tmx"), Content);

            List<Map> Down = new List<Map>();
            List<Map> Right = new List<Map>();
            List<Map> Up = new List<Map>();
            List<Map> Left = new List<Map>();

            Down.Add(All);
            Down.Add(Left_Bottom);
            Down.Add(Bottom_Top);
            Down.Add(Right_Bottom);
            Down.Add(Left_Bottom_Top);
            Down.Add(Left_Bottom_Right);
            Down.Add(Right_Top_Bottom);

            Right.Add(All);
            Right.Add(Left_Right);
            Right.Add(Right_Bottom);
            Right.Add(Right_Top);
            Right.Add(Right_Top_Bottom);
            Right.Add(Left_Bottom_Right);
            Right.Add(Right_Top_Bottom);
            Right.Add(Right_Top_Left);

            Up.Add(All);
            Up.Add(Left_Top);
            Up.Add(Bottom_Top);
            Up.Add(Right_Top);
            Up.Add(Left_Bottom_Top);
            Up.Add(Right_Top_Bottom);
            Up.Add(Right_Top_Left);

            Left.Add(All);
            Left.Add(Left_Bottom);
            Left.Add(Left_Right);
            Left.Add(Left_Top);
            Left.Add(Left_Bottom_Right);
            Left.Add(Left_Bottom_Top);
            Left.Add(Right_Top_Left);

            int[] X_Order = new int[120];
            int[] Y_Order = new int[120];

            X_Order[0] = 6;
            X_Order[1] = 7;
            X_Order[2] = 6;
            X_Order[3] = 5;

            X_Order[4] = 6;
            X_Order[5] = 7;
            X_Order[6] = 8;
            X_Order[7] = 7;
            X_Order[8] = 6;
            X_Order[9] = 5;
            X_Order[10] = 4;
            X_Order[11] = 5;

            X_Order[12] = 6;
            X_Order[13] = 7;
            X_Order[14] = 8;
            X_Order[15] = 9;
            X_Order[16] = 8;
            X_Order[17] = 7;
            X_Order[18] = 6;
            X_Order[19] = 5;
            X_Order[20] = 4;
            X_Order[21] = 3;
            X_Order[22] = 4;
            X_Order[23] = 5;

            X_Order[24] = 6;
            X_Order[25] = 7;
            X_Order[26] = 8;
            X_Order[27] = 9;
            X_Order[28] = 10;
            X_Order[29] = 9;
            X_Order[30] = 8;
            X_Order[31] = 7;
            X_Order[32] = 6;
            X_Order[33] = 5;
            X_Order[34] = 4;
            X_Order[35] = 3;
            X_Order[36] = 2;
            X_Order[37] = 3;
            X_Order[38] = 4;
            X_Order[39] = 5;
            
            X_Order[40] = 6;
            X_Order[41] = 7;
            X_Order[42] = 8;
            X_Order[43] = 9;
            X_Order[44] = 10;
            X_Order[45] = 11;
            X_Order[46] = 10;
            X_Order[47] = 9;
            X_Order[48] = 8;
            X_Order[49] = 7;
            X_Order[50] = 6;
            X_Order[51] = 5;
            X_Order[52] = 4;
            X_Order[53] = 3;
            X_Order[54] = 2;
            X_Order[55] = 1;
            X_Order[56] = 2;
            X_Order[57] = 3;
            X_Order[58] = 4;
            X_Order[59] = 5;

            X_Order[60] = 7;
            X_Order[61] = 8;
            X_Order[62] = 9;
            X_Order[63] = 10;
            X_Order[64] = 11;
            X_Order[65] = 11;
            X_Order[66] = 10;
            X_Order[67] = 9;
            X_Order[68] = 8;
            X_Order[69] = 7;
            X_Order[70] = 5;
            X_Order[71] = 4;
            X_Order[72] = 3;
            X_Order[73] = 2;
            X_Order[74] = 1;
            X_Order[75] = 1;
            X_Order[76] = 2;
            X_Order[77] = 3;
            X_Order[78] = 4;
            X_Order[79] = 5;

            X_Order[80] = 8;
            X_Order[81] = 9;
            X_Order[82] = 10;
            X_Order[83] = 11;
            X_Order[84] = 11;
            X_Order[85] = 10;
            X_Order[86] = 9;
            X_Order[87] = 8;
            X_Order[88] = 4;
            X_Order[89] = 3;
            X_Order[90] = 2;
            X_Order[91] = 1;
            X_Order[92] = 1;
            X_Order[93] = 2;
            X_Order[94] = 3;
            X_Order[95] = 4;

            X_Order[96] = 9;
            X_Order[97] = 10;
            X_Order[98] = 11;
            X_Order[99] = 11;
            X_Order[100] = 10;
            X_Order[101] = 9;
            X_Order[102] = 3;
            X_Order[103] = 2;
            X_Order[104] = 1;
            X_Order[105] = 1;
            X_Order[106] = 2;
            X_Order[107] = 3;

            X_Order[108] = 10;
            X_Order[109] = 11;
            X_Order[110] = 11;
            X_Order[111] = 10;
            X_Order[112] = 2;
            X_Order[113] = 1;
            X_Order[114] = 1;
            X_Order[115] = 2;

            X_Order[116] = 11;
            X_Order[117] = 11;
            X_Order[118] = 1;
            X_Order[119] = 1;





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

            Y_Order[40] = 1;
            Y_Order[41] = 2;
            Y_Order[42] = 3;
            Y_Order[43] = 4;
            Y_Order[44] = 5;
            Y_Order[45] = 6;
            Y_Order[46] = 7;
            Y_Order[47] = 8;
            Y_Order[48] = 9;
            Y_Order[49] = 10;
            Y_Order[50] = 11;
            Y_Order[51] = 10;
            Y_Order[52] = 9;
            Y_Order[53] = 8;
            Y_Order[54] = 7;
            Y_Order[55] = 6;
            Y_Order[56] = 5;
            Y_Order[57] = 4;
            Y_Order[58] = 3;
            Y_Order[59] = 2;

            Y_Order[60] = 1;
            Y_Order[61] = 2;
            Y_Order[62] = 3;
            Y_Order[63] = 4;
            Y_Order[64] = 5;
            Y_Order[65] = 7;
            Y_Order[66] = 8;
            Y_Order[67] = 9;
            Y_Order[68] = 10;
            Y_Order[69] = 11;
            Y_Order[70] = 11;
            Y_Order[71] = 10;
            Y_Order[72] = 9;
            Y_Order[73] = 8;
            Y_Order[74] = 7;
            Y_Order[75] = 5;
            Y_Order[76] = 4;
            Y_Order[77] = 3;
            Y_Order[78] = 2;
            Y_Order[79] = 1;

            Y_Order[80] = 1;
            Y_Order[81] = 2;
            Y_Order[82] = 3;
            Y_Order[83] = 4;
            Y_Order[84] = 8;
            Y_Order[85] = 9;
            Y_Order[86] = 10;
            Y_Order[87] = 11;
            Y_Order[88] = 11;
            Y_Order[89] = 10;
            Y_Order[90] = 9;
            Y_Order[91] = 8;
            Y_Order[92] = 4;
            Y_Order[93] = 3;
            Y_Order[94] = 2;
            Y_Order[95] = 1;

            Y_Order[96] = 1;
            Y_Order[97] = 2;
            Y_Order[98] = 3;
            Y_Order[99] = 9;
            Y_Order[100] = 10;
            Y_Order[101] = 11;
            Y_Order[102] = 11;
            Y_Order[103] = 10;
            Y_Order[104] = 9;
            Y_Order[105] = 3;
            Y_Order[106] = 2;
            Y_Order[107] = 1;

            Y_Order[108] = 1;
            Y_Order[109] = 2;
            Y_Order[110] = 10;
            Y_Order[111] = 11;
            Y_Order[112] = 11;
            Y_Order[113] = 10;
            Y_Order[114] = 2;
            Y_Order[115] = 1;

            Y_Order[116] = 1;
            Y_Order[117] = 11;
            Y_Order[118] = 11;
            Y_Order[119] = 1;


            bool[,] Connect_Top = new bool[13, 13];
            bool[,] Connect_Right = new bool[13, 13];
            bool[,] Connect_Left = new bool[13, 13];
            bool[,] Connect_Bottom = new bool[13, 13];

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Connect_Bottom[i, j] = false;
                    Connect_Top[i, j] = false;
                    Connect_Left[i, j] = false;
                    Connect_Right[i, j] = false;
                }
            }

            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 12; j++)
                {
                    Connect_Bottom[i, j] = true;
                    Connect_Top[i, j] = true;
                    Connect_Left[i, j] = true;
                    Connect_Right[i, j] = true;
                }
            }


            int k = 1;

            // set k to 0, give X ord and Y ord 0 values nad 12 values

            //-----------------------------------------------------------------------------------

            while (k < 119)

            {
                if (Connect_Bottom[X_Order[k], Y_Order[k] ] is false)
                    Connect_Top[X_Order[k], Y_Order[k] - 1] = false;



                if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                    Connect_Bottom[X_Order[k], Y_Order[k] + 1] = false;




                if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                    Connect_Right[X_Order[k] - 1, Y_Order[k]] = false;




                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                    Connect_Left[X_Order[k] + 1, Y_Order[k]] = false;

                //-------------------------------------------------------------------------------------------

                if (Connect_Top[X_Order[k], Y_Order[k]] is true)
                {
                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is true)
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                maplist.Add(All); //add top right left bottom
                            }
                            else
                            {
                                maplist.Add(Left_Bottom_Top);//add top left bottom
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                maplist.Add(Right_Top_Bottom); //add top right bottom
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
                                maplist.Add(Right_Top_Left); //add top right left
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
                                maplist.Add(Top);//add top
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
                                maplist.Add(Left_Bottom_Right); //add right left bottom
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
                                maplist.Add(Bottom); //add bottom
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
                                maplist.Add(Left1); //add left
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                maplist.Add(Right1); //add right
                            }
                            else
                            {
                                //add blank
                            }
                        }
                    }
                }

                Console.WriteLine(maplist.Count);
                //-------------------------------------------------------------------------
                Random r = new Random();
                if (maplist.Count > 1)
                {
                    grid[X_Order[k], Y_Order[k]] = maplist[r.Next(0, maplist.Count - 1)];
                }
                else
                {
                    Console.WriteLine(maplist.Count);
                    grid[X_Order[k], Y_Order[k]] = maplist[0];
                }
                //-------------------------------------------------------------------------
                if (!Down.Contains(grid[X_Order[k], Y_Order[k]]))
                {
                    Connect_Bottom[X_Order[k], Y_Order[k]] = false;
                }
                if (!Up.Contains(grid[X_Order[k], Y_Order[k]]))
                {
                    Connect_Top[X_Order[k], Y_Order[k]] = false;
                }
                if (!Left.Contains(grid[X_Order[k], Y_Order[k]]))
                {
                    Connect_Left[X_Order[k], Y_Order[k]] = false;
                }
                if (!Right.Contains(grid[X_Order[k], Y_Order[k]]))
                {
                    Connect_Right[X_Order[k], Y_Order[k]] = false;
                }
                k = k + 1;
            }

            grid[6, 6] = Center;
            
            //loop end]

            //Events = grid.Layers("Events");
            //tilepixel = map.TileWidth;
            grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].Texture = Content.Load<Texture2D>("sprite");
            viewportPosition = new Vector2(grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].X, grid[6, 6].ObjectGroups["Events"].Objects["Spawn"].Y);
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
            //Center.Draw(spriteBatch, new Rectangle(176, 176, 352, 352), viewportPosition);
            for (int i = 1; i < 12; i++)
            {
                for (int k = 1; k < 12; k++)
                {
                    //Center.Draw(spriteBatch, new Rectangle(176, 176, 176, 176), viewportPosition);
                    grid[1, 1].Draw(spriteBatch, new Rectangle(i * 176, k * 176, 176, 176), viewportPosition);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
