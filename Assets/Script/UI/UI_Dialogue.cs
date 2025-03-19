using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Dialogue : NewMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text_NameChar;
    [SerializeField] protected TextMeshProUGUI text_Dialogue;
    [SerializeField] protected GameObject obj_Dialogue;
    private Coroutine dialogueCoroutine;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();
    private bool isDialogueRunning = false;

    public event Action DialogueEnded;
    //public event Action<GameObject> InteractionTriggered;

    protected override void Start()
    {
        base.Start();
        this.ShowDialogue("", "");
    }    
    protected virtual IEnumerator DisplayDialogue(Dialogue dialogue)
    {
        isDialogueRunning = true;

        text_NameChar.text = dialogue.characterName;
        text_NameChar.gameObject.SetActive(true);

        text_Dialogue.text = dialogue.dialogue;
        text_Dialogue.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);

        text_Dialogue.gameObject.SetActive(false);
        text_NameChar.gameObject.SetActive(false);
        isDialogueRunning = false;

        yield return new WaitForSeconds(1f);

        StartNextDialogue();
        if (dialogueQueue.Count == 0 && DialogueEnded != null)
        {
            DialogueEnded();
        }
    }

    public void ShowDialogue(string name, string dialogue)
    {
        Dialogue newDialogue = new Dialogue(name, dialogue);
        dialogueQueue.Enqueue(newDialogue);
        if (dialogueCoroutine == null)
        {
            StartNextDialogue();
        }
    }

    private void StartNextDialogue()
    {
        if (dialogueQueue.Count > 0)
        {
            Dialogue nextDialogue = dialogueQueue.Dequeue();
            dialogueCoroutine = StartCoroutine(DisplayDialogue(nextDialogue));
        }
        else
        {
            dialogueCoroutine = null;
        }
    }

    public void StopDialogue()
    {
        if (isDialogueRunning && dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
            isDialogueRunning = false;
        }
    }

    public void OpenObjectDialogue()
    {
        obj_Dialogue.gameObject.SetActive(true);
    }
    public void CloseObjectDialogue()
    {
        obj_Dialogue.gameObject.SetActive(false);
    }

}
