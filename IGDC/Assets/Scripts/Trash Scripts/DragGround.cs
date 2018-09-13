using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class DragGround : MonoBehaviour {

    private Rigidbody rb;
    public enum DragDirection { horizontal, vertical };
    [SerializeField]
    private DragDirection drag_dir;
    private Vector3 last_pos;
    public float speed;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        last_pos = transform.position;
	}

    private void OnMouseDrag()
    {
        Move_keys();
    }


    void Move_keys()
    {
        Vector3 pos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0).normalized;
        Debug.Log(pos);
        pos.z = 0;
        switch (drag_dir)
        {
            case DragDirection.horizontal:
                pos.y = last_pos.y;
                
                rb.velocity = (pos - last_pos) * speed;
                break;
            case DragDirection.vertical:
                pos.x = last_pos.x;
                rb.velocity = (pos - last_pos) * speed;
                break;
        }
        last_pos = transform.position;
    }
}
