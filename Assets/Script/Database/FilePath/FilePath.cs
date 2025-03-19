using System.IO;
using UnityEngine;

public class FilePath : NewMonoBehaviour
{
    
    [SerializeField] protected string positionFilePath;
    [SerializeField] protected string sceneFilePath;
    [SerializeField] protected string puzzelFilePath;
    [SerializeField] protected string DoorFilePath;
    [SerializeField] protected string CutScenesFilePath;
    [SerializeField] protected string DialogueFilePath;
    [SerializeField] protected string LanguageFilePath;
    [SerializeField] protected string volumeFilePath;

    protected override void Start()
    {
        base.Start();
        string basePath = Application.persistentDataPath; 
        this.LanguageFilePath = Path.Combine(basePath, "LanguageData.json");
        this.positionFilePath = Path.Combine(basePath, "GameDataPosition.json");
        this.sceneFilePath = Path.Combine(basePath, "GameDataScenes.json");
        this.puzzelFilePath = Path.Combine(basePath, "GameDataPuzzel.json");
        this.DoorFilePath = Path.Combine(basePath, "GameDataDoor.json");
        this.CutScenesFilePath = Path.Combine(basePath, "GameDataCutScenes.json");
        this.DialogueFilePath = Path.Combine(basePath, "GameDataDialogue.json");
        this.volumeFilePath = Path.Combine(basePath, "GameDataVolume.json");
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        string basePath = Application.persistentDataPath; 
        this.LanguageFilePath = Path.Combine(basePath, "LanguageData.json");
        this.positionFilePath = Path.Combine(basePath, "GameDataPosition.json");
        this.sceneFilePath = Path.Combine(basePath, "GameDataScenes.json");
        this.puzzelFilePath = Path.Combine(basePath, "GameDataPuzzel.json");
        this.DoorFilePath = Path.Combine(basePath, "GameDataDoor.json");
        this.CutScenesFilePath = Path.Combine(basePath, "GameDataCutScenes.json");
        this.DialogueFilePath = Path.Combine(basePath, "GameDataDialogue.json");
        this.volumeFilePath = Path.Combine(basePath, "GameDataVolume.json");
    }
}