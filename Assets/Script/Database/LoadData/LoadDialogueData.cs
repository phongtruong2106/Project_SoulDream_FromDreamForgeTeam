using UnityEngine;

public class LoadDialogueData : LoadDataParent
{
    public bool Dialogue_1;
    public bool Dialogue_2;

     protected override void Start()
    {
        base.Start();
        this.LoadDialogueDataFromDataManager();
    }
    protected virtual void LoadDialogueDataFromDataManager()
    {
        DialogueData dialogueData= this.dataManager._LoadData.LoadDialogueData();
        if(dialogueData != null)
        {
            this.Dialogue_1 = dialogueData.Dialogue_1;
            this.Dialogue_2 = dialogueData.Dialogue_2;
             Debug.Log("Puzzel data loaded into LoadDialogue.");
        }
    }
}