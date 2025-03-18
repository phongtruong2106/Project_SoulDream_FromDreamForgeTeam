using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickPlayer : Enemy
{
    [SerializeField] protected GameObject objectHand;
    [SerializeField] protected GameObject playerObj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override void Update() {
        this.AttackPlayer();
        this.PickUpPlayer();
    }

    protected virtual void AttackPlayer()
    {
        if(enemyController._enemyCheckPlayer._isPlayer)
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

    protected virtual void PickUpPlayer()
    {
        if(enemyController._enemyCheckTouchPlayer._isTouch)
        {
            this.playerControler._objectDie.isAttackEnemy_2 = true;
            Vector3 handPosition = objectHand.transform.position;
            playerObj.transform.position = handPosition;
            Vector3 offset = playerObj.transform.position - handPosition;
            float yOffset = 1.0f;
            offset.y -= yOffset;
            playerObj.transform.position += offset;
        }
    }
}
