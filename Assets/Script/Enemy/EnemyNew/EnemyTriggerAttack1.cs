using UnityEngine;

public class EnemyTriggerAttack1 : EnemyTrigger
{
    protected bool isPlayer;
    [SerializeField] protected GameObject objectHand;
    [SerializeField] protected GameObject playerObj;
    protected override void Update()
    {
        base.Update();
        this.IsPlayer();
    }
    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))       
        {
            isPlayer = true;
        } 
        else
        {
            isPlayer = false;
        }
    }
    
    protected virtual void IsPlayer()
    {
        if(this.isPlayer)
        {
            this.playerControler._objectDie.isAttackEnemy_2 = true;
            this.PickUpPlayer();
        }
    }
    protected virtual void PickUpPlayer()
    {
        Vector3 handPosition = objectHand.transform.position;
        playerObj.transform.position = handPosition;
        Vector3 offset = playerObj.transform.position - handPosition;
        float yOffset = 1.0f;
        offset.y -= yOffset;
        playerObj.transform.position += offset;
    }
}