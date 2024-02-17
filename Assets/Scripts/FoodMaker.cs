using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenScript : MonoBehaviour
{
    public float horizontalInput;
    public GameObject FoodDish;
    public GameObject FoodSector;
    public Button CookButton;
    private Vector3 gameObjectPosition;

    void Start()
    {
        if (CookButton != null)
        {
            CookButton.onClick.AddListener(SpawnFood);
        }
        else
        {
            Debug.LogError("CookButton is not assigned!");
        }
    }

    void SpawnFood()
    {
        if (FoodDish != null)
        {
            gameObjectPosition = SectorPosition();
            Instantiate(FoodDish, gameObjectPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("FoodDish prefab is not assigned!");
        }
    }

    Vector3 SectorPosition()
    {
        if (FoodSector != null)
        {
            return FoodSector.transform.position;
        }
        else
        {
            Debug.LogError("FoodSector is not assigned!");
            return Vector3.zero;
        }
    }
}
