using System;
using System.Collections.Generic;
using System.Globalization;

namespace Party_Shuffle
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Random random = new Random();

            var names = new List<string>();
            


            string ShuffleList(List<string> items)
            {
                
                var returnNames = new List<string>();
                int n = items.Count;
                for (int i = 0; i < n; i++)
                {
                    int j = random.Next(0, items.Count);
                    returnNames.Add(items[j]);
                    items.RemoveAt(j);
                }
                return string.Join(", ", returnNames);
            }

            
            names.Add("This");
            names.Add("Sentance");
            names.Add("Probably");
            names.Add("Won't");
            names.Add("Make");
            names.Add("Sense");
            Console.WriteLine(string.Join(", " ,names));
            Console.ReadLine();
            Console.WriteLine("Shuffling words...");
            Console.ReadLine();
            Console.WriteLine(ShuffleList(names));
            Console.ReadLine();
        }
    }
}
