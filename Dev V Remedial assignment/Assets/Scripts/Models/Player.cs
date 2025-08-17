using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public float Money { get; set; }
    public List<Gem> Inventory { get; set; }

    public Player(float startingMoney)
    {
        Money = startingMoney;
        Inventory = new List<Gem>();
    }
}