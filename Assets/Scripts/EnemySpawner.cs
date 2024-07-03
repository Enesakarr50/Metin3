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

    // Spawn noktalar�
    public Transform[] spawnPoints;

    private float timer;
    private Transform playerTransform;

    void Start()
    {
        timer = spawnInterval;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnWave(other.transform.position);
        }
    }

    void SpawnWave(Vector3 spawnPosition)
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject enemyPrefab = GetRandomEnemyPrefab();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
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
