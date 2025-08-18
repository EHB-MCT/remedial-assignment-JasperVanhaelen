using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Transaction
{
    public int GemId { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
    public bool IsPurchase { get; set; } // true = buy, false = sell
}
