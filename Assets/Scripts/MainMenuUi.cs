using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void OpenUnits()
    {
        SceneManager.LoadScene("UnitsMenu");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}