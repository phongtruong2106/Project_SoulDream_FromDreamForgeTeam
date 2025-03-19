using UnityEngine;

public class ItemCheck : NewMonoBehaviour
{
    public bool isItem = false;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item")) {
            this.isItem = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item")) {
           this.isItem = false;
        }
    }
     
}