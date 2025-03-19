using UnityEngine;

public class EnemyAttack :Enemy
{
    public bool attackedPlayer;
    protected override void Update()
    {
        this.Attack();
        this.AnimationAttack();
        this.IsPlayerDie();
    }

    protected virtual void Attack()
    {
        if(enemyController._enemyCheckPlayer._isPlayer)
        {
            this.attackedPlayer = true;
        }
        else
        {
            this.attackedPlayer = false;
        }
    }

    protected virtual void AnimationAttack()
    {
        if(this.attackedPlayer) 
        {
            enemyController._animator.SetBool("Attack", true);
            enemyController._enemyMovement.isMove = false;
        }
        else
        {
            enemyController._animator.SetBool("Attack", false);
            enemyController._enemyMovement.isMove = true;
        }
    }

    protected virtual void IsPlayerDie()
    {
        if(this.playerControler._objectDie.isPlayerDie)
        {
            enemyController._enemyMovement.isMove = false;
            enemyController._animator.SetTrigger("IsKillPlayer");
        }
        
    }
    
}