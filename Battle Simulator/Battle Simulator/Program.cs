// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;

static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
{
    var random = new Random();
    int results = 0;
    for (int i = 0; i < numberOfRolls; i++)
    {
       results += random.Next(1, diceSides + 1); //Did +1 since im asking for dice sides and not the random range to roll in.
    }
    results += fixedBonus;
    return results;
}
static void SimulateBattle(List<string> heroNames, string bossWinText, int monsterHP, int savingThrowDC, int lastHeroStanding)
{
    var random = new Random();
    int greatSword = 0;
    int con;
    Console.WriteLine($"You currently have {monsterHP} HP!");
    Console.ReadLine();
    if (heroNames.Count == 1)
    {
        lastHeroStanding = 1;
    }
    while (monsterHP > 0)
    {
        foreach (string warrior in heroNames)
        {
            if (heroNames.Count == 1)
            {
                greatSword += 12;
                if (lastHeroStanding == 0)
                {
                    Console.WriteLine($"Being the last hero standing, {heroNames[0]} has powered up greatly");
                    Console.ReadLine();
                }
                lastHeroStanding = 1;
            }
            greatSword += DiceRoll(2, 6);
            monsterHP -= greatSword;
            Console.Write($"{warrior} did {greatSword} damage to you. ");
            greatSword = 0;
            if (monsterHP < 0)
            {
                monsterHP = 0;
            }
            Console.WriteLine($"You currently have {monsterHP} HP left.");
            if (monsterHP == 0)
            {
                break;
            }
            Console.ReadLine();
        }
        if (monsterHP == 0)
        {
            break;
        }
        con = random.Next(1, 21) + 5;
        if (heroNames.Count == 1)
        {
            con += DiceRoll(2,12,5);
        }
        int randomAttack = random.Next(heroNames.Count);
        Console.WriteLine($"{heroNames[randomAttack]} has a constitution of {con}");
        Console.ReadLine();
        if (con < savingThrowDC)
        {
            Console.WriteLine($"You defeated {heroNames[randomAttack]} and they withdrew from battle");
            Console.ReadLine();
            heroNames.Remove(heroNames[randomAttack]);
        }

        if (heroNames.Count == 0)
        {
            Console.ReadLine();
            Console.WriteLine($"All warriors have been defeated, {bossWinText}");
            break;
        }

    }
    if (heroNames.Count > 0)
    {
        Console.ReadLine();
        Console.WriteLine("The warriors defeated you...");
    }
    Console.ReadLine();
}
var warriorNames = new List<string>();
int lastHeroStanding = 0;

for (var i = 0; i < 4; i++)
{
    Console.Write("Enter the name of a Warrior: ");
    warriorNames.Add(Console.ReadLine());
}
Console.WriteLine($"A party of {warriorNames[0]}, {warriorNames[1]}, {warriorNames[2]} and {warriorNames[3]} enter your castle.\n");
SimulateBattle(warriorNames, "and you barely used any power...", DiceRoll(3,8,6), 12, lastHeroStanding);
if (warriorNames.Count > 0)
{
    Console.ReadLine();
    Console.ReadLine(); //These are to build suspense
    Console.WriteLine("But you refuse to get killed!");
    Console.ReadLine();
    SimulateBattle(warriorNames, "but you used alot of power, a long rest is well deserved.", DiceRoll(10,12), 20, lastHeroStanding);
}

if (warriorNames.Count > 0)
{
    Console.ReadLine();
    Console.ReadLine();
    Console.WriteLine("But you feel new power coursing through you, you give it one last push!");
    Console.ReadLine();
    SimulateBattle(warriorNames, "it took all your strength but you successfully defended the castle.", DiceRoll(10,15,55), 20, lastHeroStanding);
}

Console.WriteLine("End.");
Console.ReadLine();