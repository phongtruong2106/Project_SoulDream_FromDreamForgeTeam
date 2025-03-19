using Unity.VisualScripting;
using UnityEngine;

public class DataUI : DataSave
{
    [SerializeField] protected DataManager dataManager;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataManager();
    }

    private void LoadDataManager()
    {
        if(this.dataManager != null) return;
        this.dataManager = gameObject.GetComponentInParent<DataManager>();
    }
}