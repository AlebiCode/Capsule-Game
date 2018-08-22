using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Vector3 offset;
    public bool ShowCursor;
    public float Sensitivity;
    public GameObject player;

    // Use this for initialization
    void Start() {
        offset = transform.position - player.transform.position;

        if (ShowCursor==false)
        {
            Cursor.visible = false;
        }

    }

    // Update is called once per frame
    void LateUpdate() {
        transform.position = player.transform.position + offset;


        float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Sensitivity;
        float newRotationX = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * Sensitivity;
        gameObject.transform.localEulerAngles = new Vector3(newRotationX, newRotationY, 0);



 
    }
}
    