using UnityEngine;
using UnityEngine.UI;

public class UI_Bt_Setting : UI_BtnGame
{
    public Button _buttonSettingGame => button;
    public bool isSettingGameInitialized = false;
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

        this.PressButton();
    }

    protected virtual void ChangeLanguage()
    {
         var languageSetting = this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting;
       if (languageSetting.IsEN)
        {
            this.text.text = "Setting";
        }
         else if (languageSetting.IsVN)
        {
            this.text.text = "Cài đặt";
        }
    }
    private void PressButton()
    {
        if(!isSettingGameInitialized)
        {
            this.button.onClick.AddListener(OpenPanelSetting);
            isSettingGameInitialized = true;
        }
    }

    private void OpenPanelSetting()
    {
       this.uI_Option_MainMenu._uIControllerMainMenu._uI_Option_Setting.gameObject.SetActive(true);
       this.uI_Option_Setting._exit_btn.IsSettingGameInitialized = false;
    }

}