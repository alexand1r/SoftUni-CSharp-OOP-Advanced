using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        var player1 = new Player(Console.ReadLine());
        var player2 = new Player(Console.ReadLine());

        var deck = new CardDeck();

        PopulateHand(player1, deck);
        PopulateHand(player2, deck);

        Console.WriteLine(Winner(player1, player2));
    }

    private static void PopulateHand(Player player, CardDeck deck)
    {
        while (player.Hand.Count != 5)
        {
            try
            {
                var cardData = Console.ReadLine().Trim()
                    .Split(new string[] { " of " }, StringSplitOptions.RemoveEmptyEntries);

                player.AddCard(deck.DistributeCard(cardData[0], cardData[1]));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }

    private static string Winner(Player player1, Player player2)
    {
        var player1BestCard = player1.GetBestCard();
        var player2BestCard = player2.GetBestCard();

        return player1BestCard.CompareTo(player2BestCard) > 0
            ? $"{player1.Name} wins with {player1BestCard}."
            : $"{player2.Name} wins with {player2BestCard}.";
    }
}
