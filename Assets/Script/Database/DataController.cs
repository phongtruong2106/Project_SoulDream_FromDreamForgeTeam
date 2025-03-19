using UnityEngine;

public class DataController : NewMonoBehaviour
{
    [SerializeField] protected DataCheckArea dataCheckArea;
    public DataCheckArea _dataCheckArea => dataCheckArea; 
    [SerializeField] protected DataDoor dataDoor;
    public DataDoor _dataDoor => dataDoor;
    [SerializeField] protected DataPuzzel dataPuzzel;
    public DataPuzzel _dataPuzzel => dataPuzzel;
    [SerializeField] protected DataScenes dataScenes;
    public DataScenes _dataScenes => dataScenes;
    [SerializeField] protected DataPosition dataPosition;
    public DataPosition _dataPosition => dataPosition;
    [SerializeField] protected Dataprogress dataprogress;
    public Dataprogress _dataprogress => dataprogress;
    [SerializeField] protected PlayerControler playerController;
    public PlayerControler _playerControler => playerController;
    [SerializeField] protected DataManager dataManager;
    public DataManager _dataManager => dataManager;
    [SerializeField] protected DataDialogue dataDialogue;
    public DataDialogue _dataDialogue => dataDialogue;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataCheckArea();
        this.LoadDataDoor();
        this.LoadDataPuzzel();
        this.LoadDataScenes();
        this.LoadDataPosition();
        this.LoadPlayerController();
        this.LoadDataManager();
        this.LoadDataDialogue();
    }

    private void LoadDataDialogue()
    {
        if(this.dataDialogue != null) return;
        this.dataDialogue = gameObject.GetComponentInChildren<DataDialogue>();
    }
    protected virtual void LoadDataManager()
    {
        if(this.dataManager != null) return;
        this.dataManager = FindAnyObjectByType<DataManager>();
    }
    protected virtual void LoadDataCheckArea()
    {
        if(this.dataCheckArea != null) return;
        this.dataCheckArea = FindAnyObjectByType<DataCheckArea>();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindAnyObjectByType<PlayerControler>();
    }
    
    protected virtual void LoadDataDoor()
    {
        if( this.dataDoor != null) return;
        this.dataDoor = FindAnyObjectByType<DataDoor>();
    }
    protected virtual void LoadDataPuzzel()
    {
        if( this.dataPuzzel != null) return; 
        this.dataPuzzel = FindAnyObjectByType<DataPuzzel>();
    }
    protected virtual void LoadDataScenes()
    {
        if( this.dataScenes != null) return; 
        this.dataScenes = FindAnyObjectByType<DataScenes>();
    }
    protected virtual void LoadDataPosition()
    {
        if( this.dataPosition != null) return;
        this.dataPosition = FindAnyObjectByType<DataPosition>();
    }
}