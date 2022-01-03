using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private float horizontalInput;
    public float throwPower;

    private float movSpeed = 15f;

    private Rigidbody rigidBody;

    private Text throwPowerText;

    private bool isStatic = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        throwPowerText = GameObject.Find("ThrowPowerText").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!isStatic)
        {
            rigidBody.useGravity = true;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Movement();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            throwPower += 0.5f * Time.deltaTime;
            throwPowerText.text = "Throw Power : " + throwPower;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            isStatic = false;
            rigidBody.AddForce(new Vector3(-1,1,0) * throwPower * 10f, ForceMode.Impulse);
            throwPower = 0;
            throwPowerText.text = "Throw Power : " + throwPower;
        }

    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * movSpeed);
    }
}
