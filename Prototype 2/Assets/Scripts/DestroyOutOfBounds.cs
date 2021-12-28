using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Z value of game area (move to game manager late)
    public float topBoundary = 30f;
    public float bottomBoundary = -10f;

    // Update is called once per frame
    void Update()
    {
        //Destroy Game Object if out of z boundary ( can be upgrade for x and y boundary if needed)
        if (transform.position.z > topBoundary)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBoundary)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
