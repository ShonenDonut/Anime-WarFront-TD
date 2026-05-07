public static class ShopData
{
    public const string SelectedTowerKey = "SelectedTower";

    public static bool IsTowerOwned(string towerName)
    {
        return UnityEngine.PlayerPrefs.GetInt(towerName + "_Owned", 0) == 1;
    }

    public static void OwnTower(string towerName)
    {
        UnityEngine.PlayerPrefs.SetInt(towerName + "_Owned", 1);
        UnityEngine.PlayerPrefs.Save();
    }

    public static void SelectTower(string towerName)
    {
        UnityEngine.PlayerPrefs.SetString(SelectedTowerKey, towerName);
        UnityEngine.PlayerPrefs.Save();
    }

    public static string GetSelectedTower()
    {
        return UnityEngine.PlayerPrefs.GetString(SelectedTowerKey, "BasicTower");
    }
}