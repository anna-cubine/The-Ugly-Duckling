using UnityEngine;

public class DisappearOnClick : MonoBehaviour
{
    // This method will be called when the object is clicked
    void OnMouseDown()
    {
        // Find the UIController in the scene
        UIController uiController = FindAnyObjectByType<UIController>();

        if (uiController != null)
        {
            uiController.OnEnemyHit();  // Call the method
        }
        else
        {
            Debug.LogError("UIController not found in the scene!");
        }

        // Destroy the GameObject when it is clicked
        Destroy(gameObject);
    }
}
