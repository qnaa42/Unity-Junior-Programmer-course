using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{


    private GameManager gameManager;

    private int Count = 0;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.count += 1;
        gameManager.isBallSpawned = false;
        gameManager.isBoxSpawned = false;
        gameManager.Spawn();
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
