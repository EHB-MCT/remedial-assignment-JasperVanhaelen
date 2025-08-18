using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Gem
{
    [Header("Data")]
    public int id;  // DB id
    public string name;
    public int price;
    public int quantity;    // Owned quantity

    [Header("UI References")]
    public TextMeshProUGUI costText;    // Shows price
    public TextMeshProUGUI ownedText;   // Shows owned amount
    public Button buyButton;
    public Button sellButton;

    // Constructor for creating Gem objects programmatically
    public Gem(int id, string name, int price)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.quantity = 0;
    }
}
