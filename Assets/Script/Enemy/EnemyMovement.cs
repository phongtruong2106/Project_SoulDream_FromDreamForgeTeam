using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : Enemy
{
    public Transform objectPos;
    [SerializeField] protected float detectionRadius;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Vector3 movePositon;
    [SerializeField] protected Transform objectPosDefault;
    [SerializeField] protected Transform objectPosTrigger;
    [SerializeField] protected Transform objectPosTriggerChicken;
    [SerializeField] protected Notification notification;
    [SerializeField] protected DL_Notifition dL_Notifition;
    protected bool isCheckTarget;
    public bool isMove = true;
    protected int DefaultSpeed = 3;
    protected int StopSpeed = 0;
    

    protected override void Start()
    {
        base.Start();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDLNotification();
    }

    protected override void Update() {
        this.CheckPlayerInArea();
    }

    protected virtual void LoadDLNotification()
    {
        if(this.dL_Notifition != null) return;
        this.dL_Notifition = FindAnyObjectByType<DL_Notifition>();
    }
    protected virtual void CheckPlayerInArea()
    {
        if(enemyController._enemy._objectCheckPlayer._isPlayer)
        {
            this.MoveTowardsPlayer();
            objectPos = objectPosDefault;
        }
    }
    public virtual void MoveTowardsPlayer()
    {
        if(this.isMove)
        {
            enemyController.Agent.speed = this.DefaultSpeed;
            Vector3 directionToPlayer = objectPos.position - transform.position;
            Vector3 targetPosition = objectPos.position - directionToPlayer.normalized * detectionRadius;
            enemyController.Agent.SetDestination(targetPosition);
            movePositon = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.position.z);
            float inputMagnitude = Mathf.Clamp01(movePositon.magnitude);
            animator.SetFloat("IsMove", inputMagnitude);
        }
    }
    
}
