using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    public int waveNumber = 1;

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    
    public GameObject[] powerUpArray;

    private Vector3 powerUpOffset = new Vector3(0, 0.55f, 0);

    private float spawnRange = 9f;

    private bool spawningPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        GameObject powerUp = Instantiate(powerUpPrefab, GenerateSpawnPosition() + powerUpOffset, powerUpPrefab.transform.rotation);
        powerUpArray[0] = powerUp;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; 
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }    
        if (powerUpArray[0] == null && !spawningPowerUp)
        {
            spawningPowerUp = true;
            StartCoroutine(SpawnPowerUp());
        }    
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    private IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(15f); 
        GameObject powerUp = Instantiate(powerUpPrefab, GenerateSpawnPosition() + powerUpOffset, powerUpPrefab.transform.rotation);
        powerUpArray[0] = powerUp;
        spawningPowerUp = false;
    }    

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
