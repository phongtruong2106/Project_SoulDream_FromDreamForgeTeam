using UnityEngine;

public class ObjectStairsDetected : NewMonoBehaviour
{
    [SerializeField] private string stairsTag = "Stairs";
    public ObjectClimbingStairs objectClimbingStairs;

    protected virtual void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag(stairsTag)) {
            objectClimbingStairs.stairsDetected = false;
        }
    }

    protected virtual void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag(stairsTag)) {
            objectClimbingStairs.stairsDetected = true;
        }  
    }

}