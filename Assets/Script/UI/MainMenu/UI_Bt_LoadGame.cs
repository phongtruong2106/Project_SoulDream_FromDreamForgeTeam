using UnityEngine;
using UnityEngine.UI;

public class UI_Bt_LoadGame : UI_BtnGame
{
    public Button _Btn_LoadGame => button;
    public bool isLoadGameInitialized = false;
    [SerializeField] protected Color TextColor;
    private string currentLanguage = "";
  
    protected override void Awake()
    {
        base.Awake();
        this.ChangeLanguage();
    }
    protected override void Start()
    {
        this.ChangeLanguage();
        this.isLoadGameInitialized = false;
         this.SetDataSave();
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
        this.LoadGame();
        this.HideTextButton();
    }
    protected virtual void ChangeLanguage()
    {
        var languageSetting = this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting;
        if (languageSetting.IsEN)
        {
            this.text.text = "Continue";
        }
        else if (languageSetting.IsVN)
        {
            this.text.text = "Tiếp tục";
        }
    }
    protected virtual void LoadGame()
    {
        if(!this.uI_Option_MainMenu._uIControllerMainMenu._dataManager._LoadData.IsDataNull)
        {
            if (!isLoadGameInitialized)
            {
                this.button.onClick.AddListener(LoadData);
                isLoadGameInitialized = true;
            }
        }
    }
    private void LoadData()
    {
        this.uI_Option_MainMenu._uIControllerMainMenu._dataManager._LoadData.LoadSceneData();
    }

    private void SetDataSave()
    {
        this.uI_Option_MainMenu._uIControllerMainMenu._dataManager._LoadData.LoadPositionDataLoadSetBool();
    }

    private void HideTextButton()
    {
        if(this.uI_Option_MainMenu._uIControllerMainMenu._dataManager._LoadData.IsDataNull)
        {
            this.text.color = this.TextColor;
        }
    }
}