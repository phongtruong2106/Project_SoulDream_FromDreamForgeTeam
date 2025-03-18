using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Option_MainMenu : NewMonoBehaviour
{
    [SerializeField] protected UI_Bt_NewGame uI_Bt_NewGame;
    [SerializeField] protected UI_Bt_LoadGame uI_Bt_LoadGame;
    [SerializeField] protected UIControllerMainMenu uIControllerMainMenu;
    public UIControllerMainMenu _uIControllerMainMenu => uIControllerMainMenu;
    [SerializeField] protected CutSceneController cutSceneController;
    public CutSceneController _cutSceneController => cutSceneController;
    [SerializeField] protected UI_Bt_Setting uI_Btn_Setting;
    public UI_Bt_Setting _uI_Btn_Setting => uI_Btn_Setting;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIBTNewGame();
        this.LoadUIBtnLoadGame();
        this.LoadUIControllerMainMenu();
        this.LoadCutScenesController();
        this.LoadUIOptionSetting();
    }
    private void LoadUIOptionSetting()
    {
        if(this.uI_Btn_Setting != null) return;
        this.uI_Btn_Setting = gameObject.GetComponentInChildren<UI_Bt_Setting>(); 
    }
    private void LoadCutScenesController()
    {
        if(this.cutSceneController != null) return;
        this.cutSceneController = FindAnyObjectByType<CutSceneController>();
    }
    protected virtual void LoadUIBTNewGame()
    {
        if(this.uI_Bt_NewGame != null) return;
        this.uI_Bt_NewGame = gameObject.GetComponentInChildren<UI_Bt_NewGame>();
    }
    protected virtual void LoadUIBtnLoadGame()
    {
        if(this.uI_Bt_LoadGame != null) return;
        this.uI_Bt_LoadGame = gameObject.GetComponentInChildren<UI_Bt_LoadGame>();
    }
    protected virtual void LoadUIControllerMainMenu()
    {
        if(this.uIControllerMainMenu != null) return;
        this.uIControllerMainMenu = gameObject.GetComponentInParent<UIControllerMainMenu>();
    }
}
