using UnityEngine;

public class DataGame : NewMonoBehaviour
{
    [SerializeField] protected DataSaveManager dataSaveManager;
    [SerializeField] protected LoadDataController loadDataController;
    [SerializeField] protected DataController dataController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataSaveManager();
            this.LoadDataController();  
        this.LoadOBJLoadDataController();  
    }
    private void LoadDataSaveManager()
    {
        if(this.dataSaveManager != null) return;
        this.dataSaveManager = FindAnyObjectByType<DataSaveManager>();
    }
     protected virtual void LoadDataController()
    {
        if(this.dataController != null) return;
        this.dataController = FindAnyObjectByType<DataController>();
    }
    protected virtual void LoadOBJLoadDataController()
    {
        if(this.loadDataController != null) return;
        this.loadDataController = FindAnyObjectByType<LoadDataController>();
    }
}