using UnityEngine;

public class FoodOrder : MonoBehaviour
{
    public GameObject Message;
    public GameObject[] wishPrefabs;
    public GameObject DeliveryPlace;
    private bool hasSpawned = false;
    private GameObject prefabInstance;
    private bool isMessageDestroyed = false;

    private void Start()
    {
        StopGameObject.OnSpeedZero += SpawnMessage;
    }

    private void OnDestroy()
    {
        StopGameObject.OnSpeedZero -= SpawnMessage;
    }

    private void Update()
    {
        if (hasSpawned && !isMessageDestroyed)
        {
            CheckForNearbyFoodObjects(prefabInstance.transform.position, prefabInstance.name, Message);
        }
    }

    private void SpawnMessage()
    {
        if (!hasSpawned)
        {
            Vector3 position = ParentLocation(transform.parent);
            Instantiate(Message, position, Quaternion.identity);
            prefabInstance = SpawnAlienWish(position);
            Instantiate(DeliveryPlace, new Vector3(position.x, position.y - 3.65f, position.z), Quaternion.identity);
            Debug.Log("Instancijuotas prefabas pavadinimu: " + prefabInstance.name);
            hasSpawned = true;
        }
    }

    private Vector3 ParentLocation(Transform parentTransform)
    {
        if (parentTransform != null)
        {
            return parentTransform.position;
        }
        else
        {
            Debug.LogWarning("This object has no parent");
            return Vector3.zero;
        }
    }

    private int RandomFoodIndex()
    {
        return Random.Range(0, wishPrefabs.Length);
    }

    private GameObject SpawnAlienWish(Vector3 position)
    {
        int index = RandomFoodIndex();
        GameObject instance = Instantiate(wishPrefabs[index], position, Quaternion.identity);
        return instance;
    }

    private void CheckForNearbyFoodObjects(Vector3 position, string PrefabName, GameObject Message)
    {
        position = new Vector3(position.x, position.y - 3.65f, position.z);
        GameObject[] nearbyObjects = GameObject.FindGameObjectsWithTag("Food");
        foreach (GameObject obj in nearbyObjects)
        {
            if (Vector3.Distance(obj.transform.position, position) < 0.3f)
            {
                string objName = obj.name;
                if (objName == PrefabName)
                {
                    DestroyImmediate(obj);
                    DestroyImmediate(Message);
                    DestroyImmediate(prefabInstance);
                

                }
                else
                {
                    Destroy(obj);
                }
            }
        }
    }
}
