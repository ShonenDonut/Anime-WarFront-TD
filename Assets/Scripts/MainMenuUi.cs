using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("MapSelect");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void OpenUnits()
    {
        SceneManager.LoadScene("UnitsMenu");
    }

    public void OpenMapSelect()
    {
        SceneManager.LoadScene("MapSelect");
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }
}