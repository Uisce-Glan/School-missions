using System;
using System.IO;
using System.Security.Cryptography;

namespace Adventure_map
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var length = 40;
            var height = 10;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    if (x == 0 || x == length - 1 || y == 0 || y == height - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (x == 0 && y == 0 || x == 0 && y == height - 1 || x == length - 1 & y == 0 || x == length - 1 && y == height - 1)
                        {
                            Console.Write("+");
                        }
                        else if (y == 0 || y == height - 1)
                        {
                            Console.Write("-");
                        }
                        else if (x == 0 || x == length - 1)
                        {
                            Console.Write("|");
                        }
                        continue;
                    }

                    if (x < length / 6)
                    {

                        var symbols = @"!@$%&()A?";
                        // Draw a tree.
                        int willItBeATree = random.Next(0, 2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (x < length / 10)
                        {
                            Console.Write(symbols[random.Next(symbols.Length)]);
                        }
                        else if (willItBeATree == 0)
                        {
                            Console.Write(symbols[random.Next(symbols.Length)]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        continue;
                    }

                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }
    }
}

