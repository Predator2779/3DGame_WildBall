using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallBehaviour _ballBehaviour;
    [SerializeField] private CameraController _cameraController;

    [SerializeField] [Range(1.0f, 100.0f)] private float _cameraSensitivity;

    [SerializeField] private float _ballSpeed, _ballJump, _ballRotation;

    [SerializeField] private bool _EDIT_MODE = false;
    [SerializeField] private GameObject _roomConstructor;

#if  UNITY_EDITOR
    public bool EDIT_MODE { get { return _EDIT_MODE; } private set { } }

    public GameObject RoomConstructor { get { return _roomConstructor; } private set { } }

    [ContextMenu("SetValues")]
    private void SetValues()
    {
        _ballBehaviour._speedForce = _ballSpeed;
        _ballBehaviour._jumpForce = _ballJump;
        _ballBehaviour._jumpRotation = _ballRotation;
        _cameraController._sensitivity = _cameraSensitivity;
    }
#endif
}
