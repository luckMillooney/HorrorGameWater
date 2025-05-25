using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FirstPersonCamera : MonoBehaviour
{

    [SerializeField]
    Transform focus = default;

    [SerializeField, Range(-89f, 89f)]
    float minVerticalAngle = -60f, maxVerticalAngle = 60f;

    [SerializeField, Range(1f, 360f)]
    float rotationSpeed = 90f;

    [SerializeField, Range(0.01f, 10f)]
    float mouseSensitivity = 1f;

    [SerializeField, Min(0f)]
    float upAlignmentSpeed = 360f;

    [SerializeField]
    bool lockCursor = true;

    Vector2 lookAngles = new Vector2(0f, 0f);
    Quaternion gravityAlignment = Quaternion.identity;
    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        lookAngles = new Vector2(transform.localEulerAngles.x, transform.localEulerAngles.y);
    }

    void LateUpdate()
    {
        UpdateGravityAlignment();
        ManualRotation();

        Quaternion lookRotation = gravityAlignment * Quaternion.Euler(lookAngles.x, lookAngles.y, 0f);
        transform.SetPositionAndRotation(focus.position, lookRotation);
    }

    void UpdateGravityAlignment()
    {
        Vector3 fromUp = gravityAlignment * Vector3.up;
        Vector3 toUp = CustomGravity.GetUpAxis(focus.position);
        float dot = Mathf.Clamp(Vector3.Dot(fromUp, toUp), -1f, 1f);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        float maxAngle = upAlignmentSpeed * Time.deltaTime;

        Quaternion newAlignment =
            Quaternion.FromToRotation(fromUp, toUp) * gravityAlignment;

        if (angle <= maxAngle)
        {
            gravityAlignment = newAlignment;
        }
        else
        {
            gravityAlignment = Quaternion.SlerpUnclamped(
                gravityAlignment, newAlignment, maxAngle / angle
            );
        }
    }

    void ManualRotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        lookAngles.y += mouseX * mouseSensitivity;
        lookAngles.x -= mouseY * mouseSensitivity;

        lookAngles.x = Mathf.Clamp(lookAngles.x, minVerticalAngle, maxVerticalAngle);

        // нормализация угла вокруг Y
        if (lookAngles.y < 0f) lookAngles.y += 360f;
        else if (lookAngles.y >= 360f) lookAngles.y -= 360f;
    }
}
