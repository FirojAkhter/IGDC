using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	[SerializeField]
	private LayerMask lm;
	public float ray_size;
	[SerializeField]
	private Transform t;
	[SerializeField]
	bool selected;
	public float rot_speed;
	Quaternion rot;
	bool clicked;
	// Use this for initialization
	void Start () {
		selected = false;
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		

		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin , ray.direction*ray_size , Color.red);

		if (Input.GetMouseButtonDown (0) && !selected) {
			if (Physics.Raycast (ray.origin, ray.direction, out hit, ray_size, lm)) {
				selected = true;
				clicked = true;
				t = hit.transform;
				rot = Quaternion.LookRotation (createvector (90, t.forward));
				//rot = Quaternion.Euler(new Vector3 (0, 0,  90));
				Debug.Log (rot);
			} 
		} 


		if (clicked )
			StartCoroutine (Rotate ());

		}

	IEnumerator Rotate()
	{
		

			while (t.rotation != rot) {
			
				t.localRotation = Quaternion.Slerp (t.localRotation, rot, rot_speed * Time.deltaTime);
				yield return null;
			}

		clicked = false;
		selected = false;
		t = null;
	}

	Vector3  createvector(float angle , Vector3 v)
	{
		Vector3 ans = new Vector3(v.x * Mathf.Cos(angle) + v.z * Mathf.Sin(angle ), 0, -1 * v.x * Mathf.Sin(angle ) + v.z * Mathf.Cos(angle ));
		return ans.normalized;

	}

}
