using System;
using System.ComponentModel;

namespace Increasing_level_difficulty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int[] monsters = new int[100];
            for (int i = 0; i < monsters.Length; i++)
            {
                var newMonster = random.Next(1 , 51);
                monsters[i] = newMonster;
            }
            Array.Sort(monsters);
            Console.WriteLine($"There are: {String.Join(", ", monsters)} on each floor.");
            Console.ReadLine();
        }
    }
}
