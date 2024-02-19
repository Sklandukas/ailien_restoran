using UnityEngine;

public class FoodOrder : MonoBehaviour
{
    public GameObject Message;
    public GameObject[] wishPrefabs;
    public GameObject DeliveryPlace;
    private bool hasSpawned = false;

    private void Start()
    {
        StopGameObject.OnSpeedZero += SpawnMessage;
    }

    private void OnDestroy()
    {
        StopGameObject.OnSpeedZero -= SpawnMessage;
    }

    private void SpawnMessage()
    {
        if (!hasSpawned) 
        {
            Vector3 position = ParentLocation(transform.parent);
            Instantiate(Message, position, Quaternion.identity);
            GameObject prefabInstance = SpawnAlienWish(position);
            string prefabName = prefabInstance.name;
            Instantiate(DeliveryPlace, new Vector3(position.x, position.y - 3.65f, position.z), Quaternion.identity);
            Debug.Log("Instancijuotas prefabas pavadinimu: " + prefabName);
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
        GameObject prefabInstance = Instantiate(wishPrefabs[index], position, Quaternion.identity);
        return prefabInstance;
    }
}
