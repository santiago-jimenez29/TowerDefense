
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject normalEnemyPrefab;
    public GameObject fastEnemyPrefab;

    public Transform spawnPoint;
    public Transform[] waypoints;

    public float spawnInterval = 1.5f;
    public float timeBetweenWaves = 4f;
    public float preparationTime = 5f;

    private GameManager manager;

    IEnumerator Start()
    {
        manager = FindFirstObjectByType<GameManager>();

        if (manager == null ||
            normalEnemyPrefab == null ||
            fastEnemyPrefab == null ||
            spawnPoint == null ||
            waypoints == null ||
            waypoints.Length != 4)
        {
            Debug.LogError("EnemySpawner setup is incomplete!");
            yield break;
        }

        // Give the player time to prepare
        yield return new WaitForSeconds(preparationTime);

        // Wave 1: Three normal enemies
        yield return StartCoroutine(RunWave(1, 3, 0));

        if (GameManager.IsGameOver)
            yield break;

        yield return new WaitForSeconds(timeBetweenWaves);

        // Wave 2: Three normal, two fast
        yield return StartCoroutine(RunWave(2, 3, 2));

        if (GameManager.IsGameOver)
            yield break;

        yield return new WaitForSeconds(timeBetweenWaves);

        // Wave 3: Three normal, four fast
        yield return StartCoroutine(RunWave(3, 3, 4));

        if (GameManager.IsGameOver)
            yield break;

        // All three waves completed
        manager.WinGame();
    }

    IEnumerator RunWave(int wave, int normalCount, int fastCount)
    {
        Debug.Log("WAVE " + wave + " STARTED!");

        for (int i = 0; i < normalCount; i++)
        {
            if (GameManager.IsGameOver)
                yield break;

            SpawnEnemy(normalEnemyPrefab);
            yield return new WaitForSeconds(spawnInterval);
        }

        for (int i = 0; i < fastCount; i++)
        {
            if (GameManager.IsGameOver)
                yield break;

            SpawnEnemy(fastEnemyPrefab);
            yield return new WaitForSeconds(spawnInterval);
        }

        // Wait until all enemies in this wave are defeated
        yield return new WaitUntil(() =>
            manager.EnemiesRemaining == 0 ||
            GameManager.IsGameOver
        );

        if (!GameManager.IsGameOver)
        {
            Debug.Log("WAVE " + wave + " COMPLETE!");
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        GameObject enemy = Instantiate(
            prefab,
            spawnPoint.position,
            Quaternion.identity
        );

        EnemyMovement movement =
            enemy.GetComponent<EnemyMovement>();

        EnemyHealth health =
            enemy.GetComponent<EnemyHealth>();

        if (movement == null || health == null)
        {
            Debug.LogError("Enemy prefab is missing required scripts!");
            Destroy(enemy);
            return;
        }

        // Connect scene waypoints to the spawned enemy
        movement.waypoints = waypoints;

        // Track the new enemy
        manager.RegisterEnemy();
    }
}
