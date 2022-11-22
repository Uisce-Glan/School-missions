using System;

namespace Party_Dilema
{
    internal class Program
    {
        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        static void Main(string[] args)
        {
            int number;


            Console.WriteLine("How many players?");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Factorial(number));

        }
    }
}
