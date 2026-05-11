using UnityEngine;

public static class PlayerData
{
    public const string CurrencyKey = "PlayerCurrency";

    public static int GetCurrency()
    {
        return PlayerPrefs.GetInt(CurrencyKey, 100);
    }

    public static void SetCurrency(int amount)
    {
        PlayerPrefs.SetInt(CurrencyKey, amount);
        PlayerPrefs.Save();
    }

    public static bool CanAfford(int cost)
    {
        return GetCurrency() >= cost;
    }

    public static void SpendCurrency(int cost)
    {
        SetCurrency(GetCurrency() - cost);
    }
}