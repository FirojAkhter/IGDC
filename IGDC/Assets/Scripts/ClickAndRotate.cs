using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndRotate : MonoBehaviour {
    
    [SerializeField]
    private float slow_factor;
    public float angle;
    private float last_angle;
    bool clicked;

    private void Start()
    {
        clicked = false;
    }
    void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
           // Debug.Log("Entering");
            //  transform.RotateAround (transform.position,Vector3.forward, 90 );
            StartCoroutine(Rotate());
        }
        
	}
   




    IEnumerator Rotate()
	{
         angle = 0;
        last_angle = 0;
			while(angle < 90) {
            last_angle = angle;
            angle += slow_factor;
            float rot = angle - last_angle;

            transform.RotateAround(transform.position, Vector3.forward, rot);
            
            
			yield return new WaitForSeconds(Time.deltaTime);
		}
        clicked = false;
	}

	
}
