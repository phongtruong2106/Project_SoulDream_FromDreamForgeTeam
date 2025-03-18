using UnityEngine;

public class LoadDataUI : NewMonoBehaviour
{
    [SerializeField] protected LoadDataController loadDataController;
    protected bool isLoad;
    protected override void Start()
    {
        base.Start();
        this.isLoad = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLoadDataController();
    }
    private void LoadLoadDataController()
    {
        if(this.loadDataController != null) return;
        this.loadDataController = FindFirstObjectByType<LoadDataController>();
    }

    
}