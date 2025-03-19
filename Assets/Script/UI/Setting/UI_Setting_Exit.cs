using UnityEngine;

public class UI_Setting_Exit : UI_BtnGame
{
    public bool IsSettingGameInitialized = false;

    protected override void Start()
    {
        base.Start();
        this.IsSettingGameInitialized = false;
    }

    protected override void Update()
    {
        base.Update();
        this.ChangeLanguage();
        this.PressBtn();
        
    }

    protected virtual void ChangeLanguage()
    {
        if(this.uI_Option_Setting._uI_Controller_Setting._gameManagerB._changeLanguage._sO_UISetting.IsEN)
        {
            this.text.text = "Exit";
        }
        else if(this.uI_Option_Setting._uI_Controller_Setting._gameManagerB._changeLanguage._sO_UISetting.IsVN)
        {
            this.text.text = "Thoát";
        }
    }

    private void PressBtn()
    {
        if(!this.IsSettingGameInitialized)
        {
            this.button.onClick.AddListener(ExitPanel);
            IsSettingGameInitialized = true;
        }
    }

    private void ExitPanel()
    {
        this.uI_Option_Setting.gameObject.SetActive(false);
        this.uI_Option_MainMenu._uI_Btn_Setting.isSettingGameInitialized = false;
    }
}