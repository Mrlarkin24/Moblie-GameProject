using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Public variable 
    public GameObject fire;
    public float maxSpeed = 5f;

    Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // Function called about 60 times per second
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Move the spaceship when an arrow key is pressed
        if (Input.GetKey("right"))
            r2d.velocity = new Vector3(move * maxSpeed, r2d.velocity.y);
        else if (Input.GetKey("left"))
            r2d.velocity = new Vector3(move * maxSpeed, r2d.velocity.y);
        else
            r2d.velocity = new Vector3(move * 0, r2d.velocity.y);

        if (Input.GetKeyDown("space"))
        {
            Instantiate(fire, transform.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Water"))
            Destroy(gameObject);
    }
}
