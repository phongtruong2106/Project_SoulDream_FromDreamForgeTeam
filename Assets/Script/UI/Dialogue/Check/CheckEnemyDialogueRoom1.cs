using UnityEngine;

public class CheckEnemyDialogueRoom1 : CheckEnemyDialogue
{
    [SerializeField] protected NotificationPiano notificationPiano;
    [SerializeField]  protected bool isTalk;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.IsNoice();
        this.CheckIsTalk();
        this.CheckEndTalk();
    }
    protected override void IsNoice()
    {
        if(this.notificationPiano.IsNotification)
        {
            this.isTalk = true;
            
        }

    }

    protected override void CheckIsTalk()
    {
        if(this.isTalk)
        {
            this.dialogueNew.OpenDialogueP(this.sO_Dialogue.inkJson);
           // this.dialogueManager.isCheckEndTalk = false;
            this.notificationPiano.IsNotification = false;
            this.isTalk = false;
        }
    }

    protected override void CheckEndTalk()
    {
        if(this.dialogueManager.isCheckEndTalk)
        {
            this.notificationPiano.IsNotification  = false;
        }
    }
}