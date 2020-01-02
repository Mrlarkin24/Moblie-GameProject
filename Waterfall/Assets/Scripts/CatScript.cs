using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Public variable 
    public bool alive;
    public GameObject fire;
    public float maxSpeed = 5f, timeMouse = 0.00f;
    public int fireCount = 0, mouseCount = 0;

    bool mousePower = true;

    Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        r2d = GetComponent<Rigidbody2D>();

        alive = true;
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

        //Checks if invincibility timer has run out and resets related variables
        if (timeMouse < 0)
        {
            mousePower = true;
            mouseCount -= 3;
            timeMouse = 0.00f;
        }

        //Activates invincibility timer 
        if (!mousePower)
            timeMouse -= Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            if (fireCount < 5)
            {
                Instantiate(fire, transform.position, Quaternion.identity);
                fireCount++;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Water"))
        {
            if (mousePower)
            {
                Destroy(gameObject);
                alive = false;
                Time.timeScale = 0;
            }
        }
        else if (coll.gameObject.CompareTag("Mouse"))
        {
            //Keeps track of how many mouses the player has collected 
            mouseCount++;
            if (mouseCount == 3)
            {
                mousePower = false;
                timeMouse = 10.00f;
            }
        }
    }
}
