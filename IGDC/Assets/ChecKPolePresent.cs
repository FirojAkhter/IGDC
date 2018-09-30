using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecKPolePresent : MonoBehaviour {

   
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "pole" || other.tag == "ActivePole")
        {
            Debug.Log("Triggering grid");
            PlaceInGrid.generated = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pole")
        {
            PlaceInGrid.generated = false;
        }
    }
}
