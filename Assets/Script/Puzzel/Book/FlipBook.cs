using UnityEngine;

public class FlipBook : BookController
{
    protected int CountClick;
    [SerializeField] protected Animator animator;
    protected bool isClose;

    protected override void Start()
    {
        this.CountClick = 0;
        this.isClose = false;
    }

    private void Update()
    {
       this.FlipPage();
       this.IsClose();
       this.RePage();
//       Debug.Log(this.CountClick);
    }
    public virtual void ClickRightFlip()
    {
        if (this.CountClick < 9)
        {
            this.CountClick++;
        }

    }

    public virtual void ClickLeftFlip()
    {
        if(this.CountClick > 0)
        {
            this.CountClick--;
        }
        
    }
    protected virtual void IsClose()
    {
        if(!object_Interact.IsClickObj)
        {
            this.isClose = true;
        }
    }

    protected virtual void RePage()
    {
        if(this.isClose)
        {
            animator.SetTrigger("page0");
            this.isClose = false;
        }
    }

    protected virtual void FlipPage()
    {
       animator.SetTrigger("page" + CountClick);
    }
}