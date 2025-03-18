using System;
using UnityEngine;

public class AnimationEvent : NewMonoBehaviour
{
    [SerializeField] protected PlayerControler playerControler;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerControler();
    }

    protected virtual void LoadPlayerControler()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerControler()", gameObject);
    }
    public void HandleLedgeClimbOver()
    {
       playerControler._objectLedgeClimb.LedgeClimbOver();
    }

    public void SFX_FootStep()
    {
        this.playerControler._playerSoundController._SFX_FootStep.sfx_FootStepWoodFloor();
    }

    public void SFX_FootStepRun()
    {
        this.playerControler._playerSoundController._SFX_FootStep.sfx_FootStepRunWoodFloor();
    }

    public void Change_CC()
    {
        // Vector3 newCenter = this.playerControler._characterController.center;
        // newCenter.y = 0f; // Chỉnh y mới
        // this.playerControler._characterController.center = newCenter; // Gán lại Vector3

    }
    public void SFX_Jump()
    {
        this.playerControler._playerSoundController._SFX_Jump.sfx_Jump();
    }
    public void ChangeDie()
    {
        playerControler._animator.SetTrigger("IsDie");
    }
}