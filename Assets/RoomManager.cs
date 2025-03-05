using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public CubeButton[] buttons;

    //Adj matrix to test on
    private int[,] adjacencyMatrix =
    {
        { 0, 1, 0, 1 },
        { 1, 0, 1, 0 },
        { 0, 1, 0, 1 },
        { 1, 0, 1, 0 }
    };

    private HashSet<(int, int)> traveledPaths = new HashSet<(int, int)> ();

    public int currentRoom = 0; //Starting at room 0
    public int currentColumn;

    public TextMeshProUGUI[] doorLabels;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        (currentRoom, currentColumn) = FindFirstValidRoom(); //Place the player in the first 1 room.
        UpdateUI();
    }

    //Finding the first valid position for the player
    private (int, int) FindFirstValidRoom()
    {
        int row = 1; //Make sure you're starting in row 1
        for (int j = 1; j < adjacencyMatrix.GetLength(1); j++) //Go thru columns
        {
            if (adjacencyMatrix[row - 1, j - 1] == 1)
            {
                return (row - 1, j - 1);
            }
        }
        return (0, 0);
    }

    //Checking if the player can move to that room or now
    public bool IsValidMove(int chosenRoom)
    {
        return adjacencyMatrix[currentRoom, chosenRoom-1] == 1;
    }

    //Moving the player to the new room and updating everything
    public bool MoveToRoom(int newRoom)
    {
        //Debug.Log("current " + currentRoom);
        //Debug.Log("new "+newRoom);
        if (IsValidMove(newRoom))
        {
            currentRoom = newRoom-1;
            UpdateUI();
            return true;
        }
        else
        {
            //Lose a life
            Debug.Log("Incorrect!");
            return false;
        }
    }

    //Checking if the player has gone to another room before for the map to show green for past visited rooms
    public bool HasTraveled(int from, int to)
    {
        return traveledPaths.Contains((from, to));
    }

    // Update is called once per frame
    void UpdateUI()
    {
        int labelIndex = 0;

        for (int i = 0; i < doorLabels.Length; i++)
            doorLabels[i].text = ""; //Clear everything first

        //Need this for ensuring correct button order in the array
        int[] correctButtonOrder = { 0, 1, 2, 3 };

        //Getting all numbers except the current room number to display on doors
        for (int i = 0; i< adjacencyMatrix.GetLength(1); i++)
        {
            if (i != currentRoom)
            {
                if(labelIndex < doorLabels.Length)
                {
                    int destRoom = i + 1; //Converting from 0 based to one based

                    doorLabels[labelIndex].text = destRoom.ToString();

                    //Set corresponding button destination room
                    int buttonIndex = correctButtonOrder[labelIndex];
                    buttons[buttonIndex].SetDestinationRoom(destRoom);

                    Debug.Log("DOOR LABEL " + labelIndex + " -> Room " + destRoom);
                    Debug.Log("BUTTON " + labelIndex + " assigned to Room " + (buttons[labelIndex].getDestinationRoom()));

                    labelIndex++;

                    //Debug.Log("Button " + buttons[i] + " leads to " + destRoom);
                }
            }
        }

    }
}
