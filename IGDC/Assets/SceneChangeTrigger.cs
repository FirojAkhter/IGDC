using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger : MonoBehaviour {
    [SerializeField]
    int load_index;
    [SerializeField]
    private GameObject g;
    private Animator an;
	// Use this for initialization
	void Start () {
        an = g.GetComponent<Animator>();
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            an.SetTrigger("Activate");
            Invoke("Action", 1f);
        }
    }

    void Action()
    {
        Scene_Manager.LoadNext(load_index);
    }
}
