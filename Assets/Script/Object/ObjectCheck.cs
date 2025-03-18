using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : NewMonoBehaviour
{
   [SerializeField] protected UIController uIController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController!= null) return;
        this.uIController = GetComponent<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider collision)
   {
        if (collision.gameObject.layer == LayerMask.NameToLayer("UI")) {
            uIController._uI_PressButton.OpenObjPress();
        }
   }
    
   protected virtual void OnTriggerExit(Collider collision)
   {
        if (collision.gameObject.layer == LayerMask.NameToLayer("UI")) {
            uIController._uI_PressButton.CloseObjPress();
        }
   }
}
