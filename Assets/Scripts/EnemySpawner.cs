using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject prefab; // Spawn edilecek d��man prefab'i
        public float spawnProbability; // Spawn olma olas�l���
    }

    public EnemyType[] enemyTypes; // D��man t�rleri
    public float spawnInterval = 5.0f; // Her dalga aras�ndaki s�re
    public int enemiesPerWave = 5; // Her dalgada spawn edilecek d��man say�s�
    public float spawnRadius = 10.0f; // Oyuncunun etraf�ndaki spawn yar��ap�

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
        // Dairesel bir pozisyon se�
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
        return null; // Bu sat�ra normalde ula��lmaz
    }
}
