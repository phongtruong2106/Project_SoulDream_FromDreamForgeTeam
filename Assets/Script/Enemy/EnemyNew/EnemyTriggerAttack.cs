using UnityEngine;

public class EnemyTriggerAttack : EnemyTrigger
{
    public bool _isPlayer = false;
    
    protected override void Update()
    {
        base.Update();
        this.IsPlayer();
    }
    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))       
        {
            _isPlayer = true;
        } 
        else
        {
            _isPlayer = false;
        }
    }
    
    protected virtual void IsPlayer()
    {
        if(this._isPlayer)
        {
            this.playerControler._objectDie.isAttackEnemy_1 = true;
        }
    }
   
   
}