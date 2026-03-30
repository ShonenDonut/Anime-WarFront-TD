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

        // =========================
        // CHANGED:
        // was: Time.timeScale = 0f;
        // now: pause through GameManager
        // =========================
        if (GameManager.Instance != null)
            GameManager.Instance.PauseForStore();
    }

    public void CloseStore()
    {
        if (storePanel != null)
            storePanel.SetActive(false);

        // =========================
        // CHANGED:
        // was: Time.timeScale = 1f;
        // now: restore current speed (1x or 2x)
        // =========================
        if (GameManager.Instance != null)
            GameManager.Instance.ResumeFromStore();
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