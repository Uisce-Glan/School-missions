using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)

        {
            
            string[] backers = File.ReadAllLines("backers.txt");
            string playerName = "empty";
            if (File.Exists("player-name.txt"))
            {
                playerName = File.ReadAllText("player-name.txt");
                Console.WriteLine($"Welcome back {playerName}.");
            } else {
                Console.Write("Enter your name: ");
                File.WriteAllText("player-name.txt", Console.ReadLine());
                playerName = File.ReadAllText("player-name.txt");
            }
            string delete = Console.ReadLine();
            if (delete == "delete")
            {
                File.Delete("player-name.txt");
                Console.WriteLine("Save has been deleted.");
                return;
            }
            if (backers.Contains(playerName))
            {
                Console.WriteLine("There is a secret delete command on the first input.");
            }
            else
            {
                Console.WriteLine("There isn't a secret command, I promise.");
            }
            Console.ReadLine();
        }
    }
}
