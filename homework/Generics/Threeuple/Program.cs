using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var line1 = Console.ReadLine().Split();

        Console.WriteLine(new Threeuple<string, string, string>
        {
            Item1 = line1.First() + " " + line1.Skip(1).First(),
            Item2 = line1.Skip(2).First(),
            Item3 = line1.Last()
        });

        var line2 = Console.ReadLine().Split();

        Console.WriteLine(new Threeuple<string, int, bool>
        {
            Item1 = line2.First(),
            Item2 = int.Parse(line2.Skip(1).First()),
            Item3 = line2.Last() == "drunk"
        });

        var line3 = Console.ReadLine().Split();

        Console.WriteLine(new Threeuple<string, double, string>
        {
            Item1 = line3.First(),
            Item2 = double.Parse(line3.Skip(1).First()),
            Item3 = line3.Last()
        });
    }
}
