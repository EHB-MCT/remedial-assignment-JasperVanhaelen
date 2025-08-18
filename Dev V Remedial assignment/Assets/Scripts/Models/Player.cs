using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public float money; // Player's current money
    public List<Gem> inventory; // Reference to all gems

    public Player(float startingMoney)
    {
        money = startingMoney;
        inventory = new List<Gem>();
    }
}
