using UnityEngine;

public class EventHorn : MonoBehaviour
{
    ////// Сделать синглтоном.

    [SerializeField] private GameObject _sphere;

    public SphereScaler SphereScaler;

    private void Awake()
    {
        SphereScaler = _sphere.GetComponent<SphereScaler>();
    }
}
