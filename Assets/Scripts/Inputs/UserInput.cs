using UnityEngine;
using GlobalStringVars;
using Photon.Pun;

[RequireComponent(typeof(BallBehaviour))]

public class UserInput : MonoBehaviour
{
    private PhotonView _photonView;
    private BallBehaviour _ballBehaviour;
    private CameraController _cameraController;
    private SphereScaler _sphereScaler;

    /// <summary>
    /// Start.
    /// </summary>
    private void Start()
    {
        Cursor.visible = false;

        _photonView = GetComponent<PhotonView>();
        _ballBehaviour = GetComponent<BallBehaviour>();
        _cameraController = _ballBehaviour._wildCamera.GetComponent<CameraController>();
        _sphereScaler = GetComponent<SphereScaler>();
    }

    /// <summary>
    /// Update.
    /// </summary>
    private void Update()
    {
        if (!_photonView.IsMine) return;

        CameraRotation();
        GetJumpButton();

        GetQ();
        GetE();
        GetX();

        _sphereScaler.ScaleLimiter();
        _sphereScaler.WeightLimiter();
        _ballBehaviour.GroundControl();
    }

    /// <summary>
    /// FixedUpdate.
    /// </summary>
    private void FixedUpdate()
    {
        if (!_photonView.IsMine) return; ////////

        Movement();
        MouseScrollWheel();
    }

    /// <summary>
    /// Передвижение.
    /// </summary>
    private void Movement()
    {
        var VerticalAxis = Input.GetAxis(GlobalVariables.VerticalAxis);
        var HorizontalAxis = Input.GetAxis(GlobalVariables.HorizontalAxis);

        _ballBehaviour.Move(VerticalAxis, HorizontalAxis);
    }

    /// <summary>
    /// Вращение камеры.
    /// </summary>
    private void CameraRotation()
    {
        var mouse_X = Input.GetAxis(GlobalVariables.MouseX);
        var mouse_Y = Input.GetAxis(GlobalVariables.MouseY);

        _cameraController.CameraControl(mouse_X, mouse_Y);
    }

    /// <summary>
    /// Прыжок при нажатии Jump;
    /// </summary>
    private void GetJumpButton()
    {
        if (Input.GetButtonDown(GlobalVariables.JumpButton))
            _ballBehaviour.Jump();
    }

    /// <summary>
    /// Scaler по колесу мыши.
    /// </summary>
    private void MouseScrollWheel()
    {
        var ScrollWheel = Input.GetAxis(GlobalVariables.MouseScrollWheel);

        _sphereScaler.ScaleWheel(ScrollWheel);
    }

    /// <summary>
    /// Минимальный размер по Q;
    /// </summary>
    private void GetQ()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            _sphereScaler.SetScale(1.0f, 10.0f);
    }

    /// <summary>
    /// Максимальный размер по E;
    /// </summary>
    private void GetE()
    {
        if (Input.GetKeyUp(KeyCode.E))
            _sphereScaler.SetScale(9.0f, 350.0f);
    }

    /// <summary>
    /// Базовый размер по Х;
    /// </summary>
    private void GetX()
    {
        if (Input.GetKeyUp(KeyCode.X))
            _sphereScaler.SetScale(3.0f, 10.0f);
    }
}
