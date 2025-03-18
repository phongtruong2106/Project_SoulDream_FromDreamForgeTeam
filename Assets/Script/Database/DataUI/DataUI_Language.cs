using System.IO;
using UnityEngine;

public class DataUI_Language : DataUI
{
    private bool previousIsChoiceEN;
    private bool previousIsChoiceVN;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.FileSave = "LanguageData.json";
        this.dataSaveManager._LangueDataNew.isEN = true;
        this.dataSaveManager._LangueDataNew.isVN = false;

        previousIsChoiceEN = this.dataSaveManager._LangueDataNew.isEN;
        previousIsChoiceVN = this.dataSaveManager._LangueDataNew.isVN;
    }

    protected override void Update()
    {
        base.Update();
        this.SaveData();
    }

    protected override void SaveData()
    {
        base.SaveData();

        bool currentIsChoiceEN = this.dataManager._ui_Option_Setting._UI_Btn_Setting_Selected._uI_Btn_Setting_LanguageOption.previousIsEN;
        bool currentIsChoiceVN = this.dataManager._ui_Option_Setting._UI_Btn_Setting_Selected._uI_Btn_Setting_LanguageOption.previousIsVN;
        if (currentIsChoiceEN != previousIsChoiceEN || currentIsChoiceVN != previousIsChoiceVN)
        {
            LanguageData languageData = new LanguageData
            {
                isEN = currentIsChoiceEN,
                isVN = currentIsChoiceVN,
            };
            string json = JsonUtility.ToJson(languageData, true);
            File.WriteAllText(filePath, json);

            Debug.Log($"Language data saved to {filePath}: {json}");
            isDataSaved = true;
            previousIsChoiceEN = currentIsChoiceEN;
            previousIsChoiceVN = currentIsChoiceVN;
        }
    }

}