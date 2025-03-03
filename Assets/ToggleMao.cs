using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class Toggle : MonoBehaviour
{
    public static Toggle Instance;
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

    public void setMap()
    {
        int[,] matrix = new int[5, 5]; // 5x5 matrix

        // Initialize the first row and first column with 1 to 4
        for (int i = 1; i < 5; i++)
        {
            matrix[0, i] = i; // First row: 1 2 3 4
            matrix[i, 0] = i; // First column: 1 2 3 4
        }

        //Example matrix to work with
        int[,] adjacencyMatrix =
        {
            { 0, 1, 0, 1 },
            { 1, 0, 1, 0 },
            { 0, 1, 0, 1 },
            { 1, 0, 1, 0 }
        };

        //Getting where player is currently positioned for map updating
        int currentRoom = RoomManager.Instance.currentRoom;

        // Convert matrix to a string for display
        string displayText = "";
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0 && j == 0)
                {
                    displayText += "  "; // Empty space at (0,0)
                } else if(i == 0 && j != 0)
                {
                    //I wasn't able to dipslay the map correctly without these two other if statements
                    displayText += $"{j}  ";
                } else if (j == 0 && i != 0)
                {
                    displayText += $"{i}  ";
                } else {
                    int roomValue = adjacencyMatrix[i -1, j - 1]; //Need to do this because first row and column are not part of matrix
                    //If the player is at the current room, that number is blue on the adj matrix
                    if (i-1 == RoomManager.Instance.currentRoom && j-1 == RoomManager.Instance.currentColumn)
                    {
                        displayText += $"<color=blue>{adjacencyMatrix[i, j]}  </color>";
                    //This will show green for past rooms visited
                    } else if (roomValue == 1 && RoomManager.Instance.HasTraveled(i-1, j-1))
                    {
                        displayText += $"<color=green>{matrix[i, j]}  </color";
                    }
                    else
                    {
                        displayText += $"{roomValue}  ";
                    }
                }
            }
            displayText += "\n"; // New line for each row
        }
        // Set the text component to display the adjacency matrix
        overlayText.text = displayText;
    }
}
