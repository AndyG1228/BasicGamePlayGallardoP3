using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.0f;
    public float xRange = 23;
    public float topRange = 16;
    public float bottomRange = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //To keep the player withinn the game boundaries
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //To keep the player withinn the game boundaries
        if (transform.position.z < bottomRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomRange);
        }
        if (transform.position.z > topRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,topRange);
        }

        //Launch a copied projectile from the player upon pressing spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }
}
