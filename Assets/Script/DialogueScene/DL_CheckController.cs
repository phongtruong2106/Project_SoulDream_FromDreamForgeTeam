using UnityEngine;

public class DL_CheckController : NewMonoBehaviour
{
    [SerializeField] protected DL_CheckPlayer dL_CheckPlayer;
    public DL_CheckPlayer _DL_CheckPlayer => dL_CheckPlayer;
    [SerializeField] protected DL_CheckPlayerUnHide dL_CheckPlayerUnHide;
    public DL_CheckPlayerUnHide _DL_CheckPlayerUNHide => dL_CheckPlayerUnHide;
    [SerializeField] protected DL_Notifition dL_Notifition;
    public DL_Notifition _DL_Notification => dL_Notifition;
    [SerializeField] protected LoadDataController loadDataController;
    public LoadDataController _loadDataController => loadDataController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDLCheckPlayer();
        this.LoadDLCheckPlayerUnHide();
        this.LoadDL_Notifition();
        this.LoadDataManager();
    }

    private void LoadDataManager()
    {
        if(this.loadDataController != null) return;
        this.loadDataController =  FindAnyObjectByType<LoadDataController>();
    }
    protected override void Start()
    {
        if(this.dL_CheckPlayer != null)
        {
            this._DL_CheckPlayer.gameObject.SetActive(false);
        }
        
    }
    protected virtual void LoadDLCheckPlayer()
    {
        if(this.dL_CheckPlayer != null) return;
        this.dL_CheckPlayer = gameObject.GetComponentInChildren<DL_CheckPlayer>();
    }
    protected virtual void LoadDLCheckPlayerUnHide()
    {
        if(this.dL_CheckPlayerUnHide != null) return;
        this.dL_CheckPlayerUnHide = gameObject.GetComponentInChildren<DL_CheckPlayerUnHide>();
    }
     protected virtual void LoadDL_Notifition()
    {
        if(this.dL_Notifition != null) return;
        this.dL_Notifition = gameObject.GetComponentInChildren<DL_Notifition>();
    }
}