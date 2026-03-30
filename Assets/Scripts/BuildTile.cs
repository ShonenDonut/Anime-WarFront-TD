using UnityEngine;
using UnityEngine.EventSystems;

public class BuildTile : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    private GameObject placedTower;

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        
        if (placedTower != null)
        {
            Debug.Log("This tile already has a tower.");
            return;
        }

        if (towerPrefab == null)
        {
            Debug.LogWarning("Tower prefab is missing on " + gameObject.name);
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager instance is missing.");
            return;
        }

        if (!GameManager.Instance.CanAffordTower())
        {
            Debug.Log("Not enough currency.");
            return;
        }
        
        placedTower = Instantiate(towerPrefab, transform.position, Quaternion.identity, TowerManager.instance.transform);
        GameManager.Instance.SpendCurrency(GameManager.Instance.basicTowerCost);
    }
}