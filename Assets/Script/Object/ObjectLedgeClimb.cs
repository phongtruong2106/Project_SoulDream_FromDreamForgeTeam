using System.Collections;
using UnityEngine;

public class ObjectLedgeClimb : NewMonoBehaviour 
{
    
    [Header("ObjectLedgeClimb")]
    [SerializeField] protected Transform targetPointBegun;
    [SerializeField] protected Transform targetPointOver;
    [SerializeField] protected Animator animator;
    [SerializeField] protected PlayerControler playerControler;
    private bool canClimbLedge = false;
    private bool canGrabLedge = true;
    private Vector3 TargetPoint1;
    private Vector3 TargetPoint2;
    [HideInInspector] public bool ledgeDetected;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }
    private void Update() {
        CheckForLedge();
        AnimationController();
     
    }
    private void CheckForLedge()
    {
        if(ledgeDetected && canGrabLedge)
        {
            canGrabLedge = false;
            canClimbLedge = true;
            TargetPoint1 = new Vector3(targetPointBegun.position.x, targetPointBegun.position.y, targetPointBegun.position.z);
            TargetPoint2 = new Vector3(targetPointOver.position.x, targetPointOver.position.y, targetPointOver.position.z);
            PlayerControler.instance._objectMovement.isMove = false;
        }

        if(canClimbLedge)
        {
            gameObject.transform.parent.position = TargetPoint1;
            playerControler._objectMoveFoward._characterController.enabled = false;
            PlayerControler.instance._objectMovement.isMove = false;
            animator.applyRootMotion = false;
        }
    }

    public void LedgeClimbOver()
    {
        canClimbLedge = false;
        gameObject.transform.parent.position = TargetPoint2;
        ledgeDetected = false;  
        PlayerControler.instance._objectMovement.isMove = true;
        playerControler._objectMoveFoward._characterController.enabled = true;
        animator.applyRootMotion = true;
        animator.SetBool("isClimbLedge", canClimbLedge);
        Invoke("AllowLedgeGrab", 0.1f);
    }
    protected virtual void AnimationController()
    {
        animator.SetBool("isClimbLedge", canClimbLedge);
    }
    private void AllowLedgeGrab() => canGrabLedge = true;

}