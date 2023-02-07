using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_north : MonoBehaviour
{//array
    public GameObject[] crasherPrefabs;
    private float spawnRangeX = 25;
    private float spawnPosZ = 40;
    private float startDelay = 1.0f;
    public float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NorthSpawn", startDelay , spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NorthSpawn()
    {
        int crasherIndex = Random.Range(0, crasherPrefabs.Length);
        //spawn within random range of x
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(crasherPrefabs[crasherIndex], spawnPos, crasherPrefabs[crasherIndex].transform.rotation);
    }
}
