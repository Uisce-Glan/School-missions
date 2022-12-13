using System;
using System.Collections.Generic;

namespace Olympic_Games_quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var olympics = new Dictionary<string, string>()
            {
                { "2000", "Australia" },
                { "2004", "Greece" },
                { "2008", "China" },
                { "2012", "United Kingdom" },
                { "2016", "Brazil" },
                { "2020", "Japan" },
                { "2024", "France" }
            };
            for (int i = 0; i < 4; i++)
            {
                int year = 2000 + random.Next(olympics.Count) * 4;
                if (year > 2020)
                {
                    Console.WriteLine($"In what country will the {year} olympic summer games be?");
                }
                else
                {
                    Console.WriteLine($"In what country was the {year} olympic summer games?");
                }
                string guess = Console.ReadLine();
                guess = char.ToUpper(guess[0]) + guess.Substring(1);
                string result;
                olympics.TryGetValue(year.ToString(), out result);

                if (guess == result)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect, the correct answer was {result}.");
                }
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
