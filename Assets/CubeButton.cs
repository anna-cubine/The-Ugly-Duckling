using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    public enum Direction { Left, Right, Up, Down }
    public Direction direction;

    //Getting original color of button and doors so the color change is only for a second
    public UnityEngine.Color originalColor;
    public UnityEngine.Color doorColor;

    public TextMeshProUGUI doorText; //For the text on each door.

    public GameObject door;
    public GameObject[] walls;

    public TextMeshProUGUI label;
    private int destinationRoom; //Room that pressed button will lead to

    //private UnityEngine.Color newColor = new UnityEngine.Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

    //Room that the player is trying to go to
    public void SetDestinationRoom(int room)
    {
        destinationRoom = room;
        label.text = "Go to " + room;
    }

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        doorColor = door.GetComponent<Renderer>().material.color;
    }
    void OnMouseDown()
    {
        //Getting instances of current room and current available rooms to go to
        int currentRow = RoomManager.Instance.currentRoom;
        int currentCol = RoomManager.Instance.currentColumn;
        
        if (RoomManager.Instance.MoveToRoom(destinationRoom))
        {
            //Upadting map
            Toggle.Instance.setMap();
            //Using a coroutine so I can wait some time before switching back to the original color
            StartCoroutine(OpenDoor(door));
            StartCoroutine(ChangeColor());
        }
        UnityEngine.Color newColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponent<Renderer>().material.color = newColor;
        }
    }

    //Updating door texts depending on which room user is in
    public void UpdateDoorLabel(int roomNumber)
    {
        doorText.text = roomNumber.ToString();
    }

    private IEnumerator ChangeColor()
    {
        //Giving player indication that button has been pressed
        GetComponent<Renderer>().material.color = UnityEngine.Color.white;
        //Wait .2 seconds...
        yield return new WaitForSeconds(0.2f);
        //Return color to its original color
        GetComponent<Renderer>().material.color = originalColor;
    }

    private IEnumerator OpenDoor(GameObject door)
    {
        door.GetComponent<Renderer>().material.color = UnityEngine.Color.black;
        yield return new WaitForSeconds(0.4f);
        door.GetComponent <Renderer>().material.color = doorColor;
    }
}
