using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUIPressKey : NewMonoBehaviour
{
    protected UI_PressButton uI_PressButton;
    [SerializeField] protected string textBox;
    [SerializeField] protected ZoomPuzzel zoomPuzzel;
    protected UIController uIController;
    protected bool isZoom;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIPressButton();
        this.LoadUIController();
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }
    protected virtual void LoadUIPressButton()
    {
         if(this.uI_PressButton != null) return;
        this.uI_PressButton = FindAnyObjectByType<UI_PressButton>();
    }

    protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(true);
            Following();
            uI_PressButton._text_ObjPress.text = textBox;
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
