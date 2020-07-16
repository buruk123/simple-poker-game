using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        foreach (var rank in ranks)
        {
            foreach (var color in colors)
            {
                deck.Add(new Card(rank, color));
            }
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
        ShowDeck();
        Debug.Log("____________________________");
    }

    private void ShowDeck()
    {
        Card[] deckCards = new Card[numsOfCardsOnDeck];
        for (var i = 0; i < deckCards.Length; i++)
        {
            deckCards[i] = GetRandomCard();
        }
    }

    private Card GetRandomCard()
    {
        var index = random.Next(0, deck.Count);
        var card = deck[index];
        deck.RemoveAt(index);
        Debug.Log(card.Rank + " of " + card.Color + " " + index);
        return card;
    }
}
