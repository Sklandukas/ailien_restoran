using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AilienOrder: MonoBehaviour
{
    public GameObject[] wishPrefabs;
    public GameObject ailienCloud;
    private GameObject prefabInstance;
    private float targetPosition;
    void Start()
    {
    }

    void Update()
    {
        if (ailienCloud != null && prefabInstance == null)
        {
            Vector3 gameObjectPosition = cloudPosition();
            int index = RandomFoodIndex();
            prefabInstance = Instantiate(wishPrefabs[index], gameObjectPosition, Quaternion.identity);
            prefabInstance.transform.localScale = new Vector3(0.9f, 0.9f, 0.0f);
            Vector3 newPosition = FoodPositionObject(gameObjectPosition);
        }
        else if (ailienCloud == null)
        {
            Debug.LogWarning("Ailien Cloud is not assigned!");
        }
        if (prefabInstance != null)
        {
            Vector3 newPosition = FoodPositionObject(prefabInstance.transform.position);
            CheckForNearbyFoodObjects(newPosition);
        }

    }

    Vector3 cloudPosition()
    {
        return ailienCloud.transform.position;
    }

    int RandomFoodIndex()
    {
        return Random.Range(0, wishPrefabs.Length);
    }

    Vector3 FoodPositionObject(Vector3 position)
    {
        float newY = -1.2f;
        Vector3 newPosition = new Vector3(position.x, newY, position.z);
        return newPosition;
    }

    void CheckForNearbyFoodObjects(Vector3 position)
    {
        GameObject[] nearbyObjects = GameObject.FindGameObjectsWithTag("food");
        foreach (GameObject obj in nearbyObjects)
        {
            if (Vector3.Distance(obj.transform.position, position) < 1.0f)
            {
                Debug.Log("Rastas objektas su tag'u 'Food' šalia tuščiojo objekto.");
                Destroy(prefabInstance);
                Destroy(ailienCloud);
                break;
            }
        }
    }
}