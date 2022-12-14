using System;
using System.Collections.Generic;
using System.Threading;

namespace Bubble_Sort
{
    internal class Program
    {
        static void DisplayData(List<int> data)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 20; y >= 0; y--)
            {
                if (y % 5 == 0)
                {
                    Console.Write($"{y,3} |");
                }
                else
                {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Count; x++)
                {
                    if (y == 0)
                    {
                        Console.Write("-");
                        continue;
                    }

                    Console.Write(y <= data[x] ? "\u2592" : " ");
                }

                Console.WriteLine();
            }

            Thread.Sleep(10);
        }
        static void Main(string[] args)
        {
            var data = new List<int>();
            var random = new Random();

            for (int i = 0; i < 70; i++)
            {
                data.Add(random.Next(20));
                DisplayData(data);
            }



            // Bubble sort

            // Go through the list number by number and compare it to its next neighbor.
            // If the next neighbor is smaller than the previous one, swap them!
            // Continue until we reach the end.
            // Each time we go through the list, the highest neighbor will 'bubble' to the end.
            // This means we have to sort a smaller and smaller part of the list as we go on.
            // We'll decrease our sorting range one by one until the whole list is sorted.
            for (int sortingRange = 0; data.Count > sortingRange; sortingRange++)
            {
                // Now we go from the start of the list to the end of the sorting range.
                for (int i = 0; i < data.Count - sortingRange - 1; i++)
                {
                    // Look at the next neighbor and see if it's smaller.

                    if (data[i] > data[i + 1])
                    {
                        // It is smaller! We need to switch them.
                        int copy = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = copy;
                    }

                    // Display data for diagnostic purposes.
                    DisplayData(data);
                }
            }
        }

    }
}
