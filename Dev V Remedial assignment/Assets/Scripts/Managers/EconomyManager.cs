using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class EconomyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // UI text for player's money
    public Gem[] gems;  // Array of gems assigned in Inspector

    private Player player;

    void Start()
    {
        // Load player money from DB or start with default
        float money = EconomyDatabase.LoadMoney();
        player = new Player(money);

        // Load gems from DB
        List<GemData> loadedGems = EconomyDatabase.GetAllGems();

        for (int i = 0; i < gems.Length; i++)
        {
            if (i < loadedGems.Count)
            {
                // Assign DB values to Gem objects
                gems[i].id = loadedGems[i].Id;
                gems[i].name = loadedGems[i].Name;
                gems[i].price = loadedGems[i].Price;
                gems[i].quantity = loadedGems[i].Quantity;
            }

            // Add button listeners for buy/sell
            Gem capturedGem = gems[i];
            capturedGem.buyButton.onClick.AddListener(() => BuyGem(capturedGem));
            capturedGem.sellButton.onClick.AddListener(() => SellGem(capturedGem));
        }

        // Fluctuate gem prices immediately on game start
        EconomyDatabase.FluctuateGemPrices();

        // Set up repeated price fluctuation every 5 seconds
        InvokeRepeating(nameof(UpdateGemPrices), 5f, 5f);

        UpdateUI();
    }

    void BuyGem(Gem gem)
    {
        if (player.money >= gem.price)
        {
            player.money -= gem.price;
            gem.quantity++;

            // Save changes to DB
            EconomyDatabase.SaveOrUpdateGem(gem);
            EconomyDatabase.UpdateMoney(player.money);

            UpdateUI();
        }
    }

    void SellGem(Gem gem)
    {
        if (gem.quantity > 0)
        {
            player.money += gem.price;
            gem.quantity--;

            // Save changes to DB
            EconomyDatabase.SaveOrUpdateGem(gem);
            EconomyDatabase.UpdateMoney(player.money);

            UpdateUI();
        }
    }

    // Updates UI texts
    void UpdateUI()
    {
        moneyText.text = "Money: $" + player.money;

        foreach (Gem gem in gems)
        {
            if (gem.costText != null)
                gem.costText.text = "Cost: $" + gem.price;
            if (gem.ownedText != null)
                gem.ownedText.text = "Owned: " + gem.quantity;
        }
    }

    // Call this periodically to fluctuate gem prices in UI + DB
    void UpdateGemPrices()
    {
        EconomyDatabase.FluctuateGemPrices();

        // Refresh gems array with latest DB prices
        List<GemData> updatedGems = EconomyDatabase.GetAllGems();
        for (int i = 0; i < gems.Length && i < updatedGems.Count; i++)
        {
            gems[i].price = updatedGems[i].Price;
        }

        UpdateUI();
    }
}
