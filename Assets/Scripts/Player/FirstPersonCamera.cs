using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    // Mouse values
    [SerializeField] private float mouseSensitivity = 20;
    [SerializeField] private float rotationSmoothTime = 0.07f;

    // Min and Max value the player will be able to move the camera
    [SerializeField] private Vector2 pitchMinMax = new Vector2(-40, 85);    // Not X and Y | Min and Max values

    // Actual yaw and pitch values | Only to debug
    [SerializeField] private float yaw;
    [SerializeField] private float pitch;

    // Camera values
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    void Start()
    {
        // Lock the mouse in the center and hide it from the player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // If the cursor is locked
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            transform.eulerAngles = currentRotation;
        }


        // If we press the Escape key (to show a menu for example) the cursor will be unlocked and will be visible again
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
