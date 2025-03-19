using UnityEngine;
using UnityEngine.UI;

public class UI_Btn_Exit : UI_BtnGame
{
    private bool isExitGameInitialized = false;
    
    protected override void Start()
    {
        this.ChangeLanguage();
    }

    protected override void Update()
    {
         this.ChangeLanguage();
         this.ExitToMenuGame();
    }

    protected virtual void ChangeLanguage()
    {
        if(this.uI_Option_Setting._uI_Controller_Setting._gameManagerB._changeLanguage._sO_UISetting.IsEN)
        {
            this.text.text = "Exit to Menu";
        }
        else if(this.uI_Option_Setting._uI_Controller_Setting._gameManagerB._changeLanguage._sO_UISetting.IsVN)
        {
            this.text.text = "Thoát";
        }
    }
    protected virtual void ExitToMenuGame()
    {
        if (!isExitGameInitialized)
        {
            this.button.onClick.AddListener(Scenes);
            isExitGameInitialized = true;
        }
    }

    protected virtual void Scenes()
    {
        this.uI_Option_Setting._uI_Controller_Setting._gameManagerB._ExitToMenu.LoadScene();
    }
}