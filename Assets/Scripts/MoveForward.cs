using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed = 15.0f;

    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}
