using UnityEngine;

public class CheckP2 : NewMonoBehaviour
{
    public bool isP2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
                isP2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isP2 = false;
        }
    }
}