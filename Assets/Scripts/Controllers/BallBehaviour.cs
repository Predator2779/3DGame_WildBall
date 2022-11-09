using UnityEngine;
using GlobalStringVars;

//[RequireComponent(typeof(Rigidbody))]

public class BallBehaviour : MonoBehaviour
{
    #region Переменные

    public Transform _wildCamera;
    public float _speedForce = 120.0f;
    public float _jumpForce = 120.0f;
    public float _jumpRotation = 5.0f;

    [SerializeField] private Vector3 _vectorMove;
    [SerializeField] private Rigidbody _rbody;
    [SerializeField] private float _speed;
    private float _jump;
    private bool _isGround;

    #endregion

    #region Методы

    #region Контроль шара

    /// <summary>
    ///  Start.
    /// </summary>
    private void Start() => _rbody = GetComponent<Rigidbody>();

    /// <summary>
    /// Движение шара.
    /// </summary>
    public void Move(float VerticalAxis, float HorizontalAxis)
    {
        var v = ProjectVector(_wildCamera.forward) * VerticalAxis;
        var h = ProjectVector(_wildCamera.right) * HorizontalAxis;

        _vectorMove = h + v;

        ApplyingForce(_vectorMove, _speed, ForceMode.Acceleration);
    }

    /// <summary>
    /// Прыжок.
    /// </summary>
    public void Jump()
    {
        if (_vectorMove.magnitude < 0.7f)
            ApplyingForce(Vector3.up, _jump, ForceMode.Impulse);
    }

    /// <summary>
    /// Нормализация вектора, относительно земли.
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    private Vector3 ProjectVector(Vector3 vector)
    {
        return Vector3.ProjectOnPlane(vector, Vector3.up);
    }

    /// <summary>
    /// Приложение силы к шару.
    /// </summary>
    private void ApplyingForce(Vector3 vector, float force, ForceMode forceMode)
    {
        _rbody.AddForce(vector * force, forceMode);
    }

    #endregion

    #region Контроль коллизии земли

    /// <summary>
    /// Контроль земли.
    /// </summary>
    public void GroundControl()
    {
        if (_isGround)
        {
            _speed = _speedForce;
            _jump = _jumpForce;
        }
        else
        {
            _speed = _speedForce * 0.2f;
            _jump = 0;

            RotateBall();
        }
    }

    /// <summary>
    /// Вращение шара в воздухе.
    /// </summary>
    private void RotateBall()
    {
        _jumpRotation *= Time.timeScale;

        transform.Rotate(_jumpRotation, _jumpRotation, _jumpRotation, Space.World);
    }

    /// <summary>
    /// OnCollisionEnter.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGround = true;
    }

    /// <summary>
    /// OnCollisionStay.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGround = true;
    }

    /// <summary>
    /// OnCollisionExit.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGround = false;
    }

    #endregion

    #endregion
}
