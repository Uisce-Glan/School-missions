// See https://aka.ms/new-console-template for more information
for (int y = -10; y < 9; y++)
{
    for (int x = 1; x < 79; x++)
    {
        double r = 0;
        double i = 0;
        int k = -1;
        while (r * r + i * i < 11 && k < 112)
        {
            double t = r;
            r = t * t - i * i - 2.3 + x / 24.5;
            i = 2 * t * i + y / 8.5;
            k++;
        }
        int c = k % 16;
        Console.BackgroundColor = (ConsoleColor)c;
        Console.Write(" ");
    }
    Console.WriteLine();
}
