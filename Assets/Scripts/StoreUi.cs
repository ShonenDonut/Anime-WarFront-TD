using TMPro;
using UnityEngine;

public class StoreUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject storePanel;

    [Header("UI Text")]
    public TMP_Text currencyText;

    [Header("Upgrade Costs")]
    public int damageUpgradeCost = 50;
    public int fireRateUpgradeCost = 50;

    public void OpenStore()
    {
        if (storePanel != null)
            storePanel.SetActive(true);

        RefreshUI();
        Time.timeScale = 0f;
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

        Tower[] towers = FindObjectsOfType<Tower>();
        foreach (Tower tower in towers)
        {
            tower.damage += 2;
        }

        RefreshUI();
    }

    public void UpgradeFireRate()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.currency < fireRateUpgradeCost) return;

        GameManager.Instance.SpendCurrency(fireRateUpgradeCost);

        Tower[] towers = FindObjectsOfType<Tower>();
        foreach (Tower tower in towers)
        {
            tower.fireRate += 0.5f;
        }

        RefreshUI();
    }

    public void RefreshUI()
    {
        if (currencyText != null && GameManager.Instance != null)
        {
            currencyText.text = "Currency: " + GameManager.Instance.currency;
        }
    }
}