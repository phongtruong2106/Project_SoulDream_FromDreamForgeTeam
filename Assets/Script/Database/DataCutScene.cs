using System.IO;
using UnityEngine;

public class DataCutScene : DataSave, ICutScenesData
{
    //Chap 1
    public bool CutScene1{ get; set; }
    public bool CutScene2{ get; set; }
    public bool CutScene3{ get; set; }

    protected override void Update()
    {
        this.SavePuzzelData();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.FileSave = "GameDataCutScenes.json";
        this.CutScene1 = false;
        this.CutScene2 = false;
        this.CutScene3 = false;
    }

  protected void SavePuzzelData()
    {
        if (isDataSaved) return;

        if (this.dataController._dataCheckArea.isPlayer)
        {
            // Tạo đối tượng dữ liệu puzzle để chứa các trạng thái
            CutSceneData Data = new CutSceneData
            {
                CutScene1 = this.CutScene1,
                CutScene2 = this.CutScene2,
                CutScene3 = this.CutScene3,
            };
            string json = JsonUtility.ToJson(Data, true);
            File.WriteAllText(filePath, json);
            Debug.Log($"Puzzel data saved to {filePath}: {json}");
            isDataSaved = true;
        }
    }
    
}