using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetector : MonoBehaviour {
    RaycastHit hit;
    [SerializeField]
    private float size_ray;
    [SerializeField]
    private LayerMask lm;
    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * size_ray, Color.cyan);
        if (Physics.Raycast(transform.position, transform.forward, out hit, size_ray,lm))
        {
            GridManager.box = hit.collider.transform;
        }
        else
            GridManager.box =null;
    }
}
