using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInGrid : MonoBehaviour {
    [SerializeField]
    private LayerMask lm;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * -1 * 5, Color.red);
    }
    // Update is called once per frame
    public void Action(float offset)
    {
        transform.SetParent(null);
        RaycastHit hit;
       
        if(Physics.Raycast(transform.position,-transform.up,out hit,5,lm))
        {
           
            Vector3 pos = new Vector3(hit.transform.position.x,transform.position.y, hit.transform.position.z);
            transform.position = pos;
        }
      
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
