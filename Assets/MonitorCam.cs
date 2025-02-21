// Create a camera to reference to and display what that camera is seeing on the monitor cube
using UnityEngine;

public class MonitorCam : MonoBehaviour
{
    [SerializeField] Camera otherRoomCam; //Other room camera will be attached to this
    public RenderTexture renderTexture; //Need this to display the view on the cube

    // Update is called once per frame
    void Update()
    {
        //Update with other room camera view
        RenderTexture.active = renderTexture;
        otherRoomCam.Render();
        RenderTexture.active = null;
    }
}
