using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Card
{
    public CardsRank Rank { get; set; }
    public CardsColor Color { get; set; }
    public int PowerOfRank { get; set; }
    public int PowerOfColor { get; set; }

    public Card(CardsRank rank, CardsColor color, int powerOfRank, int powerOfColor)
    {
        this.Rank = rank;
        this.Color = color;
        this.PowerOfRank = powerOfRank;
        this.PowerOfColor = powerOfColor;
    }

}
