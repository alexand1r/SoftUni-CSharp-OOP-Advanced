using System;
using System.Collections.Generic;

public class GenericBoxString
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
            Console.WriteLine(new Box<string>(Console.ReadLine()));
    }
}