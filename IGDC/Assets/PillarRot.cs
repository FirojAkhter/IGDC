using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarRot : MonoBehaviour {

	public List<GameObject> gb;
	private bool counter=true;

	void OnTriggerStay(Collider col)
	{
		Debug.Log ("Aya");
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

	IEnumerator Rotate( Vector3 axis, float angle, float duration = 1.0f)
	{
		foreach (GameObject i in gb) {
			Quaternion from = i.transform.rotation;
			Quaternion to = i.transform.rotation;
			to *= Quaternion.Euler (axis * angle);


			float elapsed = 0.0f;
			while (elapsed < duration) {
				i.transform.rotation = Quaternion.Slerp (from, to, elapsed / duration);
				elapsed += Time.deltaTime;
				yield return null;
				if (elapsed / duration >= 1f) {
					counter = true;
				}
			}
			transform.rotation = to;
		}
	}
}
