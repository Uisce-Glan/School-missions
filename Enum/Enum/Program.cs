using System;

namespace Enum
{ enum Suits
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }
    internal class Program
    {
        static void DrawAce (Suits suit)
        {
            switch (suit)
            {
                case Suits.Hearts:
                    Console.WriteLine("╭───────╮\r\n│A      │\r\n│♥      │\r\n│   ♥   │\r\n│      ♥│\r\n│      A│\r\n╰───────╯\r\n");
                    break;
                case Suits.Spades:
                    Console.WriteLine("╭───────╮\r\n│A      │\r\n│♠      │\r\n│   ♠   │\r\n│      ♠│\r\n│      A│\r\n╰───────╯\r\n");
                    break;
                case Suits.Diamonds:
                    Console.WriteLine("╭───────╮\r\n│A      │\r\n│♦      │\r\n│   ♦   │\r\n│      ♦│\r\n│      A│\r\n╰───────╯\r\n");
                    break;
                case Suits.Clubs:
                    Console.WriteLine("╭───────╮\r\n│A      │\r\n│♣      │\r\n│   ♣   │\r\n│      ♣│\r\n│      A│\r\n╰───────╯\r\n");
                    break;
            }
           ;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DrawAce(Suits.Hearts);
            DrawAce(Suits.Spades);
            DrawAce(Suits.Diamonds);
            DrawAce(Suits.Clubs);
        }
    }
}
