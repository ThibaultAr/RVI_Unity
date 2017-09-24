using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour {

    public Camera cam;

    Vector3 lastMousePos;
    Vector3 mousePos;
    float cameraSpeed = 1f;
    float playerSpeed = 6f;
	// Use this for initialization
	void Start () {
        lastMousePos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = Input.mousePosition;
        Vector3 mouseTranslation = mousePos - lastMousePos;

        this.transform.RotateAround(this.transform.position, Vector3.up, mouseTranslation.x * cameraSpeed);

        float camRotationY = cam.transform.eulerAngles.x + mouseTranslation.y;
        print(camRotationY);
        //if(camRotationY < 90f && camRotationY > 0f)
            cam.transform.RotateAround(this.transform.position, this.transform.right, -mouseTranslation.y * cameraSpeed);

        lastMousePos = mousePos;
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow)) {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            movement += Vector3.right;
        }

        this.transform.Translate(movement * playerSpeed * Time.deltaTime);
    }
}
