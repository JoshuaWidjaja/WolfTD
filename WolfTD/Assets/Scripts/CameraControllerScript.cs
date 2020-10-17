using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public float panningSpeed = 30f;
    public float panningBorderThickness = 15f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    //private bool movementEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.gameOverStatus == true)
        {
            this.enabled = false;
            return;
        }
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
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
