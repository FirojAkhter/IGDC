using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorlerp : MonoBehaviour {
    private Material m;
    [SerializeField]
    private Color startColor, endColor;
    [SerializeField]
    private float speed;
    float start_time;
   
	// Use this for initialization
	void Start () {
        m = GetComponent<MeshRenderer>().material;
        startColor = m.GetColor("_EmissionColor");
        start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = (Time.time - start_time) * speed;
        Color c = Color.Lerp(startColor, endColor, t);
        m.SetColor("_EmissionColor", c);
	}
}
