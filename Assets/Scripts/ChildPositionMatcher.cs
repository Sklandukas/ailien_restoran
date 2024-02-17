using UnityEngine;

public class ChildPositionMatcher : MonoBehaviour
{
    public Transform parentObject; 

    private Transform childObject; 

    void Start()
    {
        childObject = transform; 
        
        if (parentObject != null && childObject != null)
        {
            childObject.position = parentObject.position;
        }
        else
        {
            Debug.LogError("Tėvinis ar vaiko objektas nėra nustatytas!");
        }
    }
}
