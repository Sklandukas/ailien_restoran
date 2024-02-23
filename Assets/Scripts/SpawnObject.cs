using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject[] alienPrefabs;
    public float spawnInterval = 1;

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    void Spawn()
    {
        int locationIndex = Random.Range(0, spawnLocations.Length);
        Vector3 location = spawnLocations[locationIndex].transform.position;
        int alienIndex = Random.Range(0, alienPrefabs.Length);

        if (alienIndex < 0 || alienIndex >= alienPrefabs.Length)
        {
            Debug.LogError("Netinkamas alienIndex: " + alienIndex);
            return;
        }

        Instantiate(alienPrefabs[alienIndex], location, Quaternion.identity);
    }
}
