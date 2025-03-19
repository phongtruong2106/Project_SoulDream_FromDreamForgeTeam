using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerMainMenu : NewMonoBehaviour
{
    [SerializeField] protected GameManagerB gameManagerB;
    public GameManagerB _gameManagerB => gameManagerB;
    [SerializeField] protected DataManager dataManager;
    public DataManager _dataManager => dataManager;
    [SerializeField] protected UI_Option_Setting uI_Option_Setting;
    public UI_Option_Setting _uI_Option_Setting => uI_Option_Setting;
 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameManagerB();
        this.LoadDataController();
        this.LoadUIOptionSetting();
    }
    
    private void LoadUIOptionSetting()
    {
        if(this.uI_Option_Setting != null) return;
        this.uI_Option_Setting = gameObject.GetComponentInChildren<UI_Option_Setting>();
    }
    protected virtual void LoadDataController()
    {
        if(this.dataManager != null) return;
        this.dataManager = FindAnyObjectByType<DataManager>();
    }
    protected virtual void LoadGameManagerB()
    {
        if(this.gameManagerB != null) return;
        this.gameManagerB = FindAnyObjectByType<GameManagerB>();
    }
}
