using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimationEvent : Enemy
{

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    protected virtual void EventEnemyDontPickUp()
    {
        if(!this.enemyController._enemyCheckTouchPlayer._isTouch)
        {
            enemyController._enemyCheckPlayer._isPlayer = false;
        }
    }

    protected virtual void EventMovement()
    {
        enemyController._checkEnemyMovement.isEnemyStun = true;
    }
}
