using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //MSpeeds
    public float speed = 20f;
    public float sizeSpeed = 20f;
    public float pitchSpeed = 20f;
    public float yawSpeed = 20f;

    //Angle Restrains
    private float MaxPitchAngle = 80f;


    //Player Input
    private float inputHorizontal;
    private float inputVertical;
    private float inputSize;
    
    

    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        

    }
    
    void Update()
    {
        Movement();
        ColorChange();
    }

    public void Movement()
    {
        //Get current rotation
        Vector3 rotationVector = transform.rotation.eulerAngles;

        // Hold Yaw and pitch input as variable
        float pitch = 0f;
        float yaw = 0f;

        //Input:
        // W and S for Horizontal to move in Z Axis
        // A and D for Vertical to move in X Axis
        // Q and E for size increase over time button is pressed
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        inputSize = Input.GetAxis("Size");

        //Translating arrow input as yaw and pitch change
        if (Input.GetKey(KeyCode.UpArrow)) pitch = 1f;
        else if (Input.GetKey(KeyCode.DownArrow)) pitch = -1f;
        else if (Input.GetKey(KeyCode.LeftArrow)) yaw = -1f;
        else if (Input.GetKey(KeyCode.RightArrow)) yaw = 1f;

        // Calculate speed
        float movHorizontal = speed * Time.deltaTime * inputHorizontal;
        float movVertical = speed * Time.deltaTime * inputVertical;
        float size = sizeSpeed * Time.deltaTime * inputSize;

        //Calculate new pitch adn yaw 
        float pitchChange = rotationVector.x + pitchSpeed * Time.deltaTime * pitch;
        float yawChange = rotationVector.y + yawSpeed * Time.deltaTime * yaw;

        //Applying Input
        transform.Translate(movVertical, 0, movHorizontal);
        transform.rotation = Quaternion.Euler(pitchChange, yawChange, 0);
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q))
        {
            transform.localScale = transform.localScale + new Vector3(size, size, size);
        }
    }

    /// <summary>
    /// Cgange color of the cube accrodingly to input
    /// 1: red
    /// 2: blue
    /// 3: Yellow
    /// 4: Black
    /// </summary>
    public void ColorChange()
    {
        Material material = Renderer.material;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            material.color = new Color32(255,  0, 0, 255);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            material.color = new Color32(0, 33, 255, 255);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            material.color = new Color32(250, 255, 0, 255);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            material.color = new Color32(0, 0, 0, 255);
        }
    }
}
