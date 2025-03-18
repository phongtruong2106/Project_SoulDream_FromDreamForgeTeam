using UnityEngine;

public class DL_Check : NewMonoBehaviour
{
    [SerializeField] protected DL_CheckController dL_CheckController;
    [SerializeField] protected UIController  uIController;
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected SO_Dialogue sO_Dialogue;
   

    protected virtual void Update()
    {
        //Override
    }
     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDLCheckController();
        this.LoadUIController();
        this.LoadBoxCollider();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
    }
    protected virtual void LoadBoxCollider()
    {
        if(this.boxCollider != null) return;
        this.boxCollider = gameObject.GetComponent<BoxCollider>();
    }
    protected virtual void LoadDLCheckController()
    {
        if(this.dL_CheckController != null) return;
        this.dL_CheckController = gameObject.GetComponentInParent<DL_CheckController>();
    }
     protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }
}