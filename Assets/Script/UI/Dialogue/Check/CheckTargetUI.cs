using UnityEngine;

public class CheckTargetUI : NewMonoBehaviour
{
    [SerializeField] protected UIController UIController;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }
    protected virtual void LoadUIController()
    {
        if(this.UIController != null) return;
        this.UIController = FindAnyObjectByType<UIController>();
    }

     protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Following();

        }
    }
    
     protected virtual void Following()
    {
        if(this.target == null) return;
        this.UIController._uIGameObject.UI_PressButtonObj.gameObject.transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
}