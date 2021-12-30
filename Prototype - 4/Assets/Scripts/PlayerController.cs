using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float powerUpStrenght = 15f;

    public bool hasPowerUp = false;

    public GameObject powerUpIndicator;

    private GameObject focalPoint;

    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0f, -0.55f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            powerUpIndicator.gameObject.SetActive(true);
            hasPowerUp = true;
            StartCoroutine(PowerupCountdownRountine());
        }
    }

    IEnumerator PowerupCountdownRountine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
            Debug.Log("Collided with" + collision.gameObject.name + " with power up set to" + hasPowerUp);
        }
    }
}
