using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Text _speedo;

    public float CurrentSpeed
    {
        get { return GetComponent<Rigidbody>().velocity.magnitude * 3.6f; }
    }

    private void Update()
    {
        if (_speedo != null)
        {
            _speedo.text = ($"{Mathf.RoundToInt(CurrentSpeed)} km/h");
        }
    }
}