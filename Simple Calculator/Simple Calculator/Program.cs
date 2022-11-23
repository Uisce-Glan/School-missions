using System;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mathThingy;
            string math;
            double firstNumber;
            double secondNumber;
            bool noEscape = false;

            do
            {
                Console.Write("Set the price: ");
                mathThingy = Console.ReadLine();
                string[] mathSplit = mathThingy.Split(' ');
                math = mathSplit[1];
                firstNumber = double.Parse(mathSplit[0]);
                secondNumber = double.Parse(mathSplit[2]);
                switch (math)
                {
                    case "+":
                    case "plus":
                        Console.WriteLine($"Result: {firstNumber + secondNumber}");
                        break;

                    case "-":
                    case "minus":
                        Console.WriteLine($"Result: {firstNumber - secondNumber}");
                        break;

                    case "/":
                    case "divided":
                        Console.WriteLine($"Result: {firstNumber / secondNumber}");
                        break;

                    case "*":
                    case "times":
                        Console.WriteLine($"Result: {firstNumber * secondNumber}");
                        break;

                    default:
                        Console.WriteLine("Invalid math.");
                        break;
                }
                Console.WriteLine();
            } while (noEscape == false);
        }
    }
}
