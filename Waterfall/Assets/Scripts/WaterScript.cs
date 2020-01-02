using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    // Public variable 
    public float maxSpeed = 4f;

    Rigidbody2D r2d;

    // Function called once when the bullet is created
    void Start()
    {
        // Get the rigidbody component
        r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = Vector2.down * maxSpeed;
    }

    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject);
        }
        else if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
