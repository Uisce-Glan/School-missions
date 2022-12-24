using System;

namespace Adventure_Map_2._0__Now_with_2D_Arrays__
{
    internal class Program
    {
        static Random random = new Random();

        static void GenerateCurve(int[,] curviture, int maxX, int maxY, int maxCurviture, int randomCurveOdds, int startLocation, bool[,] nonMoving) //the mission says to use a list, but keeping my 2d arrays to stay consistant, while the code gets fundamentaliy different from how i made the rest of the code, I think I still understand the point.
        {
            var random = new Random();

            var randomCurve = 0;
            var noRepeatCharacters = 0;
            var curve = 0;

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (y == (startLocation) + curve && x > noRepeatCharacters)
                    {
                        randomCurve = random.Next(randomCurveOdds); //The curviture is decided by the random getting 1 and 2, everything else is straight line
                        if (randomCurve == 0)
                        {

                            curviture[x, y] = 1;
                            if (curve > -maxCurviture) //MaxCurviture makes sure it doesn't go completely overboard like -1 10 times in a row etc
                            {
                                curve += -1;
                            }
                        }
                        else if (randomCurve == 1)
                        {
                            curviture[x, y] = 2;
                            if (curve < maxCurviture)
                            {
                                curve += 1;
                            }
                        }
                        else
                        {
                            curviture[x, y] = 3;
                        }
                        noRepeatCharacters = x; //Makes sure it doesn't jump one x to the side and instantly place another character.
                    }
                }
            }
        }
        static void GenerateBorder(int[,] mapSize, int maxX, int maxY)
        {
            for (var x = 0; x < mapSize.GetLength(0); x++)
            {
                for (var y = 0; y < mapSize.GetLength(1); y++)
                {
                    if (x == 0 && y == 0 || x == 0 && y == maxY - 1 || x == maxX - 1 && y == 0 || x == maxX - 1 && y == maxY - 1) //This marks all the corners
                    {
                        mapSize[x, y] = 1; //This 2d array is an int so I can give different positions different characters (so in this case 1 is later on +)
                    }
                    else if (y == 0 || y == maxY - 1)
                    {
                        mapSize[x, y] = 2;
                    }
                    else if (x == 0 || x == maxX - 1)
                    {
                        mapSize[x, y] = 3;
                    }
                }
            }

        }
        static void GenerateForest(bool[,] forestLocation, int maxX, int maxY)
        {

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    int willItBeATree = random.Next(0, 3);
                    if (y < maxY / 10)
                    {
                        forestLocation[x, y] = true;
                    }
                    else if (y < maxY / 6)
                    {
                        if (willItBeATree == 0) //This checks if it will be a since it rolls a 0-2 dice for every spot and if it rolls 0 it's a tree.
                        {
                            forestLocation[x, y] = true;
                        }
                    }
                }
            }
        }
        static void GenerateRiver(int[,] river, int maxX, int maxY, bool[,] riverBool)
        {
            var random = new Random();

            var randomWaterFlow = 0;
            var noRepeatWater = 0;
            var waterFlow = 0;
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (y == (maxY * 3 / 4) + waterFlow && x > noRepeatWater)
                    {
                        randomWaterFlow = random.Next(0, 3);
                        if (randomWaterFlow == 0)
                        {

                            river[x, y] = 1;
                            if (waterFlow > -3)
                            {
                                waterFlow += -1;
                            }
                        }
                        else if (randomWaterFlow == 1)
                        {
                            river[x, y] = 2;
                        }
                        else
                        {
                            river[x, y] = 3;
                            if (waterFlow < 3)
                            {
                                waterFlow += 1;
                            }
                        }
                        if (river[x, y] > 0)
                        {
                            riverBool[x, y] = true;
                        }

                        noRepeatWater = x;

                    }
                }
            }
        } //Keeping this as a comparison for what the "GenerateCurve" was based on, even though it isn't used.
        static void GenerateRoad(bool[,] road, int maxX, int maxY, bool[,] riverLocation) //Honestly, I think i could scrap this one and use generate curve here instead since most things are the same.
        {


            var randomRoad = 0;
            var noRepeatRoad = 0;
            var randomRoadMover = 0;

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (y > (maxY * 3 / 4) - 9 && x == (maxX / 2) + randomRoadMover && y > noRepeatRoad)
                    {
                        road[x, y] = true;

                    }
                    else if (x == (maxX / 2) + randomRoadMover && y > noRepeatRoad)
                    {
                        randomRoad = random.Next(3);
                        if (randomRoad == 0)
                        {
                            if (randomRoadMover > -5)
                            {
                                randomRoadMover += 1;
                            }
                        }
                        else if (randomRoad == 1)
                        {
                            if (randomRoadMover > 5)
                            {
                                randomRoadMover += -1;
                            }
                        }
                        road[x, y] = true;
                        noRepeatRoad = y; //Makes sure that if the road goes down by 1 it doesn't place another road in that location.
                    }
                }
            }
        }


        static void Map(int height, int width)
        {

            #region Variables
            var sidePath = false;
            var bridge = new bool[height, width];
            var symbols = @"!@$%&()A?"; //Forest symbols
            var mapBorder = new int[height, width];
            var forest = new bool[height, width];
            var river = new int[height, width];
            var wall = new int[height, width];
            var waterBool = new bool[height, width];
            var road = new bool[height, width];
            var topName = new bool[height, width];
            var wallBool = new bool[height, width];
            #endregion Variables
            #region Functions
            GenerateBorder(mapBorder, height, width);
            GenerateForest(forest, height, width);
            GenerateRoad(road, height, width, waterBool);
            GenerateCurve(river, height, width, 3, 4, width * 3 / 4, waterBool);
            GenerateCurve(wall, height, width, 5, 16, width * 1 / 4, wallBool);
            #endregion Functions

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    #region This is where the border is writen
                    if (mapBorder[x, y] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("+");
                    }
                    else if (mapBorder[x, y] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|");
                    }
                    else if (mapBorder[x, y] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("-");
                    }
                    #endregion This is where the border is writen
                    else if (y == (width / 2) + 6 && x == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\b\b\b\b\b\b\b\b\b\b\b\bAdventure Map"); //The \b are to remove " " to compinsate for having a string that isn't a singer character.
                    }
                    #region Bridge Location
                    else if (road[x + 1, y] == true && river[x, y - 1] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\b\b\b\b\b\b");
                        Console.Write(" ======");
                        sidePath = true; //This is to activate the side path next to the river.
                    }
                    else if (road[x - 1, y] == true && river[x, y - 1] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\b\b\b\b\b\b");
                        Console.Write(" ======");
                        #endregion Bridge Location
                    }
                    else if (road[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("#");
                    }
                    else if (forest[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(symbols[random.Next(symbols.Length)]);
                    }
                    else if (wall[x, y] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\b" + @"\\");
                    }
                    else if (wall[x, y] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\b" + @"//");
                    }
                    else if (wall[x, y] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\b||");
                    }
                    #region River is here
                    else if (river[x, y] > 0)
                    {
                        if (sidePath == true)
                        {
                            if (river[x, y] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("\b\b\b\b\b\b\b");
                                Console.Write("#    "); //This is the road next to the river.
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("///");
                            }
                            else if (river[x, y] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("\b\b\b\b\b\b\b");
                                Console.Write("#    ");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("|||");
                            }
                            else if (river[x, y] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("\b\b\b\b\b\b\b");
                                Console.Write("#    ");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write(@"\\\");
                            }
                        }
                        else //This is when the river is above the bridge.
                        {
                            if (river[x, y] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\b\b");
                                Console.Write("///");
                            }
                            else if (river[x, y] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\b\b");
                                Console.Write("|||");
                            }
                            else if (river[x, y] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\b\b");
                                Console.Write(@"\\\");
                            }
                        }
                    }
                    #endregion River is here
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            var height = 120;
            var width = 40;
            Map(width, height); //I think making everything into functions was a mistake that made things overly complicated, and in hindsight what I thought was a good idea to make on the fly might not have been such a good idea.

        } //Also i don't feel like i need to customize it to make it my own, since its already a train wreck, but it's my train wreck and I'm attached to its quirks.
    }
}
