using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform ref_target;
 
    [SerializeField]
    private float rot_speed;
  //  public float rotY;
    private void Update()
    {
      
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        Vector3 dir = ref_target.forward;
        Debug.Log(dir);
        #region imp2
      /*  float x = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float z = Input.GetAxis("Horizontal") * rot_speed * Time.deltaTime;
        transform.Translate(0, 0, x);
        transform.Rotate(0, z, 0);*/
        #endregion imp2


        #region imp1
         if (Input.GetKey(KeyCode.W))
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rot_speed * Time.deltaTime);
            // if(Vector3.Angle(ref_target.forward,transform.forward)<= (0+2))
               transform.Translate(Vector3.forward*speed*Time.deltaTime);
         }
         else if(Input.GetKey(KeyCode.S))
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-dir), rot_speed * Time.deltaTime);
           //  if (Vector3.Angle(ref_target.forward, transform.forward) >= (180 - 2))
                 transform.Translate(Vector3.forward *speed * Time.deltaTime);
         }
         else if(Input.GetKey(KeyCode.A))
         {
            Vector3 dir2 = -ref_target.right;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir2), rot_speed * Time.deltaTime);
          //  if (Vector3.Angle(-ref_target.right, transform.forward) <= (0+2))
                 transform.Translate(Vector3.forward* speed * Time.deltaTime);
         }
         else if (Input.GetKey(KeyCode.D))
         {
            Vector3 dir2 = ref_target.right;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir2), rot_speed * Time.deltaTime);
         //   if (Vector3.Angle(ref_target.right, transform.forward) <= (0+2))
                transform.Translate(Vector3.forward  * speed * Time.deltaTime);
         }
        #endregion imp1
    }

}
