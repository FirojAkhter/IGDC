using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform ref_target;
	public Material changer;
	public static int index=1;
	public Solver sl;
 
    [SerializeField]
    private float rot_speed;
  //  public float rotY;
    private void FixedUpdate()
    {
      
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        Vector3 dir = ref_target.forward;
        //Debug.Log(dir);
        Debug.DrawRay(transform.position, createvector(45, ref_target.forward) * 5, Color.magenta);
        Debug.DrawRay(transform.position, createvector(45, -ref_target.forward) * 5, Color.black);
        Debug.DrawRay(transform.position, createvector(-45, ref_target.forward) * 5, Color.blue);
        Debug.DrawRay(transform.position, createvector(-45, -ref_target.forward) * 5, Color.grey);
        #region imp2
        /*  float x = Input.GetAxis("Vertical") * speed * Time.deltaTime;
          float z = Input.GetAxis("Horizontal") * rot_speed * Time.deltaTime;
          transform.Translate(0, 0, x);
          transform.Rotate(0, z, 0);*/
        #endregion imp2


        #region imp1
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rot_speed * Time.deltaTime);
            // if(Vector3.Angle(ref_target.forward,transform.forward)<= (0+2))
               transform.Translate(Vector3.forward*speed*Time.deltaTime);
         }
         else if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-dir), rot_speed * Time.deltaTime);
           //  if (Vector3.Angle(ref_target.forward, transform.forward) >= (180 - 2))
                 transform.Translate(Vector3.forward *speed * Time.deltaTime);
         }
         else if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
         {
            Vector3 dir2 = -ref_target.right;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir2), rot_speed * Time.deltaTime);
          //  if (Vector3.Angle(-ref_target.right, transform.forward) <= (0+2))
                 transform.Translate(Vector3.forward* speed * Time.deltaTime);
         }
         else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
         {
            Vector3 dir2 = ref_target.right;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir2), rot_speed * Time.deltaTime);
         //   if (Vector3.Angle(ref_target.right, transform.forward) <= (0+2))
                transform.Translate(Vector3.forward  * speed * Time.deltaTime);
         }
         else if(Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.A))
        {
            Vector3 dia_dir = createvector(-45, ref_target.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dia_dir), rot_speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Vector3 dia_dir = createvector(45, ref_target.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dia_dir), rot_speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Vector3 dia_dir = createvector(45, -ref_target.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dia_dir), rot_speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Vector3 dia_dir = createvector(-45, -ref_target.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dia_dir), rot_speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


        #endregion imp1
    }


    Vector3  createvector(float angle , Vector3 v)
    {
      Vector3 ans = new Vector3(v.x * Mathf.Cos(angle) + v.z * Mathf.Sin(angle ), 0, -1 * v.x * Mathf.Sin(angle ) + v.z * Mathf.Cos(angle ));
        return ans.normalized;
       
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Button") {
			if (col.gameObject.GetComponent<Puzzle> ().number == index) {
				col.gameObject.GetComponent<MeshRenderer> ().material = changer;
				col.gameObject.GetComponent<BoxCollider> ().enabled = false;
				index++;
			}
		 else {
			sl.Reset ();
			index = 1;
		}
	}

}
}
