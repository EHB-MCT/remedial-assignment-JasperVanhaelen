using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// A serializable Gem object that can be stored in player inventory
[System.Serializable]
public class Gem
{
    [Header("Data")]
    public int id;
    public string name;
    public int price;
    public int quantity;    // How many owned

    [Header("UI References")]
    public TextMeshProUGUI costText;
    public TextMeshProUGUI ownedText;
    public Button buyButton;
    public Button sellButton;

    public Gem(int id, string name, int price)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.quantity = 0;
    }
}
