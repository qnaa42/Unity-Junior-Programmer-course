using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float movSpeed = 15f;


    private float horizontalInput;
    public float throwPower;

    private Rigidbody rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * movSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwPower += 0.05f;
        }
    }
}
