using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyMovement_1 : NewMonoBehaviour
{
    [SerializeField]  protected EnemyController enemyController;
    [SerializeField] protected Transform objPosConfirm;
    [SerializeField] protected GameObject objectCheckSitDown;
    [SerializeField] protected GameObject objectCheckEnemy;
    [SerializeField] protected GameObject objectCheckEnemyNext;
    public Transform ObjPosConfirm => objPosConfirm;
    public bool isCheck = false;
    public bool isEnemyStun = false;
    private Coroutine stunCoroutine;

    protected override void Start()
    {
        if(objectCheckSitDown != null)
        {
            objectCheckSitDown.SetActive(false);
        }
    }

    protected void Update()
    {
        this.CheckEnemy();
        this.ChangeStateMovent();
    }

    protected void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isCheck = true;
            //enemyController._enemyLookedPlayer.viewAngle = 62.3f;
            
        }
    }

    protected virtual void CheckEnemy()
    {
        if(isCheck)
        {
            enemyController.PianoController._notificationPiano.IsNotification = false;
            if (stunCoroutine == null)
            {
                stunCoroutine = StartCoroutine(StartStunTimer(0f));
            }
        }
    }
    protected virtual void ChangeStateMovent()
    {
        if(isEnemyStun)
        {
            this.StopStunAnimation();
            enemyController._enemyMovement.objectPos = objPosConfirm;
            enemyController._enemyMovement.MoveTowardsPlayer();
            if(this.objectCheckSitDown != null)
            {
                this.objectCheckSitDown.SetActive(true);
            }
            
            this.objectCheckEnemyNext.SetActive(true);
            this.objectCheckEnemy.SetActive(false);
            this.isEnemyStun = false;
        }
    }

    private IEnumerator StartStunTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        StunAnimation();
        isCheck = false;
        stunCoroutine = null;
    }
    protected virtual void StunAnimation()
    {
        enemyController._animator.SetBool("IsStun", true);
    }
    protected virtual void StopStunAnimation()
    {
        enemyController._animator.SetBool("IsStun", false);
    }
}