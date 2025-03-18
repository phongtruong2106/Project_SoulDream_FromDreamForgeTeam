using UnityEngine;

public class DialogueNew : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJson;
    
    public virtual void OpenDialogue()
    {
        DialogueManagerNew.Instance.EnterDialogueMode(inkJson);
    }

    public virtual void OpenDialogueP(TextAsset textAsset)
    {
        DialogueManagerNew.Instance.InterruptDialogue(textAsset);
    }
}