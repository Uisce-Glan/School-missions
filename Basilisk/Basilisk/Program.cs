// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

var random = new Random();


var warriors = new List<string>();

int basiliskHP = 0;
int greatSword = 0;
int con = 0;

for (var i = 0; i < 8; i++)
{
    basiliskHP = basiliskHP + random.Next(1, 9);
}
basiliskHP = basiliskHP + 16;

for (var i = 0; i < 4; i++)
{
    Console.Write("Enter the name of a Warrior: ");
    warriors.Add(Console.ReadLine());
}

Console.WriteLine($"A party of {warriors[0]}, {warriors[1]}, {warriors[2]} and {warriors[3]} enter your castle.");
Console.WriteLine($"You currently have {basiliskHP} HP!\n");

while (basiliskHP > 0 )
{
    foreach (string warrior in warriors)
    {
            greatSword = random.Next(1, 5);
        basiliskHP -= greatSword;
        Console.Write($"{warrior} did {greatSword} damage to you. ");
        greatSword = 0;
        if (basiliskHP < 0)
        {
            basiliskHP = 0;
        }
        Console.WriteLine($"You currently have {basiliskHP} HP left.");
        if (basiliskHP == 0)
        { 
            break;
        }
        Console.ReadLine();
    }
    if (basiliskHP == 0)
    {
        break;
    }
    con = random.Next(1, 21)+5;
        int randomAttack = random.Next(warriors.Count);
        Console.WriteLine($"{warriors[randomAttack]} has a constitution of {con}");
        Console.ReadLine();
        if (con < 12)
        {
            Console.WriteLine($"You defeated {warriors[randomAttack]} and they withdrew from battle");
            Console.ReadLine();
            warriors.Remove(warriors[randomAttack]);
        }
    if (warriors.Count == 0)
    {
        Console.WriteLine("All warriors have been defeated, you are free to relax again");
        break;
    }
    
}
if (warriors.Count > 0)
{
    Console.WriteLine("\nThe warriors defeated you...");
}
Console.ReadLine();
