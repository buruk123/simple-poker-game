using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TestScript : MonoBehaviour
{
    public Button GetPlayerCards;
    public Player Player1;
    public Player Player2;

    private const int numsOfCardsOnDeck = 5;
    private List<Card> deck;
    private Random random = new Random();


    private void Start()
    {
        CreatePlayer("TEST"); //TODO: Nickname
        CreateDeckOfCards();
        GetPlayerCards.onClick.AddListener(GiveCardsToPlayersAndShowDeck);
    }

    private void CreateDeckOfCards()
    {
        deck = new List<Card>();
        var ranks = EnumUtil.GetValues<CardsRank>();
        var colors = EnumUtil.GetValues<CardsColor>();
        var powerOfRank = 1;
        var powerOfColor = 1;
        foreach (var rank in ranks)
        {
            foreach (var color in colors)
            {
                deck.Add(new Card(rank, color, powerOfRank, powerOfColor));
                powerOfColor++;
            }

            powerOfRank++;
            powerOfColor = 1;
        }
    }

    private void CreatePlayer(string nickname)
    {
        Player1 = new Player(nickname + "01");
        Player2 = new Player(nickname + "02");
    }

    private void GiveCardsToPlayersAndShowDeck()
    {
        var card1 = GetRandomCard();
        var card2 = GetRandomCard();
        Player1.GiveCardsToPlayer(card1, card2);
        Debug.Log("____________________________");
        var card3 = GetRandomCard();
        var card4 = GetRandomCard();
        Player2.GiveCardsToPlayer(card3, card4);
        Debug.Log("____________________________");
        var deckOfCards = GetDeck();
        Debug.Log("____________________________");
        CompareCardsAndDeck(Player1, deckOfCards);
        Debug.Log("____________________________");
        CompareCardsAndDeck(Player2, deckOfCards);

    }

    private IEnumerable<Card> GetDeck()
    {
        Card[] deckCards = new Card[numsOfCardsOnDeck];
        for (var i = 0; i < deckCards.Length; i++)
        {
            deckCards[i] = GetRandomCard();
            Debug.Log(deckCards[i].Rank + " of " + deckCards[i].Color);
        }

        return deckCards.ToList();
    }

    private Card GetRandomCard()
    {
        var index = random.Next(0, deck.Count);
        var card = deck[index];
        deck.RemoveAt(index);
        return card;
    }

    private void CompareCardsAndDeck(Player player, IEnumerable<Card> deckCards)
    {
        CheckForPair(player, deckCards);
    }

    private void CheckForPair(Player player, IEnumerable<Card> deckCards)
    {
        var power = 0;
        Card bestCard = null;
        var isPlayerGotPair = false;
        if (player.Card1.PowerOfRank == player.Card2.PowerOfRank)
        {
            power = player.Card1.PowerOfRank;
            bestCard = player.Card1;
            isPlayerGotPair = true;
        }

        foreach (var card in deckCards)
        {
            if (player.Card1.PowerOfRank == card.PowerOfRank)
            {
                if (power < player.Card1.PowerOfRank)
                {
                    power = player.Card1.PowerOfRank;
                    bestCard = player.Card1;
                    isPlayerGotPair = true;
                }
            }

            if (player.Card2.PowerOfRank == card.PowerOfRank)
            {
                if (power < player.Card2.PowerOfRank)
                {
                    power = player.Card2.PowerOfRank;
                    bestCard = player.Card2;
                    isPlayerGotPair = true;
                }
            }
        }

        if (isPlayerGotPair)
        {
            Debug.Log(player.Nickname + " has a pair of " + bestCard.Rank);
        }

    }
}
