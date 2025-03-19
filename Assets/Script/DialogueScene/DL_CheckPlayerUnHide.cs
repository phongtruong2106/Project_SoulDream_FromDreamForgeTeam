using UnityEngine;

public class DL_CheckPlayerUnHide : DL_Check
{
    [SerializeField]   protected bool isTalk;
    private bool isCanShow;
    private bool isCanTalk ;
    protected override void Start()
    {
        base.Start();
        this.isCanTalk = false ;
        this.isCanShow = false ;
    }
    protected override void Update()
    {
        base.Update();
        this.Talk();
        this.ChangeIsTalk();
        this.HideCheckDialogue();
    }
    protected void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.dL_CheckController._DL_CheckPlayer.gameObject.SetActive(true);
            this.isTalk = true;
        }
    }
    protected virtual void OnTriggerExit(Collider collider)
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
            if(!this.isCanTalk)
            {
                this.dL_CheckController._DL_CheckPlayer.gameObject.SetActive(true);
                this.uIController._dialogueNew.OpenDialogueP(sO_Dialogue.inkJson);
                Vector3 newCenter = boxCollider.center;
                newCenter.y = 4f;
                boxCollider.center = newCenter;
                this.isCanTalk = true;
            }
            
        }
    }

    protected virtual void ChangeIsTalk()
    {
        if(DialogueManagerNew.Instance.isCheckEndTalk)
        {
            this.isTalk = false;
        }
    }

    private void HideCheckDialogue()
    {
        if(dL_CheckController._loadDataController._LoadDoor.Door1)
        {
            if(!isCanShow)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}