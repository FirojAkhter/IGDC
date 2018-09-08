using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    [SerializeField]
    private float sensitivityX;
    [SerializeField]
    private float sensitivityY;
    [SerializeField]
    float angle;
    float mouseX;
    float mouseY;
    float rotX;
    float rotY;
	// Use this for initialization
	void Start () {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
        
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        float y_rot = Input.GetAxis("Mouse X");
        float x_rot = Input.GetAxis("Mouse Y");
        mouseX = x_rot;
        mouseY = y_rot;
        rotX += mouseX * sensitivityX *Time.deltaTime;
        rotY += mouseY * sensitivityY * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, angle-20f, angle);
        Quaternion rotation = Quaternion.Euler(rotX, rotY, transform.localRotation.z);
        transform.localRotation = rotation;
     
    }  }
