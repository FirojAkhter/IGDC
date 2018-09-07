﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    [SerializeField]
    private Transform target;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
       // Debug.Log(offset);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = target.position + offset;
	}
}
