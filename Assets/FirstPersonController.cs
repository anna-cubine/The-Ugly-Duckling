using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float sensitivity = 3f;
    public float movementSpeed = 15f;

    private Camera playerCamera;
    private float rotationX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float moveX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(moveX, 0f, moveZ);
    }
}
