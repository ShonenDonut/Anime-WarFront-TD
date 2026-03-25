using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform[] waypoints;
    public float spawnDelay = 2f;
    public int enemiesPerWave = 5;

    private int currentWave = 1;
    private int spawnedThisWave = 0;
    private bool waveInProgress = false;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetWave(currentWave);
        }
    }

    public void StartWave()
    {
        if (waveInProgress) return;

        waveInProgress = true;
        spawnedThisWave = 0;

        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (spawnedThisWave >= enemiesPerWave)
        {
            CancelInvoke(nameof(SpawnEnemy));
            waveInProgress = false;
            return;
        }

        GameObject enemyObj = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.waypoints = waypoints;
        }

        spawnedThisWave++;
    }
}