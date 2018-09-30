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
            
            Debug.Log("Exiting Play Scene");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
          //  v_cam.SetActive(false);
           // disable.SetActive(true); 
            pressed = true;
            pd.Resume();
       
        }
        else if (enter && Input.GetKeyDown(KeyCode.E) && pressed && persist)
        {
          

            //v_cam.SetActive(true);
            Debug.Log("Play Scene");
            pd.Play();
            persist = false;
           // disable.SetActive(false);
       
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Invoke("TurnOffPlayer", 3f);
            
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
        pd.Pause();
    }

}
