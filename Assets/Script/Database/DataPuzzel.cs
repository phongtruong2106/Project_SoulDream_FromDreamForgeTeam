using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class DataPuzzel : DataSave
{
    protected override void Update()
    {
        this.SavePuzzelData();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.FileSave = "GameDataPuzzel.json";
        this.dataSaveManager._PuzzelDataNew.IsPuzzelClock = false;
        this.dataSaveManager._PuzzelDataNew.IsPuzzelEar = false;
        this.dataSaveManager._PuzzelDataNew.IsPuzzelClock = false;
        this.dataSaveManager._PuzzelDataNew.IsPuzzelPotSteam = false;
        this.dataSaveManager._PuzzelDataNew.IsPuzzelLockBox = false;
        this.dataSaveManager._PuzzelDataNew.IsPuzzelPiano = false;
    }

  protected void SavePuzzelData()
    {
        if (isDataSaved) return;

        if (this.dataController._dataCheckArea.isPlayer)
        {
            PuzzelData puzzelData = new PuzzelData
            {
                isPuzzelPiano = this.dataSaveManager._PuzzelDataNew.IsPuzzelPiano,
                isPuzzelLockBox = this.dataSaveManager._PuzzelDataNew.IsPuzzelLockBox,
                isWaterGlass = this.dataSaveManager._PuzzelDataNew.IsWaterGlass,
                isPuzzelPotSteam = this.dataSaveManager._PuzzelDataNew.IsPuzzelPotSteam,
                isPuzzelClock = this.dataSaveManager._PuzzelDataNew.IsPuzzelClock,
                isPuzzelEar = this.dataSaveManager._PuzzelDataNew.IsPuzzelEar
            };

            string json = JsonUtility.ToJson(puzzelData, true);
            File.WriteAllText(filePath, json);

            Debug.Log($"Puzzel data saved to {filePath}: {json}");
            isDataSaved = true;
        }
    }

}
