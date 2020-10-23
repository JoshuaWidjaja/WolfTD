using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles camera behavior and control in the game.
public class CameraControllerScript : MonoBehaviour
{
    //Initializing variables
    public float panningSpeed = 30f;
    public float panningBorderThickness = 15f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    //private bool movementEnabled = true;


    // Update is called once per frame
    //Checks to see if the game is on a gameOver. If it is, disables player control of the camera.
    //Also contains code for WASD control for camera movement, as well as mouse scroll wheel for zooming in and out
    void Update()
    {
        if (GameManagerScript.gameOverStatus == true)
        {
            this.enabled = false;
            return;
        }

        //DEBUGGING code, allows player to take control/end control by pressing escape
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            movementEnabled = !movementEnabled;
        }

        if (!movementEnabled)
        {
            return;
        }*/

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward *panningSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panningSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panningSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panningSpeed * Time.deltaTime, Space.World);
        }

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scrollWheel * 1000 * scrollSpeed * Time.deltaTime;
        //minY and maxY are the min and max player is allowed to zoom in and out.   
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
