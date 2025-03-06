using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float sensitivity = 3f;
    public float movementSpeed = 15f;

    public Camera playerCamera;
    private float rotationX = 0f;


    private bool isCursorLocked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure playerCamera is assigned
        if (playerCamera == null)
        {
            playerCamera = GetComponentInChildren<Camera>();  // Fallback if not manually set
        }

        if (playerCamera == null)
        {
            Debug.LogError("No camera assigned in FirstPersonController!");
        }
        UnlockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCursorLocked)
        {
            HandleMovement();
        }
    }

    void HandleMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        //Rotating up/down
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        //Rotate player body based on mouse x
        transform.Rotate(Vector3.up * mouseX);
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCursorLocked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorLocked = false;
    }
}
