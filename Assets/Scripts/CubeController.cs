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
    public float recoilspeed = 200.0f;

    public bool shootinterval = true;

    public GameObject projectileUp;
    public GameObject projectileDown;
    public GameObject projectileLeft;
    public GameObject projectileRight;

    //set the empty spawnoffset objects
    public Transform projspawnerup;
    public Transform projspawnerdown;
    public Transform projspawnerleft;
    public Transform projspawnerright;

    private Rigidbody rigidplayercube;

    // Start is called before the first frame update
    void Start()
    {
        //define rigidbody
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

        //when im not imputting, DONT MOVE! (with rigidbody(
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            rigidplayercube.velocity = Vector3.zero;
        }


        //shoot only while key is pressed and shootinterval = true
        if (Input.GetKey(KeyCode.UpArrow)&&shootinterval)
        {//shoot up
            //recoil
            transform.Translate(Vector3.back * Time.deltaTime * recoilspeed);
            //spawn projectile at projspawner offset
            Instantiate(projectileUp, projspawnerup.position, projectileUp.transform.rotation);
            //dont allow player to shoot until shootinterval = true again
            shootinterval = false;
            StartCoroutine(cooldown());
        }
        if (Input.GetKey(KeyCode.DownArrow)&&shootinterval)
        {//shoot down
            transform.Translate(Vector3.forward * Time.deltaTime * recoilspeed);
            Instantiate(projectileDown, projspawnerdown.position, projectileDown.transform.rotation);
            shootinterval = false;
            StartCoroutine(cooldown());
        }
        if (Input.GetKey(KeyCode.LeftArrow)&&shootinterval)
        {//shoot left
            transform.Translate(Vector3.right * Time.deltaTime * recoilspeed);
            Instantiate(projectileLeft, projspawnerleft.position, projectileLeft.transform.rotation);
            shootinterval = false;
            StartCoroutine(cooldown());
        }
        if (Input.GetKey(KeyCode.RightArrow)&&shootinterval)
        {//shoot right
            transform.Translate(Vector3.left * Time.deltaTime * recoilspeed);
            Instantiate(projectileRight, projspawnerright.position, projectileRight.transform.rotation);
            shootinterval = false;
            StartCoroutine(cooldown());

        }
        
        //i just made a function
        //shootinterval cooldown
    }
    IEnumerator cooldown() 
    {
yield return new WaitForSeconds(0.25f);
shootinterval = true;
    }
    //collision function for player death
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("lava"))
        {
            Destroy(gameObject);
            Debug.Log("collided");
        }
        

    }

    
}
