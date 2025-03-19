using TMPro;
using UnityEngine;

public class UIController : NewMonoBehaviour
{
    [SerializeField] protected UI_Dialogue uI_Dialogue;
    public UI_Dialogue _uI_Dialogue => uI_Dialogue;
    [SerializeField] protected UI_PressButton uI_PressButton;
    public UI_PressButton _uI_PressButton => uI_PressButton;
    [SerializeField] protected UI_KeyHolder uI_KeyHolder;
    public UI_KeyHolder _uI_KeyHolder => uI_KeyHolder;
    [SerializeField] protected DialogueNew dialogueNew;
    public DialogueNew _dialogueNew => dialogueNew;
    [SerializeField] protected UIGame uIGame;
    public UIGame _uIGame => uIGame;
    [SerializeField] protected UIGameObject uIGameObject;
    public UIGameObject _uIGameObject => uIGameObject;
    [SerializeField] protected UI_PressButtonItem uI_PressButtonItem;
    public UI_PressButtonItem _uI_PressButtonItem => uI_PressButtonItem;
    
    [SerializeField] protected UI_PZ_Mouse uI_PZ_Mouse;
    public UI_PZ_Mouse _ui_PZ_Mouse => uI_PZ_Mouse;
    [SerializeField] protected UICutScenes uICutScenes;
    public UICutScenes _uiCutScenes => uICutScenes; 
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIDialogue();
        this.LoadUIPressButton();
        this.LoadUIKeyHolder();
        this.LoadDialogueNew();
        this.LoadUIGame();
        this.LoadUIGameObject();
        this.LoadUIPressButtonItem();
        this.LoadUIPZMouse();
        this.LoadUICutScenes();
    }

    protected virtual void LoadUICutScenes()
    {
        if(this.uICutScenes != null) return;
        this.uICutScenes = gameObject.GetComponentInChildren<UICutScenes>();    
    }
    protected virtual void LoadUIPZMouse()
    {
        if(this.uI_PZ_Mouse != null) return;
        this.uI_PZ_Mouse = gameObject.GetComponentInChildren<UI_PZ_Mouse>();
    }

    protected virtual void LoadUIGameObject()
    {
        if(this.uIGameObject != null) return;
        this.uIGameObject = FindAnyObjectByType<UIGameObject>();
    }

    protected virtual void LoadUIPressButtonItem()
    {
        if(this.uI_PressButtonItem != null) return;
        this.uI_PressButtonItem = GetComponentInChildren<UI_PressButtonItem>();
    }

    protected virtual void LoadUIDialogue()
    {
        if(this.uI_Dialogue != null) return;
        this.uI_Dialogue = GetComponentInChildren<UI_Dialogue>();
    }

    protected virtual void LoadUIPressButton()
    {
        if(this.uI_PressButton != null) return;
        this.uI_PressButton = GetComponentInChildren<UI_PressButton>();
    }

    protected virtual void LoadUIKeyHolder()
    {
        if(this._uI_KeyHolder != null) return;
        this.uI_KeyHolder = GetComponentInChildren<UI_KeyHolder>();
    }
    protected virtual void LoadDialogueNew()
    {
        if(this.dialogueNew != null) return;
        this.dialogueNew = GetComponentInChildren<DialogueNew>();
    }

    protected virtual void LoadUIGame()
    {
        if(this.uIGame != null) return;
        this.uIGame = GetComponentInChildren<UIGame>();
    }
    
}
