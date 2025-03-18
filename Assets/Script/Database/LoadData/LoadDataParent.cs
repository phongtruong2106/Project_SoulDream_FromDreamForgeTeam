using UnityEngine;

public class LoadDataParent : NewMonoBehaviour
{
    [SerializeField] protected DataManager dataManager;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataManager();
    }
    protected virtual void LoadDataManager()
    {
        if(this.dataManager != null) return;
        this.dataManager = gameObject.GetComponentInParent<DataManager>();
    }
}