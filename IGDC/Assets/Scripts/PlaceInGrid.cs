using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInGrid : MonoBehaviour {

    [SerializeField]
    private LayerMask lm;
    private Rigidbody rb;
    [SerializeField]
    private Material[] m;
    [SerializeField]
    private Material []mr;
    int currindex;
    private Transform t;
    private MeshRenderer m_r;
   public bool active;
   public bool placed;
  public  static bool generated;
   // static int checks = 0;
    public LayerMask lm_col;
    public float radius;


	// Use this for initialization
	void Start () {
        m_r = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        mr =m_r.materials;
        placed = true;
       if(rb == null)
        {
            Debug.Log("noRogidbody");
        }
      
	}
    

    private void Update()
    {
        Debug.DrawRay(transform.position, -transform.forward * 2,Color.red);
        //  int i = 0;
        if (placed)
        {
            Collider[] c = Physics.OverlapSphere(transform.position, radius, lm_col);


            if (c.Length == 0)
            {
                active = false;
                transform.tag = "pole";
            }
            else
            {
                foreach (Collider cl in c)
                {
                  //  if (cl.tag == "Generator")
                  //  {
                   //     generated = true;
                  //      active = true;
                  //      transform.tag = "ActivePole";
                        // checks++;

                  //  }


                    Debug.Log(cl.tag);
                    if (cl.tag == "ActivePole")
                    {
                        active = true;
                        transform.tag = "ActivePole";
                        break;
                        // i++;
                    }
                    else if (cl.tag == "pole")
                    {
                        active = false;
                        transform.tag = "pole";
                    }
                }
            }
        }
      //  else
       // {
       //     generated = false;
       //     Debug.Log(generated);
       // }

        if (active && placed && transform.tag == "ActivePole" && generated )
        {
            Glow(0);
        }
        else
            Glow(1);
    }
    // Update is called once per frame
    public bool Action()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,-transform.forward,out hit,100,lm))
        {
            StartCoroutine(Action2(hit));
            return true;
        }
        return false;
       
    }

    void Glow( int n)
    {
       
        mr[5] = m[n];
        m_r.materials = mr;
        
    }

    IEnumerator  Action2(RaycastHit h)
    {
        transform.SetParent(null);
        t = h.transform;
        Vector3 pos = new Vector3(h.transform.position.x, transform.position.y, h.transform.position.z);
        transform.position = pos;
        Debug.Log("Entering Action2");
        rb.isKinematic = false;
        rb.useGravity = true;
        yield return new WaitForSeconds(0.25f);
        placed = true;
        rb.isKinematic = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
            



