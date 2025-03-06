using UnityEngine;

public class PauseOnPanelOpen : MonoBehaviour
{
    [SerializeField] GameObject uiPanel; // The UI panel that when active will pause the game

    void Update()
    {
        // Check if the UI panel is active in the scene
        if (uiPanel.activeInHierarchy)
        {
            // Pause the game
            Time.timeScale = 0f;
        }
        else
        {
            // Resume the game
            Time.timeScale = 1f;
        }
    }
}