using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{                                                                           // Cube Crashers PlayerController 
    //lets set some variables
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public float zRange = 10.0f;
    public float recoilspeed = 2.0f;

    public GameObject projectileUp;
    public GameObject projectileDown;
    public GameObject projectileLeft;
    public GameObject projectileRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Turn input into movement(not inverted)
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //checking if the player’s position is within ranges
        {
            if (transform.position.x < -xRange)
            { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
            if (transform.position.x > xRange)
            { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }

            if (transform.position.z < -zRange)
            { transform.position = new Vector3(transform.position.x, transform.position.y, -zRange); }
            if (transform.position.z > zRange)
            { transform.position = new Vector3(transform.position.x, transform.position.y, zRange); }

        }
        //Projectile scripts and pushback
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * recoilspeed);
            Instantiate(projectileUp, transform.position, projectileUp.transform.rotation);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * recoilspeed);
            Instantiate(projectileDown, transform.position, projectileDown.transform.rotation);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * recoilspeed);
            Instantiate(projectileLeft, transform.position, projectileLeft.transform.rotation);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * recoilspeed);
            Instantiate(projectileRight, transform.position, projectileRight.transform.rotation);
        }
    }
}
