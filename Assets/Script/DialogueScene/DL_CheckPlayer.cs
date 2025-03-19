using System.Collections;
using UnityEngine;

public class DL_CheckPlayer : DL_Check
{
    [SerializeField] protected NotificationPiano notificationPiano;
    [SerializeField]  protected bool isTalk = false;
    [SerializeField] protected bool isDL = false;
    [SerializeField] protected bool isEndTalk = false;
    
    [SerializeField] protected LoadDataController loadDataController;
    private bool isCanTalk;
    private bool isBoolChange;
    private bool IsDialogue ;
    protected override void Start()
    {
        base.Start();
        this.isBoolChange = false;
        this.isCanTalk = false;
    }

    protected override void Update()
    {
        base.Update();
            this.ChangeBool();
            this.EndTalk();
        
    }
    protected void FixedUpdate()
    {
        this.Talk();
        this.ChangeIsTalk();
        this.PlayDialogue();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNotificationPiano();
        this.LoadDataController();
    }
    private void LoadDataController()
    {
        if(this.loadDataController != null) return;
        this.loadDataController = FindAnyObjectByType<LoadDataController>();
    }
    protected virtual void LoadNotificationPiano()
    {
        if(this.notificationPiano != null) return;
        this.notificationPiano = FindAnyObjectByType<NotificationPiano>();
    }

    protected void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.isTalk = true;
        }
    }
    protected void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.isTalk = false;
        }
    }

    protected virtual void Talk()
    {
        if(this.isTalk)
        {
            this.dL_CheckController._DL_CheckPlayerUNHide.gameObject.SetActive(false);
            if(Input.GetKeyDown(KeyCode.F))
            {
                this.isDL = true;
                this.isEndTalk = false;
                Vector3 newCenter = boxCollider.center;
                newCenter.y = 4f;
                boxCollider.center = newCenter;
            }
        }
        else
        {
            this.isDL = false;
        }
        
    }

    protected virtual void PlayDialogue()
    {
        if(this.isDL)
        {
            if(!this.isCanTalk)
            {
                this.uIController._dialogueNew.OpenDialogueP(sO_Dialogue.inkJson);
                this.playerControler._objectMoveFoward.isInput = false;
                StartCoroutine(ResetNotificationPianoAfterDelay(25f));
                this.isCanTalk = true;
            }
            
        }
    }
    protected virtual void ChangeIsTalk()
    {
        if(DialogueManagerNew.Instance.isCheckEndTalk)
        {
            this.isTalk = false;
            this.isEndTalk = true;
        }
    }
    protected virtual void EndTalk()
    {
        if(this.isEndTalk)
        {
            this.dL_CheckController._DL_Notification.Notifition = false;
            this.playerControler._objectMoveFoward.isInput = true;
        }
    }
    private void ChangeBool()
    {
        if(!this.isBoolChange)
        {
            this.IsDialogue = this.loadDataController._LoadDialogue.Dialogue_1;
            this.isBoolChange = true;
        }
    }
 
    private IEnumerator ResetNotificationPianoAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.dL_CheckController._DL_Notification.Notifition = true;
    }
    
}