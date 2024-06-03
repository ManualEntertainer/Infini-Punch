using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{


    private void Start()
    {

    }

    // Called when this object collides with another object in 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider Detected");
        Destroy(gameObject);
        
    }
}