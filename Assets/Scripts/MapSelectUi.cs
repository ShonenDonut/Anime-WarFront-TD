using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectUi : MonoBehaviour
{
    public void LoadForestMap()
    {
        SceneManager.LoadScene("Gameplay_Forest");
    }

    public void LoadDesertMap()
    {
        SceneManager.LoadScene("Gameplay_Desert");
    }

    public void LoadCityMap()
    {
        SceneManager.LoadScene("Gameplay_City");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}