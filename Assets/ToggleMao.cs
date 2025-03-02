using UnityEngine;
using TMPro;

public class Toggle : MonoBehaviour
{

    public GameObject map; // Assign in Inspector
    private bool isOverlayActive = false;
    public TextMeshProUGUI overlayText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setMap();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if 'X' key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            toggleOverlayScreen();
        }
    }

    void toggleOverlayScreen()
    {
        isOverlayActive = !isOverlayActive;
        map.SetActive(isOverlayActive);
    }

    void setMap()
    {
        int[,] matrix = new int[5, 5]; // 5x5 matrix

        // Initialize the first row and first column with 1 to 4
        for (int i = 1; i < 5; i++)
        {
            matrix[0, i] = i; // First row: 1 2 3 4
            matrix[i, 0] = i; // First column: 1 2 3 4
        }

        // Convert matrix to a string for display
        string displayText = "";
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0 && j == 0)
                {
                    displayText += "  "; // Empty space at (0,0)
                }
                else
                {
                    displayText += matrix[i, j] + " ";
                }
            }
            displayText += "\n"; // New line for each row
        }

        // Set the text component to display the adjacency matrix
        overlayText.text = displayText;
    }
}
