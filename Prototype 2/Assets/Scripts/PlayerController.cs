using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Input
    public float horizontalInput;

    //Movement Speed
    public float speed = 10f;

    //Play Area
    public float xRange = 10f;

    //Projectile reference
    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        // Checking if player is in play area, disable option to move more than play area acordingly to player position
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if ((transform.position.x > xRange))
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Player Input Translate
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Instatiate projectile at player transform
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
