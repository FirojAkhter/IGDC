using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGround : MonoBehaviour {

	[SerializeField]
	private Camera cam;
	Ray ray;
	[SerializeField]
	private LayerMask lm;
	public bool selected;
	RaycastHit hit;
	public enum DragDirection { horizontal, vertical };
	[SerializeField]
	private DragDirection drag_dir;
	[SerializeField]
	Transform t;
	[SerializeField]
	private float speed;

	void Start()
	{
		selected = false;
	}


	void Update()
	{
		Debug.DrawRay (ray.origin,ray.direction*10,Color.red);
		ray = cam.ScreenPointToRay (Input.mousePosition);
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
		
		}

	}
		
	void FixedUpdate()
	{if(selected)
		Move_keys (t);
	}

void Move_keys(Transform tr)
{
	 Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
	switch (drag_dir)
	{
	case DragDirection.horizontal:
		pos.y = 0;
		tr.position = pos ;
		break;
	case DragDirection.vertical:
		pos.x = 0;
		tr.position = pos ;
		break;
	}
}
   
}
