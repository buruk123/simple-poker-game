using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Card
{
    public CardsRank Rank { get; set; }
    public CardsColor Color { get; set; }

    public Card(CardsRank rank, CardsColor color)
    {
        this.Rank = rank;
        this.Color = color;
    }

}
