using System;

namespace City_Generator
{
    internal class Program
    {
        static void GenerateIntersection(bool[,] roads, int x, int y)
        {
            roads[x, y] = true;
            var random = new Random();
            var zero = random.Next(10);
            var one = random.Next(10);
            var two = random.Next(10);
            var three = random.Next(10);
            if (zero > 2)
            {
                GenerateRoad(roads, x, y, 0);
            }
            if (one > 2)
            {
                GenerateRoad(roads, x, y, 1);
            }
            if (two > 2)
            {
                GenerateRoad(roads, x, y, 2);
            }
            if (three > 2)
            {
                GenerateRoad(roads, x, y, 3);
            }
        }
        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {
            #region Can make this simpler if i spend more time on it but want to move on
            if (direction == 3)
            for (var x = 0; x < roads.GetLength(0); x++)
            {
                for (var y = 0; y < roads.GetLength(1); y++)
                {
                    if (x > startX && y == startY)
                    {
                        roads[x, y] = true;
                    }
                }
            }
            if (direction == 2)
                for (var x = 0; x < roads.GetLength(0); x++)
                {
                    for (var y = 0; y < roads.GetLength(1); y++)
                    {
                        if (x < startX && y == startY)
                        {
                            roads[x, y] = true;
                        }
                    }
                }
            if (direction == 1)
                for (var x = 0; x < roads.GetLength(0); x++)
                {
                    for (var y = 0; y < roads.GetLength(1); y++)
                    {
                        if (x == startX && y < startY)
                        {
                            roads[x, y] = true;
                        }
                    }
                }
            if (direction == 0)
                for (var x = 0; x < roads.GetLength(0); x++)
                {
                    for (var y = 0; y < roads.GetLength(1); y++)
                    {
                        if (x == startX && y > startY)
                        {
                            roads[x, y] = true;
                        }
                    }
                }
            #endregion Can make this simpler if i spend more time on it but want to move on
            return;
        }
        static void Main(string[] args)
        {
            var random = new Random();            
            var roads = new bool[30, 90];
            GenerateIntersection(roads, random.Next(roads.GetLength(0)), random.Next(roads.GetLength(1)));
            GenerateIntersection(roads, random.Next(roads.GetLength(0)), random.Next(roads.GetLength(1)));
            GenerateIntersection(roads, random.Next(roads.GetLength(0)), random.Next(roads.GetLength(1)));
            GenerateIntersection(roads, random.Next(roads.GetLength(0)), random.Next(roads.GetLength(1)));
            GenerateIntersection(roads, random.Next(roads.GetLength(0)), random.Next(roads.GetLength(1)));
            GenerateIntersection(roads, random.Next(roads.GetLength(0)), random.Next(roads.GetLength(1)));
            GenerateIntersection(roads, random.Next(roads.GetLength(0)), random.Next(roads.GetLength(1)));
            for (int i = 0; i < roads.GetLength(0); i++)
            {
                for (int j = 0; j < roads.GetLength(1); j++)
                {
                    if (roads[i, j] == true)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
