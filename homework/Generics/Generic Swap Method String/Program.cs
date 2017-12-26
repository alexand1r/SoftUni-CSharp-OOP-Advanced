using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var boxes = new List<Box<int>>();

        for (int i = 0; i < n; i++)
            boxes.Add(new Box<int>(Convert.ToInt32(Console.ReadLine())));

        var swapPositions = Console.ReadLine().Trim().Split()
            .Select(int.Parse)
            .ToArray();

        Swap(boxes, swapPositions[0], swapPositions[1]);

        boxes.ForEach(Console.WriteLine);
    }

    public static void Swap<TList>(List<TList> list, int a, int b)
    {
        var temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }
}
