using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Setting : NewMonoBehaviour
{
    public bool isSave;
    public bool isLoad;
    [SerializeField] protected TMP_Dropdown dropdown;
    [SerializeField] protected Scrollbar ScrollbarEventHandler;
    [SerializeField] protected UI_Btn_Setting_Selected uI_Btn_Setting_Selected;
    [SerializeField] protected UI_Option_Setting uI_Option_Setting;
    
    protected override void Start()
    {
        base.Start();
        this.isSave = false;

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDropDown();
        this.LoadScrollBar();
        this.LoadUISettingSelected();
        this.LoadUI_Bt_Setting();
    }
    private void LoadUISettingSelected()
    {
        if(this.uI_Btn_Setting_Selected != null) return;
        this.uI_Btn_Setting_Selected = gameObject.GetComponentInParent<UI_Btn_Setting_Selected>();
    }
    protected virtual void LoadDropDown()
    {
        if(this.dropdown  != null) return;
        this.dropdown = gameObject.GetComponentInChildren<TMP_Dropdown>();
    }
    
    private void LoadScrollBar()
    {
        if(this.ScrollbarEventHandler != null) return;
        this.ScrollbarEventHandler = gameObject.GetComponentInChildren<Scrollbar>();
    }
    private void LoadUI_Bt_Setting()
    {
        if(this.uI_Option_Setting != null) return;
        this.uI_Option_Setting = gameObject.GetComponentInParent<UI_Option_Setting>();
    }
}