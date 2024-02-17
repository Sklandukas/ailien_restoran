using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float x_bound = 11.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x >= x_bound)
        {
            Destroy(gameObject);
        }
        
    }
}
