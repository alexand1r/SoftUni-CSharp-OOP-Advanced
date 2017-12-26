using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        var attr = (TypeInfoAttribute)
        (Console.ReadLine() == "Rank"
            ? typeof(CardRank).GetCustomAttributes(typeof(TypeInfoAttribute), false)[0]
            : typeof(CardSuit).GetCustomAttributes(typeof(TypeInfoAttribute), false)[0]);

        Console.WriteLine(attr);
    }
}

class TypeInfoAttribute : Attribute
{
    public ObjectType Type { get; set; }
    public string Description { get; set; }
    public ObjectCategory Category { get; set; }

    public override string ToString()
    {
        return new StringBuilder($"Type = {this.Type}, Description = {this.Description}").ToString();
    }
}

enum ObjectType
{
    Enumeration,
    Class
}

enum ObjectCategory
{
    Rank,
    Suit
}

[TypeInfo(
    Type = ObjectType.Enumeration,
    Description = "Provides rank constants for a Card class.",
    Category = ObjectCategory.Rank)]
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

[TypeInfo(
    Type = ObjectType.Enumeration,
    Description = "Provides suit constants for a Card class.",
    Category = ObjectCategory.Suit)]
enum CardSuit
{
    Clubs = 0,
    Diamonds = 1,
    Hearts = 2,
    Spades = 3
}