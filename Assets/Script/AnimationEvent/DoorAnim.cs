using UnityEngine;

public class DoorAnim : DataGame
{
    [Header("Player Controller")]
    public static DoorAnim instance;
    
    [SerializeField] private bool isBoolChange;
    [SerializeField] protected DoorController doorController;
    [SerializeField] protected SFX_Door sFX_Door;
    public bool isOpen;
    public bool IsChange;

    protected override void Start()
    {
        this.IsChange = true;
        this.isBoolChange = false;
    }

    protected override void Awake()
    {
        base.Awake();
        if(DoorAnim.instance != null) Debug.LogError("Only 1 DoorAnim allow to ");
        DoorAnim.instance = this;
    }
    private void Update()
    {
        this.ChangeBool();
        this.OpenDoorData();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDoorController();
        this.LoadSFXDoor();

    }

    private void LoadSFXDoor()
    {
        if(this.sFX_Door != null) return;
        this.sFX_Door = gameObject.GetComponentInChildren<SFX_Door>();
    }

    protected virtual void LoadDoorController()
    {
        if (this.doorController != null) return;
        this.doorController = transform.parent.GetComponent<DoorController>();
        Debug.Log(transform.name + ": LoadDoorController()", gameObject);
    }

    public void OpenDoor()
    {
        doorController._animator.SetBool("isOpen", true);
        doorController._KeyHolder.isOpen = true;
        this.isOpen = true;
    }
    public void PlaySound()
    {
        sFX_Door.sfx_Door();
    }
    private void OpenDoorData()
    {
        if (this.isOpen)
        {
            this.OpenDoor();
            this.SaveData();
        }
    }

    private void ChangeBool()
    {
        if(!isBoolChange)
        {
            this.isOpen = this.loadDataController._LoadDoor.Door1;
            this.isBoolChange = true;
        }
        
    }
    private void SaveData()
    {
        if(IsChange)
        {
            this.dataSaveManager._DoorDataNew.IsDoor1 = this.isOpen;
            this.IsChange = false;
        }  
    }
}
