using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;
    [SerializeField]
    Vector3[] clip_points = new Vector3[5];
    [SerializeField]
    Vector3[] virtual_clip_points = new Vector3[5];
    [SerializeField]
    float c_x, c_y, c_z;
    [SerializeField]
    float v_c_x, v_c_y, v_c_z;
    RaycastHit hit;
    [SerializeField]
    Camera cam;
    [SerializeField]
    float angle;
   
    // Use this for initialization
    void Start () {
       
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
        c_z =cam.nearClipPlane;
        c_x = Mathf.Tan(cam.fieldOfView / 4.48f) * c_z;
        c_y = c_x / cam.aspect;
       v_c_z = cam.nearClipPlane;
       v_c_x = Mathf.Tan(cam.fieldOfView / angle) * v_c_z;
       v_c_y = v_c_x / cam.aspect;
        CalculateVirtualClippingPoints(cam.transform.position, transform.rotation, ref virtual_clip_points);
        CalculateClippingPoints(cam.transform.position, transform.rotation, ref clip_points);
    }
 
    void Update () {
      //  distance = maxDistance;
        CalculateClippingPoints(cam.transform.position, transform.parent.localRotation, ref clip_points);

        CalculateVirtualClippingPoints(cam.transform.position-(cam.transform.forward *0.1f), transform.parent.localRotation, ref virtual_clip_points);
        Drawrays(transform.parent.position,ref clip_points,Color.green);
        Drawrays(transform.parent.position, ref virtual_clip_points,Color.red);
        // Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);

        if (castRayToClips(transform.parent.position, hit,clip_points))
        {
            distance = GetDistance(transform.parent.position);
           //distance = Mathf.Clamp(distance, minDistance, maxDistance);
        
           
        }
        else if(castRayToClips(transform.parent.position,hit,virtual_clip_points) && distance != maxDistance)
       {
            Debug.Log(" Colliding");
            
       }
        else
        {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, smooth * Time.deltaTime);
	}

    void CalculateClippingPoints(Vector3 pos , Quaternion rot , ref Vector3 []ar)
    {
        ar = new Vector3[5];
        ar[0] = pos - Vector3.forward*0.2f ;
        ar[1] = pos + rot *new Vector3(-c_x, c_y, c_z)  ;
        ar[2] = pos + rot*new Vector3(c_x, c_y, c_z);
        ar[3] = pos + rot*new Vector3(-c_x, -c_y, c_z);
        ar[4] = pos + rot*new Vector3(c_x, -c_y, c_z);
    }

    void CalculateVirtualClippingPoints(Vector3 pos, Quaternion rot, ref Vector3[] ar)
    {
        ar = new Vector3[5];
        ar[0] = pos - Vector3.forward * 0.2f;
        ar[1] = pos + rot * new Vector3(-v_c_x, v_c_y, v_c_z);
        ar[2] = pos + rot * new Vector3(v_c_x, v_c_y, v_c_z);
        ar[3] = pos + rot * new Vector3(-v_c_x, -v_c_y, v_c_z);
        ar[4] = pos + rot * new Vector3(v_c_x, -v_c_y, v_c_z);
    }

    bool castRayToClips(Vector3 target,RaycastHit h , Vector3[] ar)
    {
       
        for(int i = 0;i<ar.Length;i++)
        {
            //Vector3 dir = (clip_points[i] - target).normalized;
            if (Physics.Linecast(target, ar[i],out h))
                return true;
        }
        return false;
    }


    void  Drawrays(Vector3 target,ref Vector3[] ar,Color c)
    {

        for (int i = 0; i < ar.Length; i++)
        {
            Debug.DrawLine(target, ar[i], c);
            
        }
    }

    float GetDistance(Vector3 target)
    {
        float val = -1;
          
        for (int i = 0; i < clip_points.Length; i++)
        {
            RaycastHit h;
            //Vector3 dir = (clip_points[i] - target).normalized;
          if(  Physics.Linecast(target, clip_points[i], out h))
            {
                if (val == -1)
                    val = h.distance;
                else if (h.distance < val)
                    val =h.distance;

            }

        }

        if (val == -1)
            return 0;
        else
            return val;
    }
}
