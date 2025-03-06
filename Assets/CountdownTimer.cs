using UnityEngine;
using TMPro;  // If you're using TextMesh Pro

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; // Reference to the UI Text component
    [SerializeField] private float countdownTime = 60f; // Set the starting countdown time (in seconds)

    private float currentTime;

    void Start()
    {
        // Initialize the countdown
        currentTime = countdownTime;
        UpdateTimerText();
    }

    void Update()
    {
        // Decrease the time every frame
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Decrease time by the time passed since the last frame
            UpdateTimerText();
        }
        else
        {
            // Timer is finished
            currentTime = 0;
            UpdateTimerText();
            TimerFinished();
        }
    }

    // Update the timer display in the UI
    private void UpdateTimerText()
    {
        // Convert the current time to minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60); // Get the number of minutes
        int seconds = Mathf.FloorToInt(currentTime % 60); // Get the remaining seconds

        // Format the timer text as MM:SS
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Called when the timer finishes
    private void TimerFinished()
    {
        Debug.Log("Timer Finished!");
        // You can add any logic here for when the timer reaches zero (e.g., game over, next level, etc.)
    }
}