using System;
using UnityEngine;

public class ObjectClimbingStairs : NewMonoBehaviour
{
    [SerializeField] protected PlayerControler playerControler;
    [HideInInspector] public bool stairsDetected = false;

    private void Update() {
        this.CheckIsStairs();
        this.CheckIdlePose();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler  = FindAnyObjectByType<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }

    protected virtual void CheckIsStairs()
    {
        if(stairsDetected)
        {
            playerControler._animator.SetBool("IsStairs", true);
           // playerControler._animator.SetBool("isGround", false);
          //  playerControler._animator.SetBool("isJumping", false);
        }
        else
        {
            playerControler._animator.SetBool("IsStairs", false);
           // playerControler._animator.SetBool("isJumping", false);
        }
    }

    protected virtual void CheckIdlePose()
    {

        if(playerControler._objectMovement._moveX == 0 || playerControler._objectMovement._moveZ == 0)
        {
            playerControler._animator.SetBool("IsStairs", false);
        }
    }
}