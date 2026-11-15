using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSettings : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;              // drag the ball here
    [SerializeField] private Vector3 targetOffset = new Vector3(0, 1f, 0f);

    [Header("Orbit")]
    [SerializeField] private float distance = 8f;
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float minPitch = -20f;
    [SerializeField] private float maxPitch = 70f;

    [Header("Smoothing")]
    [SerializeField] private float followSmooth = 10f;

    private float yaw;
    private float pitch = 25f;

    void Start()
    {
        // Lock/hide cursor (optional — remove for free cursor)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Mouse input
        Vector2 input = Mouse.current.delta.value;
        yaw   += input.x * mouseSensitivity;
        pitch -= input.y * mouseSensitivity;
        pitch  = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Desired position
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredPos = target.position + targetOffset - rotation * Vector3.forward * distance;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSmooth * Time.deltaTime);
        transform.LookAt(target.position + targetOffset);
    }
}