using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Card Card1;
    public Card Card2;

    public string Nickname;

    public const int CardsInHand = 2;

    public Player(string nickname)
    {
        this.Nickname = nickname;
    }

    public void GiveCardsToPlayer(Card card1, Card card2)
    {
        this.Card1 = card1;
        this.Card2 = card2;
        Debug.Log(Nickname + ": " + card1.Rank + " of " + card1.Color + " | " + card2.Rank + " of " + card2.Color);
    }
}
