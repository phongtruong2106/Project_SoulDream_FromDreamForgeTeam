using UnityEngine;
using UnityEngine.UI;

public class UI_Bt_Credit : UI_BtnGame
{
     public Button _buttonCreditGame => button;
     protected override void Start()
    {
        this.ChangeLanguage();
    }

    protected override void Update()
    {
        this.ChangeLanguage();
    }

    protected virtual void ChangeLanguage()
    {
        if(this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting.IsEN)
        {
            this.text.text = "Credits";
        }
        else if(this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting.IsVN)
        {
            this.text.text = "Credits";
        }
    }
}