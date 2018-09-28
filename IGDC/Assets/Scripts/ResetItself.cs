using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetItself : MonoBehaviour {
  
    [SerializeField]
    private Transform par;
    float rotY;
	// Use this for initialization
	void Start () {
        rotY = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward*5, Color.red);
       // float val = par.rotation.x;
        float y_rot = Input.GetAxis("Mouse X");
        rotY += y_rot* 10* Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, rotY, 0));
	}
}
