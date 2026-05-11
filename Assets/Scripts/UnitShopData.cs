using UnityEngine;

public static class UnitShopData
{
    public static bool IsUnitOwned(string unitName)
    {
        return PlayerPrefs.GetInt(unitName + "_Owned", 0) == 1;
    }

    public static void OwnUnit(string unitName)
    {
        PlayerPrefs.SetInt(unitName + "_Owned", 1);
        PlayerPrefs.Save();
    }

    public static void SelectUnit(string unitName)
    {
        PlayerPrefs.SetString("SelectedUnit", unitName);
        PlayerPrefs.Save();
    }

    public static string GetSelectedUnit()
    {
        return PlayerPrefs.GetString("SelectedUnit", "Goku");
    }
}
