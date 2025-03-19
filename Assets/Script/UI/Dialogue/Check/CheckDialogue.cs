using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialogue : NewMonoBehaviour
{
    [SerializeField] protected GameObject objectDialogue;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] protected DialogueManager dialogueManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDialogueManager();
    }

    protected virtual void LoadDialogueManager()
    {
        if(this.dialogueManager != null) return;
        this.dialogueManager = FindAnyObjectByType<DialogueManager>();
    }

    protected virtual void OnTriggerEnter(Collider collision)
   {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            
            dialogueManager.dialoguePanel = this.objectDialogue;
        }
   }

}
