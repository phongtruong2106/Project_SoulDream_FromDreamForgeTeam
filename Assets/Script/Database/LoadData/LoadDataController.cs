using UnityEngine;

public class LoadDataController : NewMonoBehaviour
{
    [SerializeField] protected LoadPuzzel loadPuzzel;
    public LoadPuzzel _LoadPuzzel => loadPuzzel;    
    [SerializeField] protected LoadDoor loadDoor;
    public LoadDoor _LoadDoor => loadDoor;
    [SerializeField] protected LoadCutScene loadCutScene;
    [SerializeField] protected LoadDialogueData loadDialogue;
    public LoadDialogueData _LoadDialogue => loadDialogue;
    [SerializeField] protected LoadDataLanguage loadDataLanguage;
    public LoadDataLanguage _LoadDataLanguage => loadDataLanguage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPuzzel();
        this.LoadDoor();
        this.LoadCutScenes();
        this.LoadDialogue();
        this.loadLanguage();
    }

    private void LoadDialogue()
    {
        if(this.loadDialogue != null) return;
        this.loadDialogue = gameObject.GetComponentInChildren<LoadDialogueData>();
    }
     private void loadLanguage()
    {
        if(this.loadDataLanguage != null) return;
        this.loadDataLanguage  = gameObject.GetComponentInChildren<LoadDataLanguage>();
    }
    protected virtual void LoadPuzzel()
    {
        if(this.loadPuzzel != null) return;
        this.loadPuzzel = gameObject.GetComponentInChildren<LoadPuzzel>();
    }
    protected virtual void LoadDoor()
    {
        if(this.loadDoor != null) return;
        this.loadDoor = gameObject.GetComponentInChildren<LoadDoor>();
    }
    protected virtual void LoadCutScenes()
    {
        if(this.loadCutScene != null) return;
        this.loadCutScene = gameObject.GetComponentInChildren<LoadCutScene>();
    }
 
}