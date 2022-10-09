using UnityEngine;

public class PartsRotation : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 1f;
    [SerializeField] [Range(-1, 1)] private int _reverseDirection;

    /// <summary>
    /// Вращение деталей сферы.
    /// </summary>
    private void FixedUpdate() => transform.Rotate(0, 0, _speedRotation * _reverseDirection, Space.Self);
}
