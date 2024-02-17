using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDelivery: MonoBehaviour {
    private Vector3 offset;
    private bool dragging = false; 
    
    void Update(){
        if(dragging){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown(){
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp(){
        dragging = false;
    }
}