using System;
using System.Collections.Generic;
using System.Text;

class Card : IComparable<Card>, IEquatable<Card>
{
    internal static readonly Dictionary<CardRank, int> RankPowers = new Dictionary<CardRank, int>
    {
        {CardRank.Two, 2}, {CardRank.Three, 3}, {CardRank.Four, 4},
        {CardRank.Five, 5}, {CardRank.Six, 6}, {CardRank.Seven, 7}, {CardRank.Eight, 8},
        {CardRank.Nine, 9}, {CardRank.Ten, 10}, {CardRank.Jack, 11}, {CardRank.Queen, 12},
        {CardRank.King, 13}, {CardRank.Ace, 14}
    };

    internal static readonly Dictionary<CardSuit, int> SuitPowers = new Dictionary<CardSuit, int>
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
        Hearts = 1,
        Diamonds = 2,
        Spades = 3
    }

    private readonly CardRank _rank;
    private readonly CardSuit _suit;

    public CardRank Rank => _rank;
    public CardSuit Suit => _suit;

    public int GetPower()
    {
        return RankPowers[Rank] + SuitPowers[Suit];
    }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;

        return this.GetPower().CompareTo(other.GetPower());
    }

    public bool Equals(Card other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _rank == other._rank && _suit == other._suit;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Card)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((int)_rank * 397) ^ (int)_suit;
        }
    }

    public override string ToString()
    {
        return new StringBuilder($"{this.Rank} of {this.Suit}").ToString();
    }

    public Card(string rank, string suit)
    {
        if (!CardRank.TryParse(rank, out _rank))
            throw new ArgumentException(ErrorMessages.InvalidCard);
        if (!CardSuit.TryParse(suit, out _suit))
            throw new ArgumentException(ErrorMessages.InvalidCard);
    }

    public Card(CardRank rank, CardSuit suit)
    {
        _rank = rank;
        _suit = suit;
    }
}