using UnityEngine;

public class UI_Btn_Setting_Selected : NewMonoBehaviour
{

    [SerializeField] protected UI_Btn_Setting_GraphicsOption uI_Btn_Setting_GraphicsOption;
    public UI_Btn_Setting_GraphicsOption _uI_Btn_Setting_GraphicsOption => uI_Btn_Setting_GraphicsOption;
    [SerializeField] protected UI_Btn_Setting_LanguageOption uI_Btn_Setting_LanguageOption;
    public UI_Btn_Setting_LanguageOption _uI_Btn_Setting_LanguageOption => uI_Btn_Setting_LanguageOption;
    [SerializeField] protected UI_Btn_Setting_ScreenOption uI_Btn_Setting_ScreenOption;
    public UI_Btn_Setting_ScreenOption _uI_Btn_Setting_ScreenOption => uI_Btn_Setting_ScreenOption;
    [SerializeField] protected UI_Btn_Setting_VoiceOption uI_Btn_Setting_VoiceOption;
    public UI_Btn_Setting_VoiceOption _uI_Btn_Setting_VoiceOption => uI_Btn_Setting_VoiceOption;
    [SerializeField] protected UI_Btn_Setting_VolumeSilen uI_Btn_Setting_VolumeSilen;
    [SerializeField] protected GameManagerB gameManagerB;
    public GameManagerB _gameManagerB => gameManagerB;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIBtnGraphicsOption();
        this.LoadBtnLanguagesOption();
        this.LoadBtnScreenOption();
        this.LoadBtnVoicesOption();
        this.LoadVolumeSilen();
        this.LoadGameManager();
    }

    private void LoadGameManager()
    {
        if(this.gameManagerB != null) return;
        this.gameManagerB = FindAnyObjectByType<GameManagerB>();
    }
    private void LoadUIBtnGraphicsOption()
    {
        if(this.uI_Btn_Setting_GraphicsOption != null) return;
        this.uI_Btn_Setting_GraphicsOption = gameObject.GetComponentInChildren<UI_Btn_Setting_GraphicsOption>();
    }
    
    private void LoadBtnLanguagesOption()
    {
        if(this.uI_Btn_Setting_LanguageOption != null) return;
        this.uI_Btn_Setting_LanguageOption = gameObject.GetComponentInChildren<UI_Btn_Setting_LanguageOption>();
    }

    private void LoadBtnScreenOption()
    {
        if(this.uI_Btn_Setting_ScreenOption != null) return;
        this.uI_Btn_Setting_ScreenOption = gameObject.GetComponentInChildren<UI_Btn_Setting_ScreenOption>();
    }
    private void LoadBtnVoicesOption()
    {
        if(this.uI_Btn_Setting_VoiceOption != null) return;
        this.uI_Btn_Setting_VoiceOption = gameObject.GetComponentInChildren<UI_Btn_Setting_VoiceOption>();
    }
    private void LoadVolumeSilen()
    {
        if(this.uI_Btn_Setting_VolumeSilen != null) return;
        this.uI_Btn_Setting_VolumeSilen = gameObject.GetComponentInChildren<UI_Btn_Setting_VolumeSilen>();
    }
}