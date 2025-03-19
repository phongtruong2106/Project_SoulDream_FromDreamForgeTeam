using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : NewMonoBehaviour
{
    [SerializeField] protected hideawayCabinetController hideawayCabinetController;
    [SerializeField] protected string textBox;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected bool isPlayer  = false;
    public bool IsPlayer => isPlayer;
    [SerializeField] protected GameObject objcheckEnemy;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadhideawayCabinetController();
    }

    protected virtual void LoadhideawayCabinetController()
    {
        if(this.hideawayCabinetController != null) return;
        this.hideawayCabinetController = transform.parent.GetComponent<hideawayCabinetController>();
        Debug.Log(transform.name + ": LoadhideawayCabinetController()", gameObject);
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }
     protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(true);
            uIController._uI_PressButton._text_ObjPress.text = textBox;
            this.Following();
            this.isPlayer = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(false);
           this.isPlayer = false;
        }
    }
    protected virtual void Following()
    {
        if(this.target == null) return;
        this.uIController._uIGameObject.UI_PressButtonObj.gameObject.transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
}
