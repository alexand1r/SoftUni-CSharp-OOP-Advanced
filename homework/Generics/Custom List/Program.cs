using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var myList = new CustomList<string>();
        while (true)
        {
            var input = Console.ReadLine().Trim().Split();

            if (input[0].Equals("End", StringComparison.OrdinalIgnoreCase))
                break;

            string element;

            switch (input[0].ToLowerInvariant())
            {
                case "add":
                    element = input.Last();

                    myList.Add(element);
                    break;
                case "remove":
                    var index = int.Parse(input.Last());

                    myList.Remove(index);
                    break;
                case "max":
                    Console.WriteLine(myList.Max());
                    break;
                case "min":
                    Console.WriteLine(myList.Min());
                    break;
                case "greater":
                    var comparison = input.Last();

                    Console.WriteLine(myList.CountGreaterThan(comparison));
                    break;
                case "swap":
                    var index1 = int.Parse(input.Skip(1).First());
                    var index2 = int.Parse(input.Last());

                    myList.Swap(index1, index2);
                    break;
                case "contains":
                    element = input.Last();
                    Console.WriteLine(myList.Contains(element));
                    break;
                case "print":
                    myList.Print();
                    break;
                case "sort":
                    Sorter.Sort(myList);
                    break;
            }
        }
    }
}
