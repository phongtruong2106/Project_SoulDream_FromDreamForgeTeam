using UnityEngine;

public class CheckEnemyDialogueChicken : CheckEnemyDialogue
{
    protected bool isCanTalk;
    [SerializeField] protected Notification notification;
    [SerializeField]  protected bool isTalk;
    protected override void Start()
    {
        base.Start();
        this.isCanTalk = false;
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.IsNoice();
        this.CheckIsTalk();
        this.CheckEndTalk();
    }

    protected override void IsNoice()
    {
        if(this.notification.IsNotification)
        {
            this.isTalk = true;
        }

    }
    
    protected override void CheckIsTalk()
    {
        if(this.isTalk)
        {
            if(!this.isCanTalk)
            {
                this.dialogueNew.OpenDialogueP(this.sO_Dialogue.inkJson);
                // this.dialogueManager.isCheckEndTalk = false;
                this.isTalk = false;
                this.notification.IsNotification = false; 
                this.isCanTalk = true;  
            }
        }
    }

    protected override void CheckEndTalk()
    {
        if(this.dialogueManager.isCheckEndTalk)
        {
            
            this.notification.IsNotification = false;
        }
    }
    
}