using UnityEngine;

public class PZ_BookCase : NewMonoBehaviour
{
    [SerializeField] protected Animator animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = gameObject.GetComponent<Animator>();
    }


    protected virtual void OnMouseDown()
    {
        this.animator.SetTrigger("Open");
       
    }
}