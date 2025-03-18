    using UnityEngine;

    public class EnemyMovementO : EnemyMovement
    {
        protected bool isCanMove;
    protected override void Start()
    {
        base.Start();
        this.isCanMove = false;
    }

    protected override void Update()
        {
            base.Update();
            this.EnemyFollowTarget();
            this.EnemyFollwTargetChicken();
            this.EnemyFollowRoom1();
        }
        protected virtual void EnemyFollowTarget()
        {
            if(enemyController.PianoController._notificationPiano.IsNotification)
            {
                objectPos = objectPosTrigger;
                this.MoveTowardsPlayer();        
            }        
        }

        protected virtual void EnemyFollwTargetChicken()
        {
            
            if(notification.IsNotification)
            {
                if(!this.isCanMove)
                {
                    objectPos = objectPosTriggerChicken;
                    this.MoveTowardsPlayer();
                    this.isCanMove = true;
                }
                
            }
        }

        protected virtual void EnemyFollowRoom1()
        {
            if(dL_Notifition.Notifition)
            {
                objectPos = objectPosTrigger;
                this.MoveTowardsPlayer(); 
            }
        }
    }