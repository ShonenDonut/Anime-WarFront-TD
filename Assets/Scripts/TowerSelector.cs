using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public static TowerSelector Instance;

    public GameObject basicTowerPrefab;
    public GameObject fastTowerPrefab;
    public GameObject strongTowerPrefab;

    private GameObject selectedTowerPrefab;

    private void Awake()
    {
        Instance = this;
        selectedTowerPrefab = basicTowerPrefab;
    }

    public void SelectBasicTower()
    {
        selectedTowerPrefab = basicTowerPrefab;
        Debug.Log("Basic Tower selected");
    }

    public void SelectFastTower()
    {
        selectedTowerPrefab = fastTowerPrefab;
        Debug.Log("Fast Tower selected");
    }

    public void SelectStrongTower()
    {
        selectedTowerPrefab = strongTowerPrefab;
        Debug.Log("Strong Tower selected");
    }

    public GameObject GetSelectedTowerPrefab()
    {
        return selectedTowerPrefab;
    }
}