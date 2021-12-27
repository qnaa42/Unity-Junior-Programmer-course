using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Car Speed
    private float speed = 15.0f;

    // Rotation speed
    private float turnSpeed = 25.0f;

    // Inputs
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        //Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // We'll move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // We'll turn the vehicle 
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
    
}
