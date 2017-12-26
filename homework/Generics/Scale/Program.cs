using System;

class Program
{
    static void Main(string[] args)
    {
        var scale = new Scale<int>(2, 3);
        Console.WriteLine(scale.GetHavier());
    }
}
