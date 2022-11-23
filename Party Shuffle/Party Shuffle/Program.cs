using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks.Dataflow;

namespace Party_Shuffle
{
    internal class Program
    {

        static List<string> ShuffleList(List<string> items)
        {
            Random random = new Random();

            var returnNames = new List<string>();
            int n = items.Count;
            for (int i = 0; i < n; i++)
            {
                int j = random.Next(0, items.Count);
                returnNames.Add(items[j]);
                items.RemoveAt(j);
            }
            return returnNames;
        }

        static void Main(string[] args)
        {


            var names = new List<string>();
            

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
            Console.WriteLine(String.Join(", " ,ShuffleList(names)));
            Console.ReadLine();
            
        }
    }
}
