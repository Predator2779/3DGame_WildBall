using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Text speedometer;

    public float CurrentSpeed
    {
        get { return GetComponent<Rigidbody>().velocity.magnitude * 3.6f; }
    }

    private void Update() => speedometer.text = ($"{Mathf.RoundToInt(CurrentSpeed)} km/h");
}