using UnityEngine;
using UnityEngine.UI;

public class SpawnSpeedCalculator : MonoBehaviour
{
    public Text textField;
    private string text;
    public float ailienSpawnTime = 8.0f;
    private float stepSize = 0.25f;

    void Start()
    {
        if (textField != null)
        {
            text = textField.text;
            float points = float.Parse(text); 
            int divisionResult = Mathf.FloorToInt(points / 5);
            ailienSpawnTime = ailienSpawnTime - (stepSize * divisionResult); 
            Debug.Log(ailienSpawnTime);

            var spawnObject = GetComponent<SpawnObject>();
            if (spawnObject != null)
            {
                spawnObject.spawnInterval = ailienSpawnTime;
            }
            else
            {
                Debug.LogError("SpawnObject komponentas nerastas!");
            }
        }
        else
        {
            Debug.LogError("Text komponentas nėra priskirtas!");
        }
    }
}