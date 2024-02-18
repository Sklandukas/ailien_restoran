using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject alienObject; 
    public GameObject parentObject;
    private bool hasSpawned = false;
    private GameObject[] children;

    void Start()
    {
        if (parentObject != null)
        {
            children = new GameObject[parentObject.transform.childCount];
            for (int i = 0; i < parentObject.transform.childCount; i++)
            {
                children[i] = parentObject.transform.GetChild(i).gameObject;
            }

            GameObject randomChild = GetRandomChildObject();
            Debug.Log("Atsitiktinai pasirinktas vaikinis GameObject: " + randomChild.name);
        }
        else
        {
            Debug.LogError("ParentObject is not assigned!");
        }
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
        Instantiate(alienObject, location, Quaternion.identity);
    }

    GameObject GetRandomChildObject()
    {
        int randomIndex = Random.Range(0, children.Length);
        return children[randomIndex];
    }
}
