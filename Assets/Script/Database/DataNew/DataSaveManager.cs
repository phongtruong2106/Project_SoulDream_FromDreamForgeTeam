using Unity.VisualScripting;
using UnityEngine;

public class DataSaveManager : NewMonoBehaviour
{
    [SerializeField] protected PuzzelDataNew puzzelDataNew;
    public PuzzelDataNew _PuzzelDataNew => puzzelDataNew;
    [SerializeField] protected DoorDataNew doorDataNew;
    public DoorDataNew _DoorDataNew => doorDataNew;
    [SerializeField] protected ScenesDataNew scenesDataNew;
    public ScenesDataNew _ScenesDataNew => scenesDataNew;
    [SerializeField] protected DialogueDataNew dialogueDataNew;
    public DialogueDataNew _DialogueDataNew => dialogueDataNew;
    [SerializeField] protected CutScenesDataNew cutScenesDataNew;
    public CutScenesDataNew _CutScenesDataNew => cutScenesDataNew;
    [SerializeField] protected LangueDataNew langueDataNew;
    public LangueDataNew _LangueDataNew => langueDataNew;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPuzzelDataNew();
        this.LoadDoorDataNew();
        this.LoadSceneSDataNew();
        this.LoadCutSceneDataNew();
        this.LoadDialogueDataNew();
        this.LoadLanguageDataNew();
    }

    private void LoadLanguageDataNew()
    {
        if(this.langueDataNew != null) return;
        this.langueDataNew = gameObject.GetComponentInChildren<LangueDataNew>();
    }
    private void LoadDoorDataNew()
    {
        if(this.doorDataNew != null) return;
        this.doorDataNew = gameObject.GetComponentInChildren<DoorDataNew>();
    }
    private void LoadSceneSDataNew()
    {
        if(this.scenesDataNew != null) return;
        this.scenesDataNew = gameObject.GetComponentInChildren<ScenesDataNew>();
    }
    private void LoadCutSceneDataNew()
    {
        if(this.cutScenesDataNew != null) return;
        this.cutScenesDataNew = gameObject.GetComponentInChildren<CutScenesDataNew>();
    }
    private void LoadDialogueDataNew()
    {
        if(this.dialogueDataNew != null) return;
        this.dialogueDataNew = gameObject.GetComponentInChildren<DialogueDataNew>();
    }
    private void LoadPuzzelDataNew()
    {
        if(this.puzzelDataNew != null) return;
        this.puzzelDataNew = gameObject.GetComponentInChildren<PuzzelDataNew>();
    }
}