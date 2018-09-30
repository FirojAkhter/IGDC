using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndConnect : MonoBehaviour {
    [SerializeField, Header("BackCheck")]
    private Transform t;
    private MeshRenderer mr;
    [SerializeField, Header("Glowmaterial")]
    GameObject []g;
    public Material []m;
   // Material p_m;
    [SerializeField]
    private float []angle_check;
    [SerializeField, Header("RightAngles")]
    private int []angle;
    bool check;
    [Header("MaterialColors")]
    private Material m_c;
    [SerializeField]
    private Color startColor, endColor;
    [SerializeField]
    private float speed;
   // float start_time;
    // Use this for initialization
    void Start () {
        m = new Material[g.Length];
        for(int i = 0;i<m.Length;i++)
        {
            m[i] = g[i].GetComponent<MeshRenderer>().material;
        }
    //    p_m = mr.material;
      //  m_c = mr.material;
        startColor = m[0].GetColor("_EmissionColor");
      //  start_time = 0;
	}

    private void Update()
    {
      //  Debug.Log(transform.localEulerAngles);
        Vector3 rot = transform.localEulerAngles;
        float z = Mathf.RoundToInt(rot.z);
        int i = 0;
        for( i = 0;i<angle.Length;i++)
        {
            
          //  Debug.Log(z);
            if(z == angle[i] && t.tag == "RightOne")
            {
                
                foreach(float a in angle_check)
                {
                    if (Mathf.RoundToInt(t.localEulerAngles.z) == a)
                    {
                        check = true;
                        break;
                    }
                    else
                        check = false;
                }
               // Debug.Log("Entering Anglr");
                if (check)
                {
                    transform.tag = "RightOne";
                    break;
                }
            }
         //   else
          //  {
               // Debug.Log("Not Entering If");
                
         //   }
           
        }
        if (i == (angle.Length ))
            transform.tag = "Untagged";
    }


    // Update is called once per frame
    void LateUpdate () {
		if(transform.tag == "RightOne")
        {
            // transform.tag = "GlowOne";
            // mr.material = m;
            ColorChange(endColor, m[0].GetColor("_EmissionColor"));
        }
        else
        {
            ColorChange(startColor, m[0].GetColor("_EmissionColor"));
            
          //  mr.material = p_m;
        }
	}

    void ColorChange(Color e_c,Color s_c)
    {
        //float t = (Time.time - start_time) * speed;
        Color c = s_c;
          c= Color.Lerp(s_c, e_c, speed*Time.deltaTime);
        for(int i =0;i<m.Length;i++)
        {
            m[i].SetColor("_EmissionColor", c);
        }
       // m_c.SetColor("_EmissionColor", c);
    }
}
