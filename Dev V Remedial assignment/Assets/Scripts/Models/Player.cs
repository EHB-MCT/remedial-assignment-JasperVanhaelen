using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents the player and their inventory
[System.Serializable]
public class Player
{
    public float money;                   // Current money balance
    public List<Gem> inventory;           // Collection of owned gems

    public Player(float startingMoney)
    {
        money = startingMoney;
        inventory = new List<Gem>();
    }
}
