using System.IO;
using UnityEngine;

public class DataPosition : DataSave
{

    protected override void Update()
    {
        this.SaveData();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.FileSave = "GameDataPosition.json";
    }

    protected override void SaveData()
    {
        if (dataController._playerControler == null) return;
        if (this.dataController._dataCheckArea.isPlayer)
        {
            Vector3 position = dataController._playerControler.transform.position;
            PositionData positionData = new PositionData(position);
            string json = JsonUtility.ToJson(positionData, true);
            File.WriteAllText(this.filePath, json);
            Debug.Log($"Position data saved to {filePath}: {json}");
            isDataSaved = true;
        }
    }
}
