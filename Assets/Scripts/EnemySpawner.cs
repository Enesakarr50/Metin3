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
    public int enemiesPerWave = 5; // Her dalgada spawn edilecek düþman sayýsý
    public float spawnInterval = 2.0f; // Düþmanlarýn spawn olma aralýðý

    // Spawn noktalarý
    public Transform[] spawnPoints;

    private float timer;
    private bool playerInTrigger = false;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        if (playerInTrigger)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SpawnWave();
                timer = spawnInterval;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            timer = spawnInterval; // Timer'ý resetliyoruz ki oyuncu tekrar girdiðinde hemen spawn olmasýn
        }
    }

    void SpawnWave()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject enemyPrefab = GetRandomEnemyPrefab();
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            }
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
        return null; // Bu satýra normalde ulaþýlmaz
    }
}
