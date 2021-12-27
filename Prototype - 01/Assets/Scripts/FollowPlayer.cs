using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Game object represnting player - vehicle
    public GameObject player;

    // Camera Offset
    private Vector3 offset = new Vector3(0, 5, -7);

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset camera nehind the player by adding to the player's position
        transform.position = player.transform.position + offset;
    }
}
