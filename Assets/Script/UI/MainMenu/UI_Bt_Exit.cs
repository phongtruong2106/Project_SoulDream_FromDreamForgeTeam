using UnityEngine;
using UnityEngine.UI;

public class UI_Bt_Exit : UI_BtnGame
{
    public Button _buttonExitGame => button;
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
        this.PressBTN();
    }

    protected virtual void ChangeLanguage()
    {
        var languageSetting = this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting;
         if (languageSetting.IsEN)
        {
            this.text.text = "Exit";
        }
         else if (languageSetting.IsVN)
        {
            this.text.text = "Thoát";
        }
    }

    private void PressBTN()
    {
        if(!this.isCall)
        {
            this.button.onClick.AddListener(Exit);
            this.isCall = true;
        }
    }
    private void Exit()
    {
        Application.Quit();

    }
}