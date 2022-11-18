using UnityEngine;

public class SphereScaler : MonoBehaviour
{
    private Rigidbody _rb;
    private float _scaleValue = 0;

    public delegate void Scaling(float scale);
    public Scaling OnScaling;

    private void Start() => _rb = GetComponent<Rigidbody>();

    /// <summary>
    /// ����������� ������� ���� �� ������ ����.
    /// </summary>
    /// <param name="scaleValue"></param>
    public void ScaleWheel(float scaleValue)
    {
        _scaleValue = scaleValue;

        transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue);
    }

    /// <summary>
    /// ����������� �������� ����.
    /// </summary>
    public void ScaleLimiter()
    {
        if (transform.localScale.y < 1.1f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (transform.localScale.y > 9.1f)
        {
            transform.localScale = new Vector3(9.0f, 9.0f, 9.0f);
        }
    }

    /// <summary>
    /// ����������� ������������� ����.
    /// </summary>
    public void WeightLimiter()
    {
        if (transform.localScale.y > 3.0f)
        {
            _rb.mass += _scaleValue * 50.0f;

            if (_rb.mass > 350.1f)
            {
                _rb.mass = 350.0f;
            }
        }
        else
        {
            _rb.mass = 10.0f;
        }
    }

    /// <summary>
    /// ��������� ������� � ���� ����.
    /// </summary>
    /// <param name="scale"></param>
    /// <param name="mass"></param>
    public void SetScale(float scale, float mass)
    {
        transform.localScale = new Vector3(scale, scale, scale);
        _rb.mass = mass;
    }

    public void SendScaleMessage()
    {
        OnScaling?.Invoke(transform.localScale.x);
    }
}