using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    //Spawn restraints
    private float spawnRangeX = 20f;
    private float spawnRangeZ = 20f;

    //Spawn Delay and spawn rate
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Spawning a animalPrefab using SpawnRandomAnimal()
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    /// <summary>
    /// Instantiating random animalPrefab from array
    /// </summary>
    void SpawnRandomAnimal()
    {
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }    
}
