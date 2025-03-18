using UnityEngine;

public class EnemyEventAnimation : Enemy
{
    public bool _isPlayer = false;

    public void CheckEnemyAttackToPlayer()
    {
        enemyController._enemyCheckPlayer._isPlayer = false;
    }
    
    public void EventCameraShake()
    {
        StartCoroutine(enemyController._cameraShake.Shake(0.01f, 0.001f, 20f));
    }

    public virtual void EventMovement()
    {
        enemyController._checkEnemyMovement.isEnemyStun = true;
    }
    public virtual void EventMovementp1()
    {
        enemyController._CheckEnemyMovement_1.isEnemyStun = true;
    }

    public void SFX_StepFoot()
    {
        enemyController._SoundEnemyController._StepFootEnemy.sfx_StepFootEnemy1();
    }

    public void SFX_StepFoot1()
    {
        enemyController._SoundEnemyController._StepFootEnemy.sfx_StepFootEnmey2();
    }
    public void SFX_Atk()
    {
        enemyController._SoundEnemyController._SFX_AttackEnemy.sfx_AtkEnemy1();
    }

}