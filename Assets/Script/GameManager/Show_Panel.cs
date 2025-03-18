using UnityEngine;

public class Show_Panel : NewMonoBehaviour
{   
    [SerializeField] protected Show_PanelSetting show_PanelSetting;
    [SerializeField] protected UI_Controller_Setting uI_Controller_Setting;
    [SerializeField] protected GameManager gameManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowPanelSetting();
        this.LoadUIOptionSetting();
        this.LoadGameManager();
    }
    protected override void Start()
    {
        base.Start();
         this.show_PanelSetting.HidePanel(this.uI_Controller_Setting.gameObject);
    }
    protected void Update()
    {
        this.ShowPanelSetting();
        this.HidePanelSetting();
    }
    protected virtual void LoadGameManager()
    {
        if(this.gameManager != null) return;
        this.gameManager = FindAnyObjectByType<GameManager>();
    }
    protected virtual void LoadShowPanelSetting()
    {
        if(this.show_PanelSetting != null) return;
        this.show_PanelSetting = FindAnyObjectByType<Show_PanelSetting>();
    }
    protected virtual void LoadUIOptionSetting()
    {
        if(this.uI_Controller_Setting != null) return;
        this.uI_Controller_Setting = FindAnyObjectByType<UI_Controller_Setting>();
    }

    protected virtual void ShowPanelSetting()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            this.show_PanelSetting.ShowPanel(this.uI_Controller_Setting.gameObject);
            this.ShowMouse();
        }
    }
    
    protected virtual void HidePanelSetting()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            this.show_PanelSetting.HidePanel(this.uI_Controller_Setting.gameObject);
            this.HideMouse();
        }
    }
    protected virtual void ShowMouse()
    {
        this.gameManager._hideMouse.isHide = true;
    }
    protected virtual void HideMouse()
    {
        this.gameManager._hideMouse.isHide = false;
    }
}