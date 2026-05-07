using UnityEngine;

public class BuildTile : MonoBehaviour
{
    private GameObject placedTower;

    private void OnMouseDown()
    {
        if (placedTower != null)
        {
            Debug.Log("This tile already has a tower.");
            return;
        }

        if (TowerSelector.Instance == null)
        {
            Debug.LogWarning("TowerSelector is missing.");
            return;
        }

        GameObject towerPrefab = TowerSelector.Instance.GetSelectedTowerPrefab();

        if (towerPrefab == null)
        {
            Debug.LogWarning("Selected tower prefab is missing.");
            return;
        }

        Tower towerData = towerPrefab.GetComponent<Tower>();

        if (towerData == null)
        {
            Debug.LogWarning("Selected prefab has no Tower script.");
            return;
        }

        if (GameManager.Instance.currency < towerData.cost)
        {
            Debug.Log("Not enough currency.");
            return;
        }

        GameManager.Instance.SpendCurrency(towerData.cost);
        placedTower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
    }
}