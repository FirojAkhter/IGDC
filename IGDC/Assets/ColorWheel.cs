using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheel : MonoBehaviour {

	public GameObject obj;
	private Vector3 rot=new Vector3(0,90f,0);
	public bool counter = true;
	public int pass;

	void Update()
	{
		transform.rotation = Quaternion.identity;
	}

	void OnTriggerStay(Collider col)
	{
		//Debug.Log ("Aya");
		if (col.tag == "Player")
			Debug.Log (col.gameObject.name);

		if (Input.GetKeyDown (KeyCode.E) && counter) 
		{
			Debug.Log ("E Pressed.");
			//obj.transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(new Vector3(90f,transform.rotation.y,transform.rotation.z)), Time.time*0.1f);
			//StartCoroutine(Rot());
			counter=false;
			StartCoroutine (Rotate (Vector3.up, 90, 1));


		}
	}

	IEnumerator Rot()
	{
		obj.transform.localRotation= Quaternion.Lerp (transform.rotation, Quaternion.Euler(new Vector3(90f,transform.rotation.y,transform.rotation.z)), Time.time*0.1f);
		yield return new WaitForSeconds (1f);
	}

	IEnumerator Rotate( Vector3 axis, float angle, float duration = 1.0f)
	{
		Quaternion from = obj.transform.rotation;
		Quaternion to = obj.transform.rotation;
		to *= Quaternion.Euler( axis * angle );

		float elapsed = 0.0f;
		while( elapsed < duration )
		{
			obj.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration );
			elapsed += Time.deltaTime;
			yield return null;
			if (elapsed / duration >=1f) 
			{
				counter = true;
			}
		}
		transform.rotation = to;
	}
}
