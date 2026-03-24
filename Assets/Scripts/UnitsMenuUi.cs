using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitsMenuUI : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}