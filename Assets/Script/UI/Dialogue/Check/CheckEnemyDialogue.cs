using UnityEngine;

public class CheckEnemyDialogue : NewMonoBehaviour
{
    [SerializeField] protected SO_Dialogue sO_Dialogue;
    [SerializeField] protected DialogueNew dialogueNew;
    [SerializeField] protected DialogueManagerNew dialogueManager;
   // [SerializeField]  protected bool isTalk;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDialogueManager();
    }

    protected override void Start()
    {
        //this.isTalk = false;
    }

    protected virtual void FixedUpdate()
    {
        // this.IsNoice();
        // this.CheckIsTalk();
        // this.CheckEndTalk();
    }

    protected virtual void LoadDialogueManager()
    {
        if(this.dialogueManager != null) return;
            this.dialogueManager = FindAnyObjectByType<DialogueManagerNew>();
    }
    protected virtual void IsNoice()
    {
      

    }

    protected virtual void CheckIsTalk()
    {
    }

    protected virtual void CheckEndTalk()
    {
        
    }

}