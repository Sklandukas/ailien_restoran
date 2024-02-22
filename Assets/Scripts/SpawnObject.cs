using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject objectToSpawn;
    public float spawnInterval = 8; 

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    void Spawn()
    {
        Vector3 location = spawnLocation.transform.position;
        Instantiate(objectToSpawn, location, Quaternion.identity);
    }
}