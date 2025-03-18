using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDie : NewMonoBehaviour
{
   [SerializeField] protected PlayerControler playerControler;
    public bool isAttackEnemy_1;
    public bool isAttackEnemy_2;
    public bool isPlayerDie;

    private void Update() {
        this.IsAttack1();
        this.IsAttack2();
        this.IsDie();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(playerControler != null) return;
        playerControler = FindAnyObjectByType<PlayerControler>();
    }

    protected virtual void IsAttack1()
    {
        if(this.isAttackEnemy_1)
        {
            this.playerControler._animator.SetTrigger("isAttack1");
            this.isPlayerDie = true;
        }
    }
    protected virtual void IsAttack2()
    {
        if(this.isAttackEnemy_2)
        {
            this.playerControler._animator.SetTrigger("isAttack2");
            this.isPlayerDie = true;
        }
    }

    protected virtual void IsDie()
    {
        if(this.isAttackEnemy_1 || this.isAttackEnemy_2)
        { 
            if(this.playerControler._characterController != null)
            {
                this.playerControler._characterController.enabled = false;
            }
            
        }
    }
}
