using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject panel;        // Reference to the UI panel
    [SerializeField] MouseLook mouseLook;     // Reference to the MouseLook script
    [SerializeField] FirstPersonController firstPersonController;  //Reference to the FirstPersonController script

    void Start()
    {
        /*
        // Initially check if the panel is active
        if (panel.activeInHierarchy)
        {
            // If the panel is active, make the cursor visible and disable MouseLook
            Cursor.visible = true;
            mouseLook.enabled = false;  // Disable MouseLook when the panel is active
        }
        else
        {
            // If the panel is not active, lock the cursor and make it invisible
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseLook.enabled = true;  // Enable MouseLook when the panel is not active
        }*/
        UpdateCursorState();
    }

    void Update()
    {
        /*
        // Check if the panel is active
        if (panel.activeInHierarchy)
        {
            Cursor.visible = true;
            mouseLook.enabled = false;  // Disable MouseLook when the panel is active
        }
        else
        {
            // Lock the cursor to the center of the screen when the panel is not active
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseLook.enabled = true;  // Enable MouseLook when the panel is closed
        }

        // Handle Escape key for unlocking the cursor and showing it
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			mouseLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
              // Optionally disable MouseLook if Escape is pressed (e.g., in menus)
        }*/

        UpdateCursorState();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }
    }

    void UpdateCursorState()
    {
        if (panel.activeInHierarchy)
        {
            UnlockCursor();
        }
        else
        {
            LockCursor();
        }
    }

    void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mouseLook.enabled = false; //Disable mouslook script
        firstPersonController.UnlockCursor(); //Unlock in fp controller
    }

    void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
        firstPersonController.LockCursor();
    }
}
