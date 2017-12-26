using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Card Suits:");

        foreach (CardSuit value in Enum.GetValues(typeof(CardSuit)))
            Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");

    }
}

public enum CardSuit
{
    Clubs = 0,
    Diamonds = 1,
    Hearts = 2,
    Spades = 3
}
