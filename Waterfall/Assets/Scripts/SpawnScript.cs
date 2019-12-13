using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Public variable 
    public GameObject water;
    public GameObject mouse;
    public float stWater = 2f;
    public float stMouse = 5f;

    Vector2 spawnPoint;
    Renderer rd;
    float randx;

    // Start is called before the first frame update
    void Start()
    {
        // Call the 'addEnemy' function in 0 second
        // Then every 'spawnTime' seconds
        InvokeRepeating("addWater", 0, stWater);
        InvokeRepeating("addMouse", 0, stMouse);
    }

    // Update is called once per frame
    void addWater()
    {
        // Get the renderer component of the spawn object
        rd = GetComponent<Renderer>();

        // Position of the left edge of the spawn object
        // It's: (position of the center) minus (half the width)
        var x1 = transform.position.x - rd.bounds.size.x / 2;

        // Same for the right edge
        var x2 = transform.position.x + rd.bounds.size.x / 2;

        // Randomly pick a point within the spawn object
        randx = Random.Range(x1, x2);

        spawnPoint = new Vector2(randx, transform.position.y);

        // Create an enemy at the 'spawnPoint' position
        Instantiate(water, spawnPoint, Quaternion.identity);
    }

    void addMouse()
    {
        // Get the renderer component of the spawn object
        rd = GetComponent<Renderer>();

        // Position of the left edge of the spawn object
        // It's: (position of the center) minus (half the width)
        var x1 = transform.position.x - rd.bounds.size.x / 2;

        // Same for the right edge
        var x2 = transform.position.x + rd.bounds.size.x / 2;

        // Randomly pick a point within the spawn object
        randx = Random.Range(x1, x2);

        spawnPoint = new Vector2(randx, transform.position.y);

        // Create an enemy at the 'spawnPoint' position
        Instantiate(mouse, spawnPoint, Quaternion.identity);
    }
}
