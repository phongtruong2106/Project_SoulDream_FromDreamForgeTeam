using System.IO;
using UnityEngine;

public class DataDialogue : DataSave, IDialogueData
{
    public bool Dialogue_1 {get; set;}
    public bool Dialogue_2 {get; set;}

    protected override void Update()
    {
        this.SaveData();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
         this.FileSave = "GameDataDialogue.json";
         this.Dialogue_1 = false;
         this.Dialogue_2 = false;
    }

    protected override void SaveData()
    {
        if(isDataSaved) return;

        if(this.dataController._dataCheckArea.isPlayer)
        {
            DialogueData dialogueData = new DialogueData
            {
                Dialogue_1 = this.Dialogue_1,
                Dialogue_2 = this.Dialogue_2,
            };
            string json = JsonUtility.ToJson(dialogueData, true);
            File.WriteAllText(filePath, json);
            Debug.Log($"Dialogue data saved to {filePath}: {json}");
            isDataSaved = true;
        }
    }
}