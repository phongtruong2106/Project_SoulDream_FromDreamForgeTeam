using System.Collections;
using UnityEngine;

public class CheckEnemySitDown : NewMonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected GameObject objEnemy;
    [SerializeField] protected GameObject objEnemySit;
    protected int StopSpeed = 0;
    public bool isSitDown;
    public bool isStop;
    public bool isFLPosSitDown;
    

    protected virtual void Update()
    {
        this.isSitDownEnemy();
        this.ChangeSpeed();
    }
    protected void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isSitDown = true;
        }
    }
    protected void OnTriggerExit(Collider collider)
    {
       if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isSitDown = false;
        } 
    }

    protected virtual void isSitDownEnemy()
    {
        if(isSitDown)
        {
            enemyController._animator.SetFloat("IsMove", 0);
            enemyController._checkEnemyMovement.isEnemyStun = false;
            objEnemy.transform.rotation = Quaternion.Euler(0, 172.443f, 0);
            Vector3 newPos = objEnemy.transform.position;
            newPos.z = -4.43f;
            objEnemy.transform.position = newPos;
            this.isStop = true;
        }
    }
    private IEnumerator StopMoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.isFLPosSitDown = true;
        StopMove();
    }
    protected virtual void ChangeSpeed()
    {
        if(isStop)
        {
            StartCoroutine(StopMoveAfterDelay(10f));
        }
    }

    protected virtual void StopMove()
    {
        this.enemyController.Agent.speed = this.StopSpeed;
        this.isFLPosSitDown = false;
        objEnemySit.gameObject.SetActive(false);
        this.isSitDown = false;
        this.isStop = false;
    }
}