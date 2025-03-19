using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bt_NewGame : UI_BtnGame
{
     public Button _buttonNewGame => button;

    private string currentLanguage = "";

    protected override void Awake()
    {
        base.Awake();
        this.ChangeLanguage();
    }

    protected override void Start()
    {
       
        this.ChangeLanguage();
    }

    protected override void Update()
    {
        var languageSetting = this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting;
        string newLanguage = languageSetting.IsEN ? "EN" : "VN";

        if (newLanguage != currentLanguage)
        {
            currentLanguage = newLanguage;
            this.ChangeLanguage();
        }

        this.StartGame();
    }

    protected virtual void ChangeLanguage()
    {
        var languageSetting = this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting;

        if (languageSetting.IsEN)
        {
            this.text.text = "NewGame";
        }
        else if (languageSetting.IsVN)
        {
            this.text.text = "Bắt đầu";
        }
    }

    protected virtual void StartGame()
    {
        if (!isStartGameInitialized)
        {
            this.button.onClick.AddListener(Scenes);
            isStartGameInitialized = true;
        }
    }

    protected virtual void Scenes()
    {
        this.LoadDataSave();
        this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._NewGame.ResetData();
        this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._NewGame.LoadScene();
        this.uI_Option_MainMenu._uIControllerMainMenu._dataManager._LoadData.IsDataNull = true;
        this.isStartGameInitialized = false;
    }

    private void LoadDataSave()
    {
        foreach (var dataSave in sO_DataSaveList)
        {
            dataSave.IsCheck = false;
        }
    }
}
