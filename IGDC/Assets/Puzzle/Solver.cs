using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour {

	public List<GameObject> gb;
	public Material def;

	public void Reset()
	{
		foreach (GameObject i in gb) 
		{
			i.GetComponent<BoxCollider> ().enabled = true;
			i.GetComponent<MeshRenderer> ().material = def;
		}
	}
}
