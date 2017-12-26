using System;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
            Console.WriteLine(new Box<int>(Convert.ToInt32(Console.ReadLine())));
    }
}
