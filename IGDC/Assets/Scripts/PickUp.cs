using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    [SerializeField]
    private LayerMask lm;
    [SerializeField]
    private float ray_size;
    RaycastHit hit;
    [SerializeField]
    private float offset;
 //   [SerializeField]
 //   private float lerp_speed;
    public bool picked;
    public GameObject t;
	// Use this for initialization
	void Start () {
        picked = false;
        t = null;
	}
	
	// Update is called once per frame
	void Update () {
       
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward * ray_size, Color.black);
        if (Physics.Raycast(transform.position+new Vector3(0,1,0), transform.forward , out hit,ray_size,lm) && !picked)
        {
         //   Debug.Log("Entering Pick");
            if (Input.GetKeyDown(KeyCode.E) )
            {
                t = hit.collider.transform.gameObject;
            //   Debug.Log("Entering Pick");
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.GetComponent<PlaceInGrid>().placed = false;
                hit.transform.tag = "pole";
                PickUpObject(hit.collider.transform);
                picked = true;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && picked)
        {
            Debug.Log("Entering Place 1st loop");

            if (t.GetComponent<PlaceInGrid>().Action())
            {
                picked = false;
               Debug.Log("Entering Place");
                t = null;
            }

        }


    }
    void PickUpObject(Transform g)
    {
        g.SetParent(this.transform);
        Vector3 pos = new Vector3(g.position.x, g.position.y+offset, g.position.z);
        g.position = pos;
       // g.position = Vector3.Lerp(g.position,pos,lerp_speed*Time.deltaTime);
       
    }

}
