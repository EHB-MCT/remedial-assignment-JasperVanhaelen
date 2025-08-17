using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }

    public Gem(int id, string name, float price)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = 0;
    }
}
