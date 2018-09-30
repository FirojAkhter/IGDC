using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_2 : MonoBehaviour {

	public Material changer;
	public static int index;
	public Solver sl;

	// Use this for initialization
	void Start () {
		index = 1;
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Button") {
			col.gameObject.GetComponent<MeshRenderer> ().material = changer;
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;
			index++;
		} else {
            Debug.Log("leavingdawdw Button");
			sl.Reset ();
			index = 1;
		}
	}
}
