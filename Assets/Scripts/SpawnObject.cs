using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject ailienObject;
    public Vector3 location; 
    private bool hasSpawned = false;

    void Start()
    {
       
    }

    void Update()
    {
        if (!hasSpawned) 
        {
            Position();
            spawnObject();
            hasSpawned = true; 
        }
    }

    void Position()
    {
        location = spawnLocation.transform.position;
    }

    void spawnObject()
    {
        Instantiate(ailienObject, location, Quaternion.identity);
    }
}
