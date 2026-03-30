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

    // =========================
    // ADDED: speed settings
    // =========================
    [Header("Speed Settings")]
    public float normalSpeed = 1f;
    public float fastSpeed = 2f;

    [Header("HUD")]
    public TMP_Text healthText;
    public TMP_Text currencyText;
    public TMP_Text waveText;
    public TMP_Text scoreText;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;

    // =========================
    // ADDED: store current speed + paused state
    // =========================
    private float currentSpeed = 1f;
    private bool isPaused = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // =========================
        // CHANGED:
        // was: Time.timeScale = 1f;
        // now: initialize speed state properly
        // =========================
        currentSpeed = normalSpeed;
        isPaused = false;
        ApplyTimeScale();

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateHUD();
    }

    // =========================
    // ADDED:
    // press F to switch 1x <-> 2x
    // =========================
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleSpeed();
        }
    }

    // =========================
    // ADDED:
    // one place that controls time scale
    // =========================
    private void ApplyTimeScale()
    {
        Time.timeScale = isPaused ? 0f : currentSpeed;
    }

    // =========================
    // ADDED:
    // toggle between 1x and 2x
    // =========================
    public void ToggleSpeed()
    {
        if (Mathf.Approximately(currentSpeed, normalSpeed))
            currentSpeed = fastSpeed;
        else
            currentSpeed = normalSpeed;

        ApplyTimeScale();
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
        // =========================
        // CHANGED:
        // was: Time.timeScale = 0f;
        // now: pause through state system
        // =========================
        isPaused = true;
        ApplyTimeScale();

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        // =========================
        // CHANGED:
        // was: Time.timeScale = 1f;
        // now: restore saved speed (1x or 2x)
        // =========================
        isPaused = false;
        ApplyTimeScale();
    }

    // =========================
    // ADDED:
    // store-specific pause helpers
    // =========================
    public void PauseForStore()
    {
        isPaused = true;
        ApplyTimeScale();
    }

    public void ResumeFromStore()
    {
        isPaused = false;
        ApplyTimeScale();
    }

    public void RestartLevel()
    {
        // UNCHANGED
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitToMainMenu()
    {
        // UNCHANGED
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void GameOver()
    {
        // =========================
        // CHANGED:
        // was: Time.timeScale = 0f;
        // now: use pause state system
        // =========================
        isPaused = true;
        ApplyTimeScale();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score;
    }
}