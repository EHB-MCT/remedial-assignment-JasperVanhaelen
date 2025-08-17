using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public int money = 500; // Starting money for the player
    public TextMeshProUGUI moneyText;   // UI text displaying money

    public Gem[] gems;  // All gem types handled by this manager

    void Start()
    {
        UpdateUI();

        // Attach buy/sell listeners for each gem
        foreach (Gem gem in gems)
        {
            Gem capturedGem = gem; // avoid closure bug
            gem.buyButton.onClick.AddListener(() => BuyGem(capturedGem));
            gem.sellButton.onClick.AddListener(() => SellGem(capturedGem));
        }
    }

    void BuyGem(Gem gem)
    {
        if (money >= gem.price)
        {
            money -= gem.price;
            gem.quantity++;
            UpdateUI();
        }
    }

    void SellGem(Gem gem)
    {
        if (gem.quantity > 0)
        {
            money += gem.price;
            gem.quantity--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        moneyText.text = "Money: $" + money;
        foreach (Gem gem in gems)
        {
            if (gem.costText != null)
                gem.costText.text = "Cost: $" + gem.price;

            if (gem.ownedText != null)
                gem.ownedText.text = "Owned: " + gem.quantity;
        }
    }
}
