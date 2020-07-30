using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts;
using Assets.Scripts.Util;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TestScript : MonoBehaviour
{
    public Button StartRoundButton;
    public Player Player1;
    public Player Player2;

    public Deck deck;

    private Random random;

    private void Start()
    {
        random = new Random();
        deck = new Deck();
        Player1 = CreatePlayer("TEST01");
        Player2 = CreatePlayer("TEST02");
        StartRoundButton.onClick.AddListener(GiveCardsToPlayersAndShowDeck);
    }

    private Player CreatePlayer(string nickname)
    {
        return new Player(nickname);
    }

    private void GiveCardsToPlayersAndShowDeck()
    {
        CreateDeck();
        GiveCardsToPlayer(Player1);
        Debug.Log("____________________________");
        GiveCardsToPlayer(Player2);
        Debug.Log("____________________________");
        CompareCardsAndDeck(Player1, deck.Cards);
        Debug.Log("____________________________");
        CompareCardsAndDeck(Player2, deck.Cards);
        ReturnCardsToDeck();
    }

    private void CreateDeck()
    {
        deck.CreateDeck();
        Player1.PlayerFinalDeck = new List<Card>(deck.Cards);
        Player2.PlayerFinalDeck = new List<Card>(deck.Cards);
    }

    private void GiveCardsToPlayer(Player player)
    {
        deck.GiveCardsToPlayer(player);
        Debug.Log(player.Nickname + ": " + player.Cards[0].Rank + " of " + player.Cards[0].Color + " | " + player.Cards[1].Rank + " of " + player.Cards[1].Color);
    }

    private void ReturnCardsToDeck()
    {
        deck.ReturnDeck();
        deck.ReturnPlayerCards(Player1);
        deck.ReturnPlayerCards(Player2);
    }

    private void CompareCardsAndDeck(Player player, List<Card> deck)
    {
        var (pokerHands, bestCard1, bestCard2) = CheckForHighCard(player, deck, player.PlayerFinalDeck);
        Debug.Log(player.Nickname + " has a " + pokerHands + " on " + bestCard1.Rank + " and " + bestCard2.Rank);
    }

    private (PokerHands, Card, Card) CheckForHighCard(Player player, List<Card> deckOfCards, List<Card> playerDeck)
    {
        for (var i = 0; i < Player.CARDSINHAND; i++)
        {
            if (player.Cards[i].Rank > deckOfCards[i].Rank)
            {
                Extensions.Replace(playerDeck, deckOfCards[i], player.Cards[i]);
            }
        }
        deck.SortDeck(playerDeck);
        return (PokerHands.HighCard, playerDeck[Deck.CARDSONDECK - 1], playerDeck[Deck.CARDSONDECK - 2]);
    }
}
