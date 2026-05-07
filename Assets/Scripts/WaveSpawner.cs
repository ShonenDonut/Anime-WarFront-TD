using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform[] waypoints;

    public float spawnDelay = 1.5f;
    public int startingEnemiesPerWave = 5;

    private int currentWave = 1;
    private int spawnedThisWave = 0;
    private int enemiesPerWave;

    private bool waveInProgress = false;

    private void Start()
    {
        enemiesPerWave = startingEnemiesPerWave;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetWave(currentWave);
        }
    }

    public void StartWave()
    {
        if (waveInProgress)
            return;

        waveInProgress = true;
        spawnedThisWave = 0;

        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (spawnedThisWave >= enemiesPerWave)
        {
            EndWave();
            return;
        }

        GameObject enemyObj = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        Enemy enemy = enemyObj.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.waypoints = waypoints;
            enemy.InitializeEnemy(currentWave);
        }

        spawnedThisWave++;
    }

    private void EndWave()
    {
        CancelInvoke(nameof(SpawnEnemy));

        waveInProgress = false;

        currentWave++;

        enemiesPerWave += 2;

        spawnDelay = Mathf.Max(0.5f, spawnDelay - 0.05f);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetWave(currentWave);
        }
    }
}