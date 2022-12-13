using System;
using System.Collections.Generic;

namespace Country_capitals_quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            string result;

            var countriesAndCaptials = new SortedList<string, string>()
            {
                { "The Republic of Ireland", "Dublin" },
                { "Northern Ireland", "Belfast" },
                { "Japan", "Tokyo" },
                { "Germany", "Berlin" },
                { "France", "Paris" },
                { "Luxembourg", "Luxembourg" },
                { "Canada", "Ottawa" }
            };
            var countries = new List<string>(countriesAndCaptials.Keys); //Turns countries into a list

            

            for (int i = 0; i < 5; i++)
            {
                var randomlyPickedCountry = countries[random.Next(0, countries.Count)]; //And now randomize the list


                countriesAndCaptials.TryGetValue(randomlyPickedCountry.ToString(), out result);
                Console.WriteLine($"What is the capital of {randomlyPickedCountry}.");

                string guess = Console.ReadLine();
                guess = char.ToUpper(guess[0]) + guess.Substring(1); //Turn the first letter in the guess capital is it isn't effected by that.

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
