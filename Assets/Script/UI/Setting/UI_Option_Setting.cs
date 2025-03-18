using UnityEngine;

public class UI_Option_Setting : NewMonoBehaviour
{   
    [SerializeField] protected UI_Btn_Exit uI_Btn_Exit;
    [SerializeField] protected UI_Controller_Setting uI_Controller_Setting;
    public UI_Controller_Setting _uI_Controller_Setting => uI_Controller_Setting;
    [SerializeField] protected UI_Setting_Exit exit_btn;
    public UI_Setting_Exit _exit_btn => exit_btn;
    [SerializeField] protected UI_Btn_Setting_Selected uI_Btn_Setting_Selected;
    public UI_Btn_Setting_Selected _UI_Btn_Setting_Selected => uI_Btn_Setting_Selected;
    [SerializeField] protected LoadDataController loadDataController;
    public LoadDataController _loadDataController => loadDataController;
    [SerializeField] protected LoadDataUIController loadDataUIController;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIBtnExit();
        this.LoadUIControllerSetting();
        this.LoadUISettingExit();
        this.LoadUIBtnSettingSelected();
        this.LoadLoadDataController();
        this.LoadLoadUIDataController();
    }
    private void LoadLoadDataController()
    {
        if(this.loadDataController != null) return;
        this.loadDataController = FindFirstObjectByType<LoadDataController>();
    }
    private void LoadLoadUIDataController()
    {
        if(this.loadDataUIController != null) return;
        this.loadDataUIController = FindFirstObjectByType<LoadDataUIController>();
    }
    private void LoadUIBtnSettingSelected()
    {
        if(this.uI_Btn_Setting_Selected != null) return;
        this.uI_Btn_Setting_Selected = gameObject.GetComponentInChildren<UI_Btn_Setting_Selected>();
    }

    private void LoadUISettingExit()
    {
        if(this.exit_btn != null) return;
        this.exit_btn = gameObject.GetComponentInChildren<UI_Setting_Exit>();
    }
    protected virtual void LoadUIBtnExit()
    {
        if(this.uI_Btn_Exit != null) return;
        this.uI_Btn_Exit = gameObject.GetComponentInChildren<UI_Btn_Exit>();
    }
    protected virtual void LoadUIControllerSetting()
    {
        if(this.uI_Controller_Setting != null) return;
        this.uI_Controller_Setting = gameObject.GetComponentInParent<UI_Controller_Setting>();
    }
    
}