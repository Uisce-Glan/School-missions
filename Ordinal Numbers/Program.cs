using System; 

namespace Ordinal_Numbers
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
                    return "st";
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
                static void Main(string[] args)
        {
            Console.WriteLine(OrdinalNumber(Convert.ToInt32(Console.ReadLine())));
            Console.ReadLine();
        }
    }
}
