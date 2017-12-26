using System;

class Program
{
    public static void Main()
    {
        foreach (CardSuit suit in typeof(CardSuit).GetEnumValues())
        {
            foreach (CardRank rank in typeof(CardRank).GetEnumValues())
            {
                Console.WriteLine($"{rank} of {suit}");
            }
        }
    }
}

enum CardRank
{
    Ace = 0,
    Two = 1,
    Three = 2,
    Four = 3,
    Five = 4,
    Six = 5,
    Seven = 6,
    Eight = 7,
    Nine = 8,
    Ten = 9,
    Jack = 10,
    Queen = 11,
    King = 12
}

enum CardSuit
{
    Clubs = 0,
    Hearts = 1,
    Diamonds = 2,
    Spades = 3
}