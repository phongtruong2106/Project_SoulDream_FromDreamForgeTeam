using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckP : NewMonoBehaviour
{
    public bool isP1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           
            isP1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isP1 = false;
        }
    }
}
