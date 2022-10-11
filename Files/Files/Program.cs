using System;
using System.IO;
using System.Numerics;
using System.Xml.Linq;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerNamePath = "empty";
            if (File.Exists("player-name.txt"))
            {
                playerNamePath = File.ReadAllText("player-name.txt");
                Console.WriteLine($"Welcome back {playerNamePath}.");
            } else {
                Console.Write("Enter your name: ");
                File.WriteAllText("player-name.txt", Console.ReadLine());
                playerNamePath = File.ReadAllText("player-name.txt");
            }
            Console.WriteLine(playerNamePath);
        }
    }
}
