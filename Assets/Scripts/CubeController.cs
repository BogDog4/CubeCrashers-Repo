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

    public bool shootinterval = true;

    public GameObject projectileUp;
    public GameObject projectileDown;
    public GameObject projectileLeft;
    public GameObject projectileRight;

    private Rigidbody rigidplayercube;

    // Start is called before the first frame update
    void Start()
    {
        //tell it what rigid body is to fix the drifting issue
        rigidplayercube = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Turn input into movement(not inverted)
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            rigidplayercube.velocity = Vector3.zero;
        }

        //checking if the player�s position is within ranges
        /*{
            if (transform.position.x < -xRange)
            { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
            if (transform.position.x > xRange)
            { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }

            if (transform.position.z < -zRange)
            { transform.position = new Vector3(transform.position.x, transform.position.y, -zRange); }
            if (transform.position.z > zRange)
            { transform.position = new Vector3(transform.position.x, transform.position.y, zRange); }

        }
        */
        //Projectile scripts and pushback
        //cooldown established
        if (Input.GetKey(KeyCode.UpArrow)&&shootinterval)
        {
            transform.Translate(Vector3.back * Time.deltaTime * recoilspeed);
            Instantiate(projectileUp, transform.position, projectileUp.transform.rotation);
            shootinterval = false;
            StartCoroutine(cooldown());
        }
        if (Input.GetKey(KeyCode.DownArrow)&&shootinterval)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * recoilspeed);
            Instantiate(projectileDown, transform.position, projectileDown.transform.rotation);
            shootinterval = false;
            StartCoroutine(cooldown());
        }
        if (Input.GetKey(KeyCode.LeftArrow)&&shootinterval)
        {
            transform.Translate(Vector3.right * Time.deltaTime * recoilspeed);
            Instantiate(projectileLeft, transform.position, projectileLeft.transform.rotation);
            shootinterval = false;
            StartCoroutine(cooldown());
        }
        if (Input.GetKey(KeyCode.RightArrow)&&shootinterval)
        {
            transform.Translate(Vector3.left * Time.deltaTime * recoilspeed);
            Instantiate(projectileRight, transform.position, projectileRight.transform.rotation);
            shootinterval = false;
            StartCoroutine(cooldown());

        }
        
        //i just made a function
        //
    }
    IEnumerator cooldown() 
    {
yield return new WaitForSeconds(0.25f);
shootinterval = true;
    }
    //collision function
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("lava"))
        {
            Destroy(gameObject);
            Debug.Log("collided");
        }
        
    }
}
