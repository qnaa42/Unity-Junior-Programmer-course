using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    /// <summary>
    /// Destroy GameObject if trigger entered, 
    /// Destroy other.GameObject if trigger entered
    /// </summary>
    /// <param name="other">Colliding GameObject</param>
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
