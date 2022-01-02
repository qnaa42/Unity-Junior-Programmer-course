using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -2f;

    public int value;

    public ParticleSystem explosionParticle;

    private Rigidbody targetRb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorqueVector(), ForceMode.Impulse);

        transform.position = RandomSpawnPositionVector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * UnityEngine.Random.Range(minSpeed, maxTorque);
    }
    float RandomTorqueFloat()
    {
        return UnityEngine.Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomTorqueVector()
    {
        return new Vector3(RandomTorqueFloat(), RandomTorqueFloat(), RandomTorqueFloat());
    }
    Vector3 RandomSpawnPositionVector()
    {
        return new Vector3(UnityEngine.Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(value);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
