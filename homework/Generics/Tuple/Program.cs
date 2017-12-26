using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var line1 = Console.ReadLine().Split();

        Console.WriteLine(new Tuple<string, string>
        {
            Item1 = line1.First() + " " + line1.Skip(1).First(),
            Item2 = line1.Last()
        });

        var line2 = Console.ReadLine().Split();

        Console.WriteLine(new Tuple<string, int>(line2.First(), int.Parse(line2.Last())));

        var line3 = Console.ReadLine().Split();

        Console.WriteLine(new Tuple<int, double>(int.Parse(line3.First()), double.Parse(line3.Last())));
    }
}
