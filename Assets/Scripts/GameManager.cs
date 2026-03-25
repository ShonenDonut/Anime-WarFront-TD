using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Stats")]
    public int baseHealth = 10;
    public int currency = 100;
    public int waveNumber = 1;
    public int score = 0;
    public int basicTowerCost = 25;

    [Header("HUD")]
    public TMP_Text healthText;
    public TMP_Text currencyText;
    public TMP_Text waveText;
    public TMP_Text scoreText;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateHUD();
    }

    public bool CanAffordTower()
    {
        return currency >= basicTowerCost;
    }

    public void SpendCurrency(int amount)
    {
        currency -= amount;
        UpdateHUD();
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        score += amount;
        UpdateHUD();
    }

    public void TakeBaseDamage(int amount)
    {
        baseHealth -= amount;

        if (baseHealth < 0)
            baseHealth = 0;

        UpdateHUD();

        if (baseHealth <= 0)
        {
            GameOver();
        }
    }

    public void SetWave(int newWave)
    {
        waveNumber = newWave;
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        if (healthText != null)
            healthText.text = "Health: " + baseHealth;

        if (currencyText != null)
            currencyText.text = "Currency: " + currency;

        if (waveText != null)
            waveText.text = "Wave: " + waveNumber;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void GameOver()
    {
        Time.timeScale = 0f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score;
    }
}