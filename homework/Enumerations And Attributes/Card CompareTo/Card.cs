using System;
using System.Collections.Generic;
using System.Text;

class Card : IComparable<Card>
{
    private static readonly Dictionary<CardRank, int> RankPowers = new Dictionary<CardRank, int>
    {
        {CardRank.Two, 2}, {CardRank.Three, 3}, {CardRank.Four, 4},
        {CardRank.Five, 5}, {CardRank.Six, 6}, {CardRank.Seven, 7}, {CardRank.Eight, 8},
        {CardRank.Nine, 9}, {CardRank.Ten, 10}, {CardRank.Jack, 11}, {CardRank.Queen, 12},
        {CardRank.King, 13}, {CardRank.Ace, 14}
    };

    private static readonly Dictionary<CardSuit, int> SuitPowers = new Dictionary<CardSuit, int>
    {
        {CardSuit.Clubs, 0}, {CardSuit.Diamonds, 13}, {CardSuit.Hearts, 26}, {CardSuit.Spades, 39}
    };

    internal enum CardRank
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

    internal enum CardSuit
    {
        Clubs = 0,
        Diamonds = 1,
        Hearts = 2,
        Spades = 3
    }

    public CardRank Rank { get; }
    public CardSuit Suit { get; }

    public int GetPower()
    {
        return RankPowers[Rank] + SuitPowers[Suit];
    }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;

        var powerComparison = this.GetPower().CompareTo(other.GetPower());
        return powerComparison;
    }

    public override string ToString()
    {
        return new StringBuilder($"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetPower()}").ToString();
    }

    public Card(string rank, string suit)
    {
        this.Rank = (CardRank)Enum.Parse(typeof(CardRank), rank);
        this.Suit = (CardSuit)Enum.Parse(typeof(CardSuit), suit);
    }
}