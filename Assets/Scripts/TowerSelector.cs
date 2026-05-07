using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public static TowerSelector Instance;

    public GameObject basicTowerPrefab;
    public GameObject fastTowerPrefab;
    public GameObject strongTowerPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetSelectedTowerPrefab()
    {
        string selectedTower = ShopData.GetSelectedTower();

        if (selectedTower == "FastTower")
            return fastTowerPrefab;

        if (selectedTower == "StrongTower")
            return strongTowerPrefab;

        return basicTowerPrefab;
    }
}
