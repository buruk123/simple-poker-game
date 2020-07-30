using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    public class Deck
    {
        public List<Card> Cards
        {
            get => deck;
            private set => deck = value;
        }

        public List<Card> AllCards
        {
            get => allCards;
            private set => allCards = value;
        }

        public const int CARDSONDECK = 5;

        private List<Card> deck;
        private List<Card> allCards;

        private Random random;

        public Deck()
        {
            random = new Random();
            Cards = new List<Card>();
            AllCards = new List<Card>();

            var ranks = EnumUtil.GetValues<CardsRank>();
            var colors = EnumUtil.GetValues<CardsColor>();
            var powerOfRank = 1;
            var powerOfColor = 1;

            foreach (var rank in ranks)
            {
                foreach (var color in colors)
                {
                    allCards.Add(new Card(rank, color, powerOfRank, powerOfColor));
                    powerOfColor++;
                }

                powerOfRank++;
                powerOfColor = 1;
            }
        }

        public void CreateDeck()
        {
            for (var i = 0; i < CARDSONDECK; i++)
            {
                var index = random.Next(0, allCards.Count);
                Cards.Add(allCards[random.Next(0, allCards.Count)]);
                AllCards.RemoveAt(index);
            }
            SortDeck(Cards);
            PrintDeck(Cards);
        }

        public void ReturnDeck()
        {
            for (var i = 0; i < CARDSONDECK; i++)
            {
                AllCards.Add(Cards[0]);
                Cards.RemoveAt(0);
            }
        }

        public void GiveCardsToPlayer(Player player)
        {
            for (var i = 0; i < Player.CARDSINHAND; i++)
            {
                var index = random.Next(0, AllCards.Count);
                var card = AllCards[index];
                player.Cards[i] = card;
                AllCards.RemoveAt(index);
            }
        }

        public void ReturnPlayerCards(Player player)
        {
            for (var i = 0; i < Player.CARDSINHAND; i++)
            {
                AllCards.Add(player.Cards[i]);
                player.Cards[i] = null;
            }
        }

        public void PrintDeck(List<Card> deck)
        {
            foreach (var card in deck)
            {
                Debug.Log(card.Rank + " of " + card.Color);
            }
        }

        public void SortDeck(List<Card> deck)
        {
            deck.Sort(Comparison);
        }

        private int Comparison(Card x, Card y)
        {
            if (x.Rank > y.Rank) return 1;
            if (x.Rank == y.Rank) return 0;
            return -1;
        }
    }
}
