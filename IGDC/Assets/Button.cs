using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Button : MonoBehaviour {
    [SerializeField]
    private PlayableDirector pd;
    [SerializeField]
    private GameObject disable;

   public bool enter = false;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask lm;
   public bool pressed = true;
    [SerializeField, Header("VirtualCamCamera")]
    private GameObject v_cam;
    
   public  bool persist;
    public Vector3 v_cam_pos;
    public Vector3 v_cam_rot;
    [SerializeField,Header("MainCam")]
    public Vector3 main_cam_pos;
    Quaternion main_cam_rot;
    public float lerp_speed;
    public float rot_lerp;
    private void Start()
    {
        pressed = true;
        persist = true;
    }
    // Use this for initialization

    private void Update()
    {
        Collider []c = Physics.OverlapSphere(transform.position, radius, lm);
        for(int i  = 0;i<c.Length;i++)
        {
            if(c[i].tag == "Player")
            {
                enter = true;
                break;
            }
            enter = false;
        }

     
      if(enter && Input.GetKeyDown(KeyCode.E) && !pressed)
        {
            StartCoroutine(Lerpcam());
            Debug.Log("Exiting Play Scene");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            v_cam.SetActive(false);
            disable.SetActive(true); 
            pressed = true;
       
        }
        else if (enter && Input.GetKeyDown(KeyCode.E) && pressed && persist)
        {
          

            v_cam.SetActive(true);
            Debug.Log("Play Scene");
            pd.Play();
            persist = false;
            disable.SetActive(false);
            main_cam_pos = disable.transform.position;
          main_cam_rot = disable.transform.rotation;
           StopAllCoroutines();
           disable.transform.position = v_cam_pos;
           disable.transform.rotation = Quaternion.Euler(v_cam_rot);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Invoke("TurnOffPlayer", 2f);
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    private void TurnOffPlayer()
    {
        pressed = false;
        persist = true;
       // v_cam.SetActive(false);
        
    }

    IEnumerator Lerpcam()
    {
       
       while(persist == true)
        {
            Debug.Log("Lerping");
            disable.transform.position = Vector3.Lerp(disable.transform.position, main_cam_pos, lerp_speed * Time.deltaTime);
            disable.transform.rotation = Quaternion.Slerp(disable.transform.rotation, main_cam_rot, rot_lerp * Time.deltaTime);
            yield return null;
        }
    }
}
