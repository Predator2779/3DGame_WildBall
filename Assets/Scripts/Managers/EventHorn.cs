using UnityEngine;

public class EventHorn : MonoBehaviour
{
    ////// ������� ����������.

    [SerializeField] private GameObject _sphere;

    public SphereScaler SphereScaler;

    private void Awake()
    {
        SphereScaler = _sphere.GetComponent<SphereScaler>();
    }
}
