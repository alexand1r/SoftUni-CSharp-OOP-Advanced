using System;
using System.Collections.Generic;

class CardDeck
{
    private readonly HashSet<Card> _cards;

    public Card DistributeCard(string rank, string suit)
    {
        var card = new Card(rank, suit);

        if (!_cards.Contains(card))
            throw new InvalidOperationException(ErrorMessages.CardAlreadyDistribted);

        _cards.Remove(card);

        return card;
    }

    public CardDeck()
    {
        _cards = new HashSet<Card>();

        foreach (Card.CardSuit cardSuit in typeof(Card.CardSuit).GetEnumValues())
        {
            foreach (Card.CardRank cardRank in typeof(Card.CardRank).GetEnumValues())
            {
                _cards.Add(new Card(cardRank, cardSuit));
            }
        }
    }
}