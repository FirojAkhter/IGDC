using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheel : MonoBehaviour {

	public GameObject obj;

	void OnTriggerStay(Collider col)
	{
		//Debug.Log ("Aya");
		if (col.tag == "Player")
			Debug.Log (col.gameObject.name);

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			Debug.Log ("E Pressed.");
			//obj.transform.rotation = Quaternion.Lerp (transform.rotation,Quaternion.Lerp(90,0,0), 0.5);


		}
	}
}
