using Unity.VisualScripting;
using UnityEngine;

public class PZ_ItemTypeNew : NewMonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] protected SO_Dialogue sO_Dialogue;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected string Text;
    public GameObject uiElement;
    [SerializeField] protected PuzzelNew puzzelNew;
    public PuzzelNew _puzzelNew => puzzelNew;
     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();

    }
    protected virtual void LoadUIController()
    {
        if(this.uIController!= null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }

    public ItemType GetKeyType()
    {
        return itemType;
    }

    public void PZDialogue()
    {
        uIController._dialogueNew.OpenDialogueP(sO_Dialogue.inkJson);
    }
    
    public void PZShowUI()
    {
        uiElement.SetActive(true);
        this.uIController._ui_PZ_Mouse._text_Mouse.text = this.Text;
    }

}