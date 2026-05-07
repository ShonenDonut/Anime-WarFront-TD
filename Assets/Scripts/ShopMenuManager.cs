using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuManager : MonoBehaviour
{
    [Header("Currency")]
    public int currency = 100;
    public TMP_Text currencyText;

    [Header("Button Status Text")]
    public TMP_Text basicStatusText;
    public TMP_Text fastStatusText;
    public TMP_Text strongStatusText;

    private void Start()
    {
        // Basic tower is owned by default
        ShopData.OwnTower("BasicTower");

        UpdateUI();
    }

    public void BuyBasicTower()
    {
        BuyTower("BasicTower", 0);
    }

    public void BuyFastTower()
    {
        BuyTower("FastTower", 40);
    }

    public void BuyStrongTower()
    {
        BuyTower("StrongTower", 60);
    }

    private void BuyTower(string towerName, int cost)
    {
        if (ShopData.IsTowerOwned(towerName))
        {
            ShopData.SelectTower(towerName);
            Debug.Log(towerName + " selected.");
            UpdateUI();
            return;
        }

        if (currency < cost)
        {
            Debug.Log("Not enough currency.");
            return;
        }

        currency -= cost;
        ShopData.OwnTower(towerName);
        ShopData.SelectTower(towerName);

        Debug.Log(towerName + " purchased and selected.");
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currencyText != null)
            currencyText.text = "Currency: " + currency;

        if (basicStatusText != null)
            basicStatusText.text = ShopData.GetSelectedTower() == "BasicTower" ? "Selected" : "Owned";

        if (fastStatusText != null)
            fastStatusText.text = ShopData.IsTowerOwned("FastTower")
                ? (ShopData.GetSelectedTower() == "FastTower" ? "Selected" : "Owned")
                : "Cost: 40";

        if (strongStatusText != null)
            strongStatusText.text = ShopData.IsTowerOwned("StrongTower")
                ? (ShopData.GetSelectedTower() == "StrongTower" ? "Selected" : "Owned")
                : "Cost: 60";
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}