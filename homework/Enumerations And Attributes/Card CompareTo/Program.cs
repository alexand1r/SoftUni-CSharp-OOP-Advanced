using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var rank = Console.ReadLine().Trim();
        var suit = Console.ReadLine().Trim();

        var card1 = new Card(rank, suit);

        rank = Console.ReadLine().Trim();
        suit = Console.ReadLine().Trim();

        var card2 = new Card(rank, suit);

        Console.WriteLine(card1.CompareTo(card2) > 0 ? card1 : card2);
    }
}
