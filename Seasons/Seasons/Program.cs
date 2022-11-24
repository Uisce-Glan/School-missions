using System;

namespace Seasons
{
    internal class Program
    {
        static string OrdinalNumber(int number)
        {
            int lastNumber;
            if (number > 10)
            {
                lastNumber = number / 10;
                lastNumber %= 10;
                if (lastNumber == 1)
                {
                    return number + "th";
                }
            }
            lastNumber = number % 10;

            if (lastNumber == 1)
            {
                return number + "st";
            }
            else if (lastNumber == 2)
            {
                return number + "nd";
            }
            else if (lastNumber == 3)
            {
                return number + "rd";
            }
            return number + "th";
        }

        static string CreateDayDescription(int day, int season, int year)
        {
            string[] Seasons = {"Spring", "Summer", "Fall", "Winter"};
            return $"{OrdinalNumber(day)} day of {Seasons[season]} in the year {year}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CreateDayDescription(1, 0, 39481));
            Console.WriteLine(CreateDayDescription(28, 2, 2002));
            Console.WriteLine(CreateDayDescription(7, 1, 2));
            Console.WriteLine(CreateDayDescription(17, 3, 908));
            Console.ReadLine();
        }
    }
}
