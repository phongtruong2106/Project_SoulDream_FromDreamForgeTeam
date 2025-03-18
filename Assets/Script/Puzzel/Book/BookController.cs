using UnityEngine;

public class BookController : NewMonoBehaviour
{
    [SerializeField] protected Object_interact object_Interact;

     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInteract();
    }
    protected virtual void LoadInteract()
    {
        if(this.object_Interact != null) return;
        this.object_Interact = FindAnyObjectByType<Object_interact>();
    }
}