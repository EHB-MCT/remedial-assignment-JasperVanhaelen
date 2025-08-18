using System.Collections.Generic;
using SQLite;
using UnityEngine;

public static class EconomyDatabase
{
    private static SQLiteConnection db => Database.GetConnection();
    private const int PlayerId = 1; // Single row for player money

    // ---------------- MONEY METHODS ----------------
    public static float LoadMoney()
    {
        var playerMoney = db.Find<PlayerMoneyData>(PlayerId);
        if (playerMoney == null)
        {
            float startingMoney = 500f; 
            var newMoney = new PlayerMoneyData { Id = PlayerId, Money = startingMoney };
            db.Insert(newMoney);
            Debug.Log($"[Economy] New player created with ${startingMoney}");
            return startingMoney;
        }
        return playerMoney.Money;
    }

    public static void UpdateMoney(float amount)
    {
        amount = Mathf.Max(amount, 0f); // prevent negative money
        var playerMoney = db.Find<PlayerMoneyData>(PlayerId);
        if (playerMoney != null)
        {
            playerMoney.Money = amount;
            db.Update(playerMoney);
        }
        else
        {
            db.Insert(new PlayerMoneyData { Id = PlayerId, Money = amount });
        }
        Debug.Log($"[Economy] Money updated to ${amount}");
    }

    // ---------------- GEM METHODS ----------------
    public static void SaveOrUpdateGem(Gem gem)
    {
        var gemData = new GemData
        {
            Id = gem.id,
            Name = gem.name,
            Price = gem.price,
            Quantity = gem.quantity
        };

        if (db.Find<GemData>(gem.id) == null)
            db.Insert(gemData);
        else
            db.Update(gemData);
    }

    public static List<GemData> GetAllGems()
    {
        return db.Table<GemData>().ToList();
    }

    // ---------------- GEM PRICE FLUCTUATION ----------------
    /// Simple random price fluctuation with supply/demand effect
    public static void FluctuateGemPrices()
    {
        List<GemData> gems = GetAllGems();
        foreach (var gem in gems)
        {
            // Random factor between -10% and +10%
            float randomFactor = Random.Range(0.9f, 1.1f);

            // Supply/demand effect: fewer owned = higher price, more owned = lower price
            float demandFactor = 1f + (10f - gem.Quantity) * 0.01f; // tweak 0.01 for strength

            int newPrice = Mathf.Max(1, Mathf.RoundToInt(gem.Price * randomFactor * demandFactor));

            gem.Price = newPrice;
            db.Update(gem);
        }

        Debug.Log("[Economy] Gem prices fluctuated");
    }

    // ---------------- TRANSACTION METHODS ----------------
    public static void AddTransaction(Transaction transaction)
    {
        var t = new TransactionData
        {
            GemId = transaction.GemId,
            Quantity = transaction.Quantity,
            Price = transaction.Price,
            IsPurchase = transaction.IsPurchase,
            DateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };
        db.Insert(t);
    }

    public static List<TransactionData> GetAllTransactions()
    {
        return db.Table<TransactionData>().ToList();
    }
}

// ---------------- DATABASE TABLES ----------------
public class PlayerMoneyData
{
    [PrimaryKey] public int Id { get; set; }
    public float Money { get; set; }
}

public class GemData
{
    [PrimaryKey] public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}

public class TransactionData
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public int GemId { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
    public bool IsPurchase { get; set; }    // store transaction time
    public string DateTime { get; set; }    // store transaction time
}