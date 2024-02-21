using UnityEngine;
public class PointsCounter : MonoBehaviour
{
    private int kintamasis = 0;

    private void Start() {
        FoodOrder.OnMyEvent += AddOneToPoint;
    }

    private void OnDestroy() {
        FoodOrder.OnMyEvent -= AddOneToPoint;
    }

    private void AddOneToPoint() {
        kintamasis++;
        Debug.Log("Kintamasis dabar: " + kintamasis);
    }
}

