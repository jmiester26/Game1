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
    ///

    /// This is the main type for your game.
    ///
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 viewportPosition;
        Vector2 startMap, mapOffset, startPos;
        Map Center, Left_Bottom, Bottom_Top, Left_Right, Left_Top, Right_Bottom, Right_Top, All, Bottom, Left1, Top, Right1, Left_Bottom_Right, Left_Bottom_Top, Right_Top_Bottom, Right_Top_Left, map, Wall;
        Map[,] grid = new Map[13, 13];
        List<Map> maplist = new List<Map>();
        int tilepixel;
        Texture2D player;
        Random r = new Random();
        public Vector2 ChangeMapPos
        {
            set
            {
                startMap = value;
                mapOffset = Vector2.Zero;
            }
        }
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
            graphics.PreferredBackBufferWidth = 720;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

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

            player = Content.Load<Texture2D>("sprite");
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
            Wall = Map.Load(Path.Combine(Content.RootDirectory, "Wall.tmx"), Content);

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
            //--------------------------------------------------------------------------------
            Y_Order[0] = 5;
            Y_Order[1] = 6;
            Y_Order[2] = 7;
            Y_Order[3] = 6;

            Y_Order[4] = 4;
            Y_Order[5] = 5;
            Y_Order[6] = 6;
            Y_Order[7] = 7;
            Y_Order[8] = 8;
            Y_Order[9] = 7;
            Y_Order[10] = 6;
            Y_Order[11] = 5;

            Y_Order[12] = 3;
            Y_Order[13] = 4;
            Y_Order[14] = 5;
            Y_Order[15] = 6;
            Y_Order[16] = 7;
            Y_Order[17] = 8;
            Y_Order[18] = 9;
            Y_Order[19] = 8;
            Y_Order[20] = 7;
            Y_Order[21] = 6;
            Y_Order[22] = 5;
            Y_Order[23] = 4;

            Y_Order[24] = 2;
            Y_Order[25] = 3;
            Y_Order[26] = 4;
            Y_Order[27] = 5;
            Y_Order[28] = 6;
            Y_Order[29] = 7;
            Y_Order[30] = 8;
            Y_Order[31] = 9;
            Y_Order[32] = 10;
            Y_Order[33] = 9;
            Y_Order[34] = 8;
            Y_Order[35] = 7;
            Y_Order[36] = 6;
            Y_Order[37] = 5;
            Y_Order[38] = 4;
            Y_Order[39] = 3;

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
                    if (j == 0)
                    {
                        Connect_Bottom[i, j] = false;
                        Connect_Top[i, j] = false;
                        Connect_Left[i, j] = false;
                        Connect_Right[i, j] = false;
                        grid[i, j] = Wall;
                    }
                    if (i == 0)
                    {
                        Connect_Bottom[i, j] = false;
                        Connect_Top[i, j] = false;
                        Connect_Left[i, j] = false;
                        Connect_Right[i, j] = false;
                        grid[i, j] = Wall;
                    }
                    if (j == 12)
                    {
                        Connect_Bottom[i, j] = false;
                        Connect_Top[i, j] = false;
                        Connect_Left[i, j] = false;
                        Connect_Right[i, j] = false;
                        grid[i, j] = Wall;
                    }
                    if (i == 12)
                    {
                        Connect_Bottom[i, j] = false;
                        Connect_Top[i, j] = false;
                        Connect_Left[i, j] = false;
                        Connect_Right[i, j] = false;
                        grid[i, j] = Wall;
                    }
                }
            }

            grid[6, 6] = Center;
            Connect_Bottom[6, 6] = true;
            Connect_Top[6, 6] = true;
            Connect_Left[6, 6] = true;
            Connect_Right[6, 6] = true;

            int k = 0;

            // set k to 0, give X ord and Y ord 0 values and 12 values



            //-----------------------------------------------------------------------------------

            while (k < 120)

            {
                maplist.Clear();
                //-------------------------------------------------------------------------------------------

                if (Connect_Bottom[X_Order[k], Y_Order[k] + 1] is false)
                    Connect_Top[X_Order[k], Y_Order[k]] = false;

                if (Connect_Bottom[X_Order[k], Y_Order[k] + 1] is true)
                    Connect_Top[X_Order[k], Y_Order[k]] = true;

                if (Connect_Top[X_Order[k], Y_Order[k] - 1] is false)
                    Connect_Bottom[X_Order[k], Y_Order[k]] = false;

                if (Connect_Top[X_Order[k], Y_Order[k] - 1] is true)
                    Connect_Bottom[X_Order[k], Y_Order[k]] = true;

                if (Connect_Left[X_Order[k] + 1, Y_Order[k]] is false)
                    Connect_Right[X_Order[k], Y_Order[k]] = false;

                if (Connect_Left[X_Order[k] + 1, Y_Order[k]] is true)
                    Connect_Right[X_Order[k], Y_Order[k]] = true;

                if (Connect_Right[X_Order[k] - 1, Y_Order[k]] is false)
                    Connect_Left[X_Order[k], Y_Order[k]] = false;

                if (Connect_Right[X_Order[k] - 1, Y_Order[k]] is true)
                    Connect_Left[X_Order[k], Y_Order[k]] = true;
                //-------------------------------------------------------------------------
                //Checks to see what the tile k can connect to based on the Arrays for 
                //Connect_Left, Connect_Bottom and so on.





                //-------------------------------------------------------------------------

                if (Connect_Top[X_Order[k], Y_Order[k]] is true)
                {
                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is true)
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                maplist.Add(All);
                            }
                            else // right not true
                            {
                                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                {
                                    maplist.Add(Left_Bottom_Top);
                                }
                                else
                                {
                                    maplist.Add(Left_Bottom_Top);
                                    maplist.Add(All);
                                }
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true) // left not true
                            {
                                if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                {
                                    maplist.Add(Right_Top_Bottom);
                                }
                                else
                                {
                                    maplist.Add(All);
                                    maplist.Add(Right_Top_Bottom);
                                }
                            }
                            else // left and right not true, top and bottom are true
                            {
                                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Bottom_Top);
                                    }
                                    else
                                    {
                                        maplist.Add(Bottom_Top);
                                        maplist.Add(Left_Bottom_Top);
                                    }
                                }
                                else
                                {
                                    if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Bottom_Top);
                                        maplist.Add(Right_Top_Bottom);
                                    }
                                    else
                                    {
                                        maplist.Add(Bottom_Top);
                                        maplist.Add(Right_Top_Bottom);
                                        maplist.Add(Left_Bottom_Top);
                                        maplist.Add(All);
                                    }
                                }
                            }
                        }
                    }
                    else //Bottom not true, Top true
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true)
                            {
                                if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                {
                                    maplist.Add(Right_Top_Left);
                                }
                                else
                                {
                                    maplist.Add(Right_Top_Left);
                                    maplist.Add(All);
                                }
                            }
                            else //Bottom and Right not true, top and left is true
                            {
                                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Left_Top);
                                    }
                                    else
                                    {
                                        maplist.Add(Left_Top);
                                        maplist.Add(Left_Bottom_Top);
                                    }
                                }
                                else
                                {
                                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Right_Top_Left);
                                        maplist.Add(Left_Top);
                                    }
                                    else
                                    {
                                        maplist.Add(Left_Top);
                                        maplist.Add(Right_Top_Left);
                                        maplist.Add(Left_Bottom_Top);
                                        maplist.Add(All);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true) //Left and Bottom not true, Right and Top True
                            {
                                if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Right_Top);
                                    }
                                    else
                                    {
                                        maplist.Add(Right_Top);
                                        maplist.Add(Right_Top_Bottom);
                                    }
                                }
                                else
                                {
                                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Right_Top);
                                        maplist.Add(Right_Top_Left);
                                    }
                                    else
                                    {
                                        maplist.Add(Right_Top);
                                        maplist.Add(Right_Top_Bottom);
                                        maplist.Add(Right_Top_Left);
                                        maplist.Add(All);

                                    }
                                }
                            }
                            else // Left and Bottom and Right not true, Top is true
                            {
                                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Top);
                                        }
                                        else
                                        {
                                            maplist.Add(Top);
                                            maplist.Add(Bottom_Top);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Top);
                                            maplist.Add(Left_Top);
                                        }
                                        else
                                        {
                                            maplist.Add(Top);
                                            maplist.Add(Left_Top);
                                            maplist.Add(Bottom_Top);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Top);
                                            maplist.Add(Right_Top);
                                        }
                                        else
                                        {
                                            maplist.Add(Top);
                                            maplist.Add(Right_Top);
                                            maplist.Add(Bottom_Top);
                                            maplist.Add(Right_Top_Bottom);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Top);
                                            maplist.Add(Right_Top);
                                            maplist.Add(Left_Top);
                                            maplist.Add(Right_Top_Left);
                                        }
                                        else
                                        {
                                            maplist.Add(Top);
                                            maplist.Add(Right_Top);
                                            maplist.Add(Bottom_Top);
                                            maplist.Add(Left_Bottom_Top);
                                            maplist.Add(Left_Top);
                                            maplist.Add(Right_Top_Bottom);
                                            maplist.Add(Right_Top_Left);
                                            maplist.Add(All);
                                        }
                                    }
                                }
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
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true) // Top is not true, Left and bottom and right are true
                            {
                                if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                {
                                    maplist.Add(Left_Bottom_Right);
                                }
                                else
                                {
                                    maplist.Add(Left_Bottom_Right);
                                    maplist.Add(All);
                                }
                            }
                            else //Top and Right are not true, Left and Bottom are true
                            {
                                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Left_Bottom);
                                    }
                                    else
                                    {
                                        maplist.Add(Left_Bottom);
                                        maplist.Add(Left_Bottom_Top);
                                    }
                                }
                                else
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Left_Bottom);
                                        maplist.Add(Left_Bottom_Right);
                                    }
                                    else
                                    {
                                        maplist.Add(Left_Bottom);
                                        maplist.Add(Left_Bottom_Right);
                                        maplist.Add(Left_Bottom_Top);
                                        maplist.Add(All);
                                    }
                                }
                            }
                        }
                        else // Left and top are not true
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true) //Right and bottom are true
                            {
                                if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Right_Bottom);
                                    }
                                    else
                                    {
                                        maplist.Add(Right_Bottom);
                                        maplist.Add(Right_Top_Bottom);
                                    }
                                }
                                else
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Right_Bottom);
                                        maplist.Add(Left_Bottom_Right);
                                    }
                                    else
                                    {
                                        maplist.Add(Right_Bottom);
                                        maplist.Add(Right_Top_Bottom);
                                        maplist.Add(Left_Bottom_Right);
                                        maplist.Add(All);
                                    }
                                }
                            }
                            else // Top and Right and Left are not true, Bottom is true
                            {
                                maplist.Add(Bottom);
                                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Bottom);
                                        }
                                        else
                                        {
                                            maplist.Add(Bottom);
                                            maplist.Add(Bottom_Top);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Bottom);
                                            maplist.Add(Left_Bottom);
                                        }
                                        else
                                        {
                                            maplist.Add(Bottom);
                                            maplist.Add(Left_Bottom);
                                            maplist.Add(Bottom_Top);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Bottom);
                                            maplist.Add(Right_Bottom);
                                        }
                                        else
                                        {
                                            maplist.Add(Bottom);
                                            maplist.Add(Right_Bottom);
                                            maplist.Add(Bottom_Top);
                                            maplist.Add(Right_Top_Bottom);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Bottom);
                                            maplist.Add(Right_Bottom);
                                            maplist.Add(Left_Bottom);
                                            maplist.Add(Left_Bottom_Right);
                                        }
                                        else
                                        {
                                            maplist.Add(Bottom);
                                            maplist.Add(Right_Bottom);
                                            maplist.Add(Bottom_Top);
                                            maplist.Add(Left_Bottom_Top);
                                            maplist.Add(Left_Bottom);
                                            maplist.Add(Right_Top_Bottom);
                                            maplist.Add(Left_Bottom_Right);
                                            maplist.Add(All);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Connect_Left[X_Order[k], Y_Order[k]] is true)
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true) //down, up not true
                            {
                                if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Left_Right);
                                    }
                                    else
                                    {
                                        maplist.Add(Left_Right);
                                        maplist.Add(Left_Bottom_Right);
                                    }
                                }
                                else
                                {
                                    if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                    {
                                        maplist.Add(Left_Right);
                                        maplist.Add(Right_Top_Left);
                                    }
                                    else
                                    {
                                        maplist.Add(Left_Right);
                                        maplist.Add(Left_Bottom_Right);
                                        maplist.Add(Right_Top_Left);
                                        maplist.Add(All);
                                    }
                                }
                            }
                            else // right, down, up not true
                            {
                                if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Left1);
                                        }
                                        else
                                        {
                                            maplist.Add(Left1);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Left1);
                                        }
                                        else
                                        {
                                            maplist.Add(Left1);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Left1);
                                        }
                                        else
                                        {
                                            maplist.Add(Left1);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Left1);
                                        }
                                        else
                                        {
                                            maplist.Add(Left1);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Connect_Right[X_Order[k], Y_Order[k]] is true) //left, down, up not true
                            {
                                if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Right1);
                                        }
                                        else
                                        {
                                            maplist.Add(Right1);
                                            maplist.Add(Right_Bottom);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Right1);
                                            maplist.Add(Right_Top);
                                        }
                                        else
                                        {
                                            maplist.Add(Right1);
                                            maplist.Add(Right_Bottom);
                                            maplist.Add(Right_Top);
                                            maplist.Add(Right_Top_Bottom);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Right1);
                                            maplist.Add(Left_Right);
                                        }
                                        else
                                        {
                                            maplist.Add(Right1);
                                            maplist.Add(Right_Bottom);
                                            maplist.Add(Left_Right);
                                            maplist.Add(Left_Bottom_Right);
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                        {
                                            maplist.Add(Right1);
                                            maplist.Add(Right_Top);
                                            maplist.Add(Left_Right);
                                            maplist.Add(Right_Top_Left);
                                        }
                                        else
                                        {
                                            maplist.Add(Right1);
                                            maplist.Add(Right_Bottom);
                                            maplist.Add(Right_Top);
                                            maplist.Add(Right_Top_Bottom);
                                            maplist.Add(Left_Right);
                                            maplist.Add(Right_Top_Left);
                                            maplist.Add(Left_Bottom_Right);
                                            maplist.Add(All);
                                        }
                                    }
                                }
                            }
                            else //all not true
                            {
                                if (Connect_Left[X_Order[k], Y_Order[k]] is false)
                                {
                                    if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Left1);
                                            }
                                            else
                                            {
                                                maplist.Add(Left1);
                                            }
                                        }
                                        else
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Left1);
                                            }
                                            else
                                            {
                                                maplist.Add(Left1);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Left1);
                                            }
                                            else
                                            {
                                                maplist.Add(Left1);
                                            }
                                        }
                                        else
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Left1);
                                            }
                                            else
                                            {
                                                maplist.Add(Left1);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Connect_Right[X_Order[k], Y_Order[k]] is false)
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                            }
                                            else
                                            {
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                                maplist.Add(Bottom);
                                                maplist.Add(Left_Bottom);
                                            }
                                        }
                                        else
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                                maplist.Add(Top);
                                                maplist.Add(Left_Top);
                                            }
                                            else
                                            {
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                                maplist.Add(Bottom);
                                                maplist.Add(Left_Bottom);
                                                maplist.Add(Top);
                                                maplist.Add(Left_Top);
                                                maplist.Add(Bottom_Top);
                                                maplist.Add(Left_Bottom_Top);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Connect_Top[X_Order[k], Y_Order[k]] is false)
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Left_Right);
                                                maplist.Add(Right1);
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                            }
                                            else
                                            {
                                                maplist.Add(Left_Bottom_Right);
                                                maplist.Add(Left_Bottom);
                                                maplist.Add(Right_Bottom);
                                                maplist.Add(Bottom);
                                                maplist.Add(Left_Right);
                                                maplist.Add(Right1);
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                            }
                                        }
                                        else
                                        {
                                            if (Connect_Bottom[X_Order[k], Y_Order[k]] is false)
                                            {
                                                maplist.Add(Right_Top_Left);
                                                maplist.Add(Left_Top);
                                                maplist.Add(Right_Top);
                                                maplist.Add(Top);
                                                maplist.Add(Left_Right);
                                                maplist.Add(Right1);
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                            }
                                            else
                                            {
                                                maplist.Add(All);
                                                maplist.Add(Left_Bottom_Top);
                                                maplist.Add(Right_Top_Bottom);
                                                maplist.Add(Bottom_Top);
                                                maplist.Add(Right_Top_Left);
                                                maplist.Add(Left_Top);
                                                maplist.Add(Right_Top);
                                                maplist.Add(Top);
                                                maplist.Add(Left_Bottom_Right);
                                                maplist.Add(Left_Bottom);
                                                maplist.Add(Right_Bottom);
                                                maplist.Add(Bottom);
                                                maplist.Add(Left_Right);
                                                maplist.Add(Right1);
                                                maplist.Add(Left1);
                                                maplist.Add(Wall);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            

            Console.WriteLine("Maps for this location: " + maplist.Count);
            //-------------------------------------------------------------------------
            //maplist.Add(All);
            //maplist.Add(Left_Bottom_Top);
            //maplist.Add(Right_Top_Bottom);
            //maplist.Add(Bottom_Top);
            //maplist.Add(Right_Top_Left);
            //maplist.Add(Left_Top);
            //maplist.Add(Right_Top);
            //maplist.Add(Top);
            //maplist.Add(Left_Bottom_Right);
            //maplist.Add(Left_Bottom);
            //maplist.Add(Right_Bottom);
            //maplist.Add(Bottom);
            //maplist.Add(Left_Right);
            //maplist.Add(Right1);
            //maplist.Add(Left1);
            //
            //
            //
            //
            //-------------------------------------------------------------------------
            if (maplist.Count > 1)
            {
                grid[X_Order[k], Y_Order[k]] = maplist[r.Next(0, maplist.Count - 1)];
            }
            else
            {
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

            //-------------------------------------------------------------------------

            k = k + 1;

        }
      //loop end]

            // these loop will create a unique copy of the maps for each grid square
            for (int c = 0; c < 13; c++)
            {
                for (int r = 0; r < 13; r++)
                {
                    if (grid[c, r] == Center)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Center.tmx"), Content);
                    }
                    else if (grid[c, r] == Left_Bottom)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Left_Bottom.tmx"), Content);
                    }
                    else if (grid[c, r] == Bottom_Top)
                    {
                        grid[r, c] = Map.Load(Path.Combine(Content.RootDirectory, "Bottom_Top.tmx"), Content);
                    }
                    else if (grid[c, r] == Left_Right)
                    {
                        Left_Right = Map.Load(Path.Combine(Content.RootDirectory, "Left_Right.tmx"), Content);
                    }
                    else if (grid[c, r] == Left_Top)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Left_Top.tmx"), Content);
                    }
                    else if (grid[c, r] == Right_Bottom)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Right_Bottom.tmx"), Content);
                    }
                    else if (grid[c, r] == Right_Top)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Right_Top.tmx"), Content);
                    }
                    else if (grid[c, r] == All)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "All.tmx"), Content);
                    }
                    else if (grid[c, r] == Right1)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Right.tmx"), Content);
                    }
                    else if (grid[c, r] == Left1)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Left.tmx"), Content);
                    }
                    else if (grid[c, r] == Left_Bottom)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Top.tmx"), Content);
                    }
                    else if (grid[c, r] == Bottom)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Bottom.tmx"), Content);
                    }
                    else if (grid[c, r] == Left_Bottom_Right)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Left_Bottom_Right.tmx"), Content);
                    }
                    else if (grid[c, r] == Left_Bottom_Top)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Left_Bottom_Top.tmx"), Content);
                    }
                    else if (grid[c, r] == Right_Top_Bottom)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Right_Top_Bottom.tmx"), Content);
                    }
                    else if (grid[c, r] == Right_Top_Left)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Right_Top_Left.tmx"), Content);
                    }
                    else if (grid[c, r] == Wall)
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "Wall.tmx"), Content);
                    }
                    else
                    {
                        grid[c, r] = Map.Load(Path.Combine(Content.RootDirectory, "All.tmx"), Content);
                    }

                }
            }
            startMap = new Vector2(6, 6);
            mapOffset = new Vector2((176 / 2) - (player.Width) / 2, (176 / 2) - (player.Height) / 2);
            viewportPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            startPos = new Vector2((int)viewportPosition.X - (player.Width / 2), (int)viewportPosition.Y - (player.Height / 2));
            mapOffset = Vector2.Zero;
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

        public bool checkbounds(Vector2 smap, Vector2 mo, Vector2 sp)
        {
            bool check = false;
            for (int i = 0; i < 2; i++)
            {
                mo -= new Vector2(7 * i, 7 * i);
                //work out the grid reference for map over
                int x = (int)(smap.X - (Math.Round((double)mo.X / 176)));
                int y = (int)(smap.Y - (Math.Round((double)mo.Y / 176)));

                // gets collision layer for map over
                Layer collision = grid[x, y].Layers["Wall"];

                // gets overall x & y in pixels for position in grid
                int overallx = (int)((smap.X * 176) - mo.X) + 88;
                int overally = (int)((smap.Y * 176) - mo.Y) + 88;

                //works out the x & y position in pixels in current map
                int mapx = (int)Math.Round((double)((overallx % 176)));
                int mapy = (int)Math.Round((double)((overally % 176)));

                int tilex = (int)(mapx / 16);
                int tiley = (int)(mapy / 16);

                // check if tile exists in the bounds
                if (collision.GetTile(tilex, tiley) != 0)
                {
                    check = true;
                }
            }

            return check;
        }

        public void checkinteract(Vector2 smap, Vector2 mo, Vector2 sp)
        {
            bool check = false;
            for (int i = 0; i < 2; i++)
            {
                mo -= new Vector2(7 * i, 7 * i);
                //work out the grid reference for map over
                int x = (int)(smap.X - (Math.Round((double)mo.X / 176)));
                int y = (int)(smap.Y - (Math.Round((double)mo.Y / 176)));

                // gets collision layer for map over
                Layer interact = grid[x, y].Layers["Interact"];

                // gets overall x & y in pixels for position in grid
                int overallx = (int)((smap.X * 176) - mo.X) + 88;
                int overally = (int)((smap.Y * 176) - mo.Y) + 88;

                //works out the x & y position in pixels in current map
                int mapx = (int)Math.Round((double)((overallx % 176)));
                int mapy = (int)Math.Round((double)((overally % 176)));

                // works out the tile you are over
                int tilex = (int)(mapx / 16);
                int tiley = (int)(mapy / 16);

                //checks the interact layer, if it is 0 then nothing there
                if (interact.GetTile(tilex, tiley) != 0)
                {
                    int tile = interact.GetTile(tilex, tiley);
                    Console.WriteLine(tile);
                    switch (tile)
                    {
                        // case for different tile numbers
                        // could add other tiles in interact layer and add the case for it here
                        case 8:
                            Console.WriteLine("stairs up");
                            ChangeMapPos = new Vector2(3, 1);
                            break;
                        case 9:
                            Console.WriteLine("stairs down");
                            ChangeMapPos = new Vector2(8, 8);
                            break;
                        case 30:
                            // example of how to collect or remove a tile, 11 is width of map in tiles
                            Console.WriteLine("collected sign");
                            int tilepos = (tiley) * 11 + tilex;
                            interact.Tiles[tilepos] = 0;
                            break;
                    }
                }
            }
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
                scrolly = -1;
            if (keyState.IsKeyDown(Keys.Down))
                scrolly = 1;

            Vector2 temp = mapOffset;
            mapOffset -= new Vector2(scrollx, scrolly);

            if (checkbounds(startMap, mapOffset, startPos))
            {
                mapOffset = temp;
            }

            //check for interactions with interact layer
            checkinteract(startMap, mapOffset, startPos);

            if (gamePadState.IsButtonDown(Buttons.Back) || keyState.IsKeyDown(Keys.Escape))
                this.Exit();

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

            for (int i = 0; i < 13; i++)
            {
                for (int k = 0; k < 13; k++)
                {
                    if (grid[i, k]!=null)
                        grid[i, k].Draw(spriteBatch, new Rectangle(((i - (int)startMap.X) * 176) + (int)mapOffset.X + 88 + (int)viewportPosition.X / 2, ((k - (int)startMap.Y) * 176) + (int)mapOffset.Y + 88 + (int)viewportPosition.Y / 2, 176, 176), new Vector2(0, 0));
                }
            }

            spriteBatch.End();

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //spriteBatch.Draw(test, Vector2.Zero, Color.White);
            spriteBatch.Draw(player, new Rectangle((int)startPos.X, (int)startPos.Y, 14, 14), Color.White);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}