using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Переменные

    [Range(1.0f, 100.0f)] public float _sensitivity = 10.0f;

    [SerializeField] private Transform _wildBall;
    [SerializeField] private float _distance;

    private Vector3 _offset;
    private float _xRot, _yRot;

    #endregion

    #region Методы

    /// <summary>
    /// Start.
    /// </summary>
    private void Start() => _offset = VectorOffset(_wildBall);

    public void CameraControl(float mouse_X, float mouse_Y)
    {
        DistanceFromScale();

        RotationControl(mouse_X, mouse_Y);

        FollowingControl(transform.localRotation * _offset * _distance + _wildBall.position);

        DistanceControl();
    }

    /// <summary>
    /// Вращение камеры вокруг шара.
    /// </summary>
    private void RotationControl(float mouse_X, float mouse_Y)
    {
        _xRot = transform.localEulerAngles.y + mouse_X * _sensitivity * Time.timeScale;
        _yRot += mouse_Y * _sensitivity * Time.timeScale;
        _yRot = Mathf.Clamp(_yRot, -75, 15);

        transform.localEulerAngles = new Vector3(-_yRot, _xRot, 0);
    }

    /// <summary>
    /// Приближение камеры, при сближении со стеной.
    /// </summary>
    private void DistanceControl()
    {
        if (Physics.Linecast(_wildBall.position, transform.position, out RaycastHit hit))
        {
            Vector3 hitLine = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            FollowingControl(hitLine);
        }
    }

    /// <summary>
    /// Зависимость камеры от размера шара.
    /// </summary>
    private void DistanceFromScale() => _distance = _wildBall.localScale.y / 3;

    /// <summary>
    /// Следование камеры за шаром.
    /// </summary>
    private void FollowingControl(Vector3 position) => transform.position = position;

    /// <summary>
    /// Расчет вектора расстояния от этого объекта, до указанного.
    /// </summary>
    /// <param name="obj">указанный объект</param>
    /// <returns>дистанция</returns>
    private Vector3 VectorOffset(Transform obj)
    {
        return transform.position - obj.position;
    }

    #endregion
}
