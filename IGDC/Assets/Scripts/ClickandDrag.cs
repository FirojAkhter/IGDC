using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandDrag : MonoBehaviour {
 
    Ray ray;
    [SerializeField]
    private LayerMask lm;
   public bool selected;
    RaycastHit hit;
    [SerializeField]
    Transform t;
    Vector3 mouse_pos;
    public float speed;
    //Vector3 offset;
    public enum DragDirection { horizontal, vertical };
    [SerializeField]
    private DragDirection drag_dir;
	[SerializeField]
	private float x_left;
	[SerializeField]
	private float x_right;
	[SerializeField]
	private float y_top;
	[SerializeField]
	private float y_down;
    // Use this for initialization
    void Start () {
        selected = false;

	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         //  mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //
      //  mouse_pos.z = 0;
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
       // Debug.Log(mouse_pos);
        if(Physics.Raycast(ray,out hit,20,lm) && Input.GetMouseButtonDown(0) && !selected)
        {
           // Debug.Log("Hitting");
            selected = true;
            if (hit.transform.tag == "UpDown")
                drag_dir = DragDirection.vertical;
            else
                drag_dir = DragDirection.horizontal;
               t = hit.transform;
           
        }
        else  if (selected && Input.GetMouseButtonDown(0))
            {
                selected = false;
                t = null;
             	//offset =Vector3.zero;
            }  
        
	}
	void FixedUpdate()
	{
		if (selected)
		{
			Move_keys(t);
			//Move(mouse_pos,t,offset);
		}
	}



    void Move_keys(Transform tr)
    {
        Vector3 pos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y new"), 0).normalized;
        switch (drag_dir)
        {
		case DragDirection.horizontal:
			pos.y = 0;

			tr.position += pos * speed * Time.fixedDeltaTime;

			//tr.position = new Vector3 (Mathf.Clamp(transform.position.x,x_left,x_right),tr.position.y,tr.position.z);
                break;
            case DragDirection.vertical:
                pos.x = 0;
			tr.position += pos * speed * Time.fixedDeltaTime;
		//	tr.position = new Vector3 (tr.position.x,Mathf.Clamp(tr.position.y,y_top,y_down),tr.position.z);
                break;
        }
    }

   
}
