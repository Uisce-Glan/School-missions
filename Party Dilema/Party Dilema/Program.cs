using System;

namespace Party_Dilema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;

            
            int Factorial(int n)
            {
                int runningTotal = 1;
                while (n > 0)
                {
                    runningTotal *= n;
                    n--;
                }
                return runningTotal;
            }


            Console.WriteLine("How many players?");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Factorial(number));

        }
    }
}
