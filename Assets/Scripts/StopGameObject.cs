using UnityEngine;

public class StopGameObject : MonoBehaviour
{
    public string stopLocationsTag = "StopLocation";
    private GameObject mainObject;
    private Transform parentTransform;
    private Vector3 stopLocation;
    private bool isSpeedZero = false; // Būsena, kuri nurodo, ar greitis jau nustatytas į 0
    public delegate void SpeedZeroEventHandler();
    public static event SpeedZeroEventHandler OnSpeedZero;

    void Start()
    {
        GameObject[] stopLocations = GameObject.FindGameObjectsWithTag(stopLocationsTag);

        if (stopLocations == null || stopLocations.Length < 1)
        {
            Debug.LogError("Nerasta sustojimo vietų.");
            enabled = false;
            return;
        }

        int randomIndex = Random.Range(0, stopLocations.Length);

        mainObject = this.gameObject;
        stopLocation = stopLocations[randomIndex].transform.position;
        mainObject.transform.position = stopLocation;

        parentTransform = mainObject.transform.parent;
    }

    void Update()
    {
        if (!isSpeedZero && parentTransform != null && Vector3.Distance(parentTransform.position, stopLocation) < 0.1f)
        {
            var parentSpeedComponent = parentTransform.GetComponent<MoveForward>();

            if (parentSpeedComponent != null)
            {   Debug.LogError("RASTA");
                parentSpeedComponent.Speed = 0f;
                OnSpeedZero?.Invoke();
                isSpeedZero = true; // Nustatome, kad greitis jau yra nustatytas į 0
            }
            else
            {
                Debug.LogError("MoveForward komponentas nerastas tėvo objekte.");
            }
        }
    }
}
