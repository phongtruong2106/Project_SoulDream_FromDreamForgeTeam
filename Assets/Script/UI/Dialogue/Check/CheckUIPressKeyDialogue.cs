using UnityEngine;

public class CheckUIPressKeyDialogue : NewMonoBehaviour
{
    protected UI_PressButton uI_PressButton;
    [SerializeField] protected string textBox;
    protected UIController uIController;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }
     protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(true);
            Following();
            uIController._uI_PressButton._text_ObjPress.text = textBox;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(false);
        }
    }
    protected virtual void Following()
    {
        if(this.target == null) return;
        this.uIController._uIGameObject.UI_PressButtonObj.gameObject.transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
}