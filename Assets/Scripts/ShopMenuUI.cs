using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuUI : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
