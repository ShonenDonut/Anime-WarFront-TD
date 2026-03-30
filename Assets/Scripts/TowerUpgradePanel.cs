using TMPro;
using UnityEngine;

public class TowerUpgradePanel : MonoBehaviour
{
    public static TowerUpgradePanel instance;

    private void Awake()
    {
        instance = this;
    }
    
    [Header("Panels")]
    public GameObject storePanel;

    [Header("UI Text")]
    public TMP_Text damageCostText;
    public TMP_Text fireRateCostText;
    
    [Header("Upgrade Costs")]
    public int damageUpgradeCost = 50;
    public int fireRateUpgradeCost = 50;

    [Header("Upgrade Stats")] 
    public int damageIncrease = 2;
    public int fireRateIncrease = 2;
    
    [Header("Upgrade UI Offset")]
    public float xOffset;
    public float yOffset;

    private Tower _selectedTower;

    public void OpenStore()
    {
        if (!storePanel) return;

        storePanel.SetActive(true);
        storePanel.transform.position = OffsetPos();
        
        RefreshUI();
        Time.timeScale = 0f;
    }
    
    private Vector3 OffsetPos()
    {
        return new Vector3(
            Camera.main.WorldToScreenPoint(_selectedTower.transform.position).x + xOffset, 
            Camera.main.WorldToScreenPoint(_selectedTower.transform.position).y + yOffset, 
            0);
    }

    public void CloseStore()
    {
        if (storePanel != null)
            storePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void UpgradeDamage()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.currency < damageUpgradeCost) return;

        GameManager.Instance.SpendCurrency(damageUpgradeCost);

        /*Tower[] towers = FindObjectsOfType<Tower>();
        foreach (Tower tower in towers)
        {
            tower.damage += 2;
        }*/
        if (!_selectedTower) return;
        _selectedTower.damage += damageIncrease;

        RefreshUI();
    }

    public void UpgradeFireRate()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.currency < fireRateUpgradeCost) return;

        GameManager.Instance.SpendCurrency(fireRateUpgradeCost);

        /*Tower[] towers = FindObjectsOfType<Tower>();
        foreach (Tower tower in towers)
        {
            tower.fireRate += 0.5f;
        }*/
        
        if(!_selectedTower) return;
        _selectedTower.fireRate += fireRateIncrease;

        RefreshUI();
    }

    public void RefreshUI()
    {
        damageCostText.text = "Cost: " + damageUpgradeCost;
        fireRateCostText.text = "Cost: " + fireRateUpgradeCost;
    }
    
    public int GetFireRateUpgradeCost(){ return fireRateUpgradeCost; }
    public int GetDamageUpgradeCost(){ return damageUpgradeCost; }

    public void SetSelectedTower(Tower newTower)
    {
        _selectedTower = newTower;
    }
}