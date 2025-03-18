using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : NewMonoBehaviour
{
    [SerializeField] protected LoadData loadData;
    public LoadData _LoadData => loadData;
    [SerializeField] protected DataIsLoaded dataIsLoaded;
    public DataIsLoaded _DataIsLoaded => dataIsLoaded;
    [SerializeField] protected ClearData clearData;
    public ClearData _ClearData => clearData;
    [SerializeField] protected UI_Option_Setting uI_Option_Setting;
    public UI_Option_Setting _ui_Option_Setting => uI_Option_Setting;
    protected override void Awake()
    {
        base.Awake();
    
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadData();
        this.LoadDataisLoad();
        this.LoadClearData();
        this.LoadUIOptionSetting();
    }

    private void LoadUIOptionSetting()
    {
        if(this.uI_Option_Setting != null) return;
        this.uI_Option_Setting = FindAnyObjectByType<UI_Option_Setting>();
    }
    protected virtual void LoadDataisLoad()
    {
        if(this.dataIsLoaded != null) return;
        this.dataIsLoaded = gameObject.GetComponentInChildren<DataIsLoaded>();
    }
    protected virtual void LoadData()
    {
        if(this.loadData != null) return;
        this.loadData = gameObject.GetComponentInChildren<LoadData>();
    }
    protected virtual void LoadClearData()
    {
        if(this.clearData != null) return;
        this.clearData = gameObject.GetComponentInChildren<ClearData>();    
    }
}
