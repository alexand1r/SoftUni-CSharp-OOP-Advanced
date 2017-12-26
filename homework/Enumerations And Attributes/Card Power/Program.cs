using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        var rank = Console.ReadLine().Trim();
        var suit = Console.ReadLine().Trim();
        Console.WriteLine(new Card(rank, suit));
    }
}