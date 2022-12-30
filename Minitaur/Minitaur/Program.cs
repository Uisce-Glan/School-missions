using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Minitaur
{
    internal class Program
    {
        static int playerX; //to keep an eye on where the player/goal is
        static int playerY;
        static int goalX;
        static int goalY;
        static int width;
        static int height;
        static char[,] map;



        static void Main(string[] args)
        {
            static void PlayerInput()
            {
                ConsoleKey key;
                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    key = keyInfo.Key;
                } while (Console.KeyAvailable); //This loop makes sure you store key presses.

                switch (key)
                {
                    case ConsoleKey.W:
                        if (map[playerX, playerY - 1] == ' ') //These ifs check if you can move to the location
                        {
                            playerY -= 1;
                        }
                        break;

                    case ConsoleKey.A:
                        if (map[playerX - 1, playerY] == ' ')
                        {
                            playerX -= 1;
                        }
                        break;

                    case ConsoleKey.S:
                        if (map[playerX, playerY + 1] == ' ')
                        {

                            playerY += 1;
                        }
                        break;

                    case ConsoleKey.D:
                        if (map[playerX + 1, playerY] == ' ')
                        {
                            playerX += 1;
                        }
                        break;
                    default:
                        break;
                }
            }

            static void DrawMap()
            {
                for (int y = 0; y < height; y++)
                {

                    for (int x = 0; x < width; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        if (x == playerX && y == playerY)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write('☺');
                        }
                        else if (x == goalX && y == goalY)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write('*');
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(map[x, y]);
                        }
                    }
                    Console.WriteLine();
                }
            }

            string mazeLevel = @"MazeLevel.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(mazeLevel).ToList(); //Make the file a list
            Console.CursorVisible = false;

            string dimensions = lines[1];
            string[] dimensionSplit = dimensions.Split("x"); //Since its number1xnumber2 i split it with x so i have height and width seprait 
            height = Int32.Parse(dimensionSplit[1]);
            width = Int32.Parse(dimensionSplit[0]);
            map = new char[width, height];

            for (int y = 0; y < height; y++) //Writes the first map
            {
                string lineCount = lines[y + 2]; //Counts what line im on (+2 because it wants to skip the first 2 rows.
                for (var x = 0; x < width; x++)
                {
                    if (lineCount[x] == 'S')
                    {
                        map[x, y] = ' ';
                        playerX = x;
                        playerY = y;
                    }
                    else if (lineCount[x] == 'M')
                    {
                        map[x, y] = ' ';
                        goalX = x;
                        goalY = y;
                    }
                    else
                    {
                        map[x, y] = lineCount[x];
                    }

                }
            }

            Console.WriteLine($"{lines[0]}\nFind the Minitaur (he is very small) and become his friend \n\n   Use\n\n    W\n   ASD\n\n To move\n\nPress any key to start");
            Console.ReadKey(true);
            Console.Clear();

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                DrawMap();

                if (playerX == goalX && playerY == goalY) //I have this first so that you actually step on the goal before you win
                {
                    break;
                }
                PlayerInput();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("You win!");
            Thread.Sleep(1000); //Makes sure the game doesn't close instantly because you held A 
            Console.ReadKey(true);
        }
    }
}
