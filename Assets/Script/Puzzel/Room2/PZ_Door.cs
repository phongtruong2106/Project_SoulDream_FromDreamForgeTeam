using UnityEngine;

public class PZ_Door : DataGame
{
    [SerializeField] protected PZR2_Controller pZR2_Controller;
    [SerializeField] protected GameObject GrayObj;
    [SerializeField] protected bool isPlayer = false;
    [SerializeField] private SFX_Door sFX_Door;
    public SFX_Door _sFX_Door => sFX_Door;
    public bool isOpen;
    public bool IsChange;
    private bool isBoolChange;
    private bool isHideSteam;
    private bool isChangeData;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPZR2Controller();
        this.LoadSFXDoor();
    }

    protected override void Start()
    {
        base.Start();
        this.IsChange = true;
        this.isHideSteam = true;
        this.isBoolChange = false;
        this.isChangeData = true;
        this.GrayObj.gameObject.SetActive(false);
    }
    protected virtual void Update()
    {
        this.CanOpen();
        this.IsOpen();
        this.ChangeBool();
        this.OpenDoorWithData();
    }

    protected void LoadSFXDoor()
    {
        if(this.sFX_Door != null) return;
        this.sFX_Door = gameObject.GetComponentInChildren<SFX_Door>();
    }

    protected virtual void LoadPZR2Controller()
    {
        if(this.pZR2_Controller != null) return;
        this.pZR2_Controller = gameObject.GetComponentInParent<PZR2_Controller>();
    }
    protected virtual void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.isPlayer = true;
        }
    }
    protected virtual void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.isPlayer = false;
        }
    }
    protected virtual void IsOpen()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(this.pZR2_Controller._pz_SteamPot.isPos)
            {
                if(this.isPlayer)
                {
                    this.pZR2_Controller._Animator.SetBool("isOpen", true);
                    this.SaveData(); 
                }
            }
           
        }
    }
    protected virtual void CanOpen()
    {
        if(this.pZR2_Controller._pz_SteamPot.isPos)
        {
            if(this.isHideSteam)
            {
                this.GrayObj.gameObject.SetActive(true);
                this.isHideSteam = false;
            }
        }
    }
    
    private void ChangeBool()
    {
        if(!isBoolChange)
        {
            this.isOpen = this.loadDataController._LoadDoor.Door2;
            this.isBoolChange = true;
        }
        
    }
    private void SaveData()
    {
        if(this.IsChange)
        {
            this.isOpen = true;
            this.dataSaveManager._DoorDataNew.IsDoor2 = this.isOpen;
            this.IsChange = false;
        }  
    }

    private void OpenDoorWithData()
    {
        if(this.isChangeData)
        {
            if(this.isOpen)
            {
                this.pZR2_Controller._Animator.SetBool("isOpen", true);
                this.isChangeData = false; 
                Debug.Log(isOpen); 
            }            
        }
    }
    protected virtual void OpenCutScene()
    {
        Debug.Log("OpenScene");
    }
}