using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject box;

    public Text CounterText;

    public int count = 0;

    public float boxMaxSpawnX = 5f;
    public float boxMinSpawnX = 15f;

    public bool isBallSpawned = false;
    public bool isBoxSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        CounterText.text = "Count : " + count;
    }

    public void Spawn()
    {
        if (!isBallSpawned)
        {
            Instantiate(ball, new Vector3(18.5f, 4.5f, -0.5f), ball.transform.rotation);
            isBallSpawned = true;
        }
        if (!isBoxSpawned)
        {
            Instantiate(box, new Vector3(UnityEngine.Random.Range(-boxMinSpawnX, boxMaxSpawnX), 0, 0), box.transform.rotation);
            isBoxSpawned = true;
        }
    }
}
