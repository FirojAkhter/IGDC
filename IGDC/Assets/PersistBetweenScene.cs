using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistBetweenScene : MonoBehaviour {
	private static PersistBetweenScene instance ;
	// Use this for initialization
	void Awake () {
		if (!instance) {
			instance = this;
		} else
			Destroy (this.gameObject);
		
	}
	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
