using System.Collections;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    public enum Direction { Left, Right, Up }
    public Direction direction;

    //Getting original color of button and doors so the color change is only for a second
    public Color originalColor;
    public Color doorColor;

    //Doors to open when button is pressed
    public GameObject doorLeft;
    public GameObject doorRight;
    public GameObject doorUp;

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        doorColor = doorLeft.GetComponent<Renderer>().material.color;
    }
    void OnMouseDown()
    {
        //Using a coroutine so I can wait some time before switching back to the original color
        StartCoroutine(ChangeColor());
        //Differentiation between directions
        if (direction == Direction.Left)
        {
            StartCoroutine(OpenDoor(doorLeft));
            Debug.Log("Go left");
        }
        else if (direction == Direction.Right)
        {
            StartCoroutine(OpenDoor(doorRight));
            Debug.Log("Go right");
        }
        else if (direction == Direction.Up)
        {
            StartCoroutine(OpenDoor(doorUp));
            Debug.Log("Go up");
        }
    }

    private IEnumerator ChangeColor()
    {
        //Giving player indication that button has been pressed
        GetComponent<Renderer>().material.color = Color.white;
        //Wait .2 seconds...
        yield return new WaitForSeconds(0.2f);
        //Return color to its original color
        GetComponent<Renderer>().material.color = originalColor;
    }

    private IEnumerator OpenDoor(GameObject door)
    {
        door.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(0.4f);
        door.GetComponent <Renderer>().material.color = doorColor;
    }
}
