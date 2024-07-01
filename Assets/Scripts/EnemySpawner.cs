using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject prefab; // Spawn edilecek düþman prefab'i
        public float spawnProbability; // Spawn olma olasýlýðý
    }

    public EnemyType[] enemyTypes; // Düþman türleri
    public float spawnInterval = 5.0f; // Her dalga arasýndaki süre
    public int enemiesPerWave = 5; // Her dalgada spawn edilecek düþman sayýsý
    public float spawnRadius = 10.0f; // Oyuncunun etrafýndaki spawn yarýçapý

    private float timer;
    private Transform playerTransform;

    void Start()
    {
        timer = spawnInterval;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnWave();
            timer = spawnInterval;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemyPrefab = GetRandomEnemyPrefab();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Dairesel bir pozisyon seç
        float angle = Random.Range(0f, 360f);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius;

        return new Vector3(playerTransform.position.x + x, playerTransform.position.y + y, playerTransform.position.z);
    }

    GameObject GetRandomEnemyPrefab()
    {
        float totalProbability = 0f;
        foreach (EnemyType enemyType in enemyTypes)
        {
            totalProbability += enemyType.spawnProbability;
        }

        float randomPoint = Random.value * totalProbability;
        foreach (EnemyType enemyType in enemyTypes)
        {
            if (randomPoint < enemyType.spawnProbability)
            {
                return enemyType.prefab;
            }
            else
            {
                randomPoint -= enemyType.spawnProbability;
            }
        }
        return null; // Bu satýra normalde ulaþýlmaz
    }
}
