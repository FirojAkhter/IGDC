using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarRot : MonoBehaviour {

	public List<GameObject> gb;
    [SerializeField]
    private float slow_factor;
    public float angle;
    private float last_angle;
    bool clicked;

    void OnTriggerStay(Collider col)
	{
		Debug.Log ("Aya");
		if (col.tag == "Player")
			Debug.Log (col.gameObject.name);

		if (Input.GetKeyDown (KeyCode.E) ) 
		{
            if (!clicked)
            {
                clicked = true;
                 Debug.Log("Entering");
                //  transform.RotateAround (transform.position,Vector3.forward, 90 );
                StartCoroutine(Rotate());
            }


        }
	}

    IEnumerator Rotate()
    {
        foreach (GameObject g in gb)
        {
            angle = 0;
            last_angle = 0;
            while (angle < 90)
            {
                last_angle = angle;
                angle += slow_factor;
                float rot = angle - last_angle;
                
                g.transform.RotateAround(g.transform.position, Vector3.up, rot);

                Debug.Log("Rotating");
                yield return new WaitForSeconds(Time.deltaTime);
            }
            
        }
        clicked = false;
    }
}

