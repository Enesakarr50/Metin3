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
    public int enemiesPerWave = 5; // Her dalgada spawn edilecek d��man say�s�
    public float spawnInterval = 2.0f; // D��manlar�n spawn olma aral���
    public int turnCounter = 0;

    // Spawn noktalar�
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
            timer = spawnInterval; // Timer'� resetliyoruz ki oyuncu tekrar girdi�inde hemen spawn olmas�n
        }
    }

    void SpawnWave()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject enemyPrefab = GetRandomEnemyPrefab();
                enemyPrefab.GetComponent<Enemy>().health = 100 + 10 * turnCounter;
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                turnCounter++;
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
        return null; // Bu sat�ra normalde ula��lmaz
    }
}
