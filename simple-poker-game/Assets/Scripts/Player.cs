using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Player
{
    public const int CARDSINHAND = 2;

    public Card[] Cards;

    public string Nickname;

    public List<Card> PlayerFinalDeck;

    public Player(string nickname)
    {
        this.Nickname = nickname;
        Cards = new Card[CARDSINHAND];
        PlayerFinalDeck = new List<Card>();
    }
}
