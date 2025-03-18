using System.IO;
using UnityEngine;

public class DataDoor : DataSave, IDoorData
{
    public bool Door1 { get; set;}
    public bool Door2 {get; set;}

    protected override void Update()
    {
        this.SavePuzzelData();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.FileSave = "GameDataDoor.json";
    }

    public void SavePuzzelData()
    {
        if (isDataSaved) return;

        if (this.dataController._dataCheckArea.isPlayer)
        {   
            DoorData doorData = new DoorData
            {
                Door1 = this.dataSaveManager._DoorDataNew.IsDoor1,
                Door2 = this.dataSaveManager._DoorDataNew.IsDoor2   
            };
            string json = JsonUtility.ToJson(doorData, true);
            File.WriteAllText(filePath, json);

            Debug.Log($"Puzzel data saved to {filePath}: {json}");
            isDataSaved = true;
        }
    }

}