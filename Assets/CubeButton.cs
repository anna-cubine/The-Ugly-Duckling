using System.Collections;
using System.Drawing;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    public enum Direction { Left, Right, Up }
    public Direction direction;

    //Getting original color of button and doors so the color change is only for a second
    public UnityEngine.Color originalColor;
    public UnityEngine.Color doorColor;

    //Doors to open when button is pressed
    public GameObject doorLeft;
    public GameObject doorRight;
    public GameObject doorUp;
    public GameObject[] walls;

    //private UnityEngine.Color newColor = new UnityEngine.Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

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
        UnityEngine.Color newColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponent<Renderer>().material.color = newColor;
        }
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
