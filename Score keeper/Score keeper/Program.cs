using System;
using System.Collections.Generic;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Score_keeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loopBreak = false;
            int clear = 0;
            
            var scoreKeeper = new SortedList<string, int>()
            {
            };

            Console.WriteLine("After how many rounds do you want to delete history? (Score will be kept, enter -1 to never delete.)");
            int whenToClear = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            while (loopBreak == false)
            {
                Console.WriteLine("Who won this round?\n");
                var winner = Console.ReadLine();

                if (winner == "")
                {
                    loopBreak = true;
                    Console.WriteLine("The final score is:");
                }
                else if (scoreKeeper.ContainsKey(winner))
                {
                    scoreKeeper[winner]++;
                }
                else
                {
                    scoreKeeper.Add(winner, 1);
                }
                
                if (clear >= whenToClear) //Felt like it got very confusing when it went on for too long, 
                {
                    Console.Clear();
                    clear = 0;
                }
                clear++;
                Console.WriteLine("------------");
                int result = 0;
                var sortedPlayers = scoreKeeper.Keys.OrderBy((player) => scoreKeeper[player]).Reverse(); //Convert so whoever is first is on the top
                foreach (var player in sortedPlayers)
                {
                    
                    Console.Write($"{player} has ");
                    scoreKeeper.TryGetValue(player, out result);
                    Console.WriteLine($"{result} points");
                }

                Console.WriteLine();

            }
        }
    }
}
