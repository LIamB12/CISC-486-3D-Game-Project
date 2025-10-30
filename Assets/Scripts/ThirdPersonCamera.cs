using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    private GameObject _mainCamera;

    [Header("Cinemachine Settings")]
    [Tooltip("Following Target")]
    public GameObject CameraTarget;

    [Tooltip("Maximum angle of upward movement")]
    public float TopClamp = 70.0f;

    [Tooltip("Maximum angle of downward movement")]
    public float BottomClamp = -30.0f;

    private const float _threshold = 0.01f;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;

    private void Start()
    {
        // Determine whether the camera is defined. If not, use Tag to find the main camera in Scene
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        // Save the Y-axis angle of the camera target
        _cinemachineTargetYaw = CameraTarget.transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        // Determine whether the look variable has changed, calculate the rotation value
        if (_look.sqrMagnitude >= _threshold)
        {
            _cinemachineTargetYaw += _look.x;
            _cinemachineTargetPitch += _look.y;
        }

        // Set the angle within the correct range
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Convert the rotation value into quaternions
        CameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch,
            _cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;

        if (lfAngle > 360f) lfAngle -= 360f;

        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private Vector2 _look;

    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }
}