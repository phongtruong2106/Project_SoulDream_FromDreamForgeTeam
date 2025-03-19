using Unity.VisualScripting;
using UnityEngine;

public class PZ_Click : DataGame
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected Pz_Clock_Controller pz_Clock_Controller;
    protected bool IsOpen;
    private bool isBoolChange;
    protected bool CanOpen;
    protected override void Start()
    {
        this.CanOpen = true;
        this.isBoolChange = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPZClockController();
    }
    private void Update() {
        this.OpenClock();
        this.SaveData();
        this.ChangeDataBool();
    }
    protected virtual void LoadPZClockController()
    {
        if(this.pz_Clock_Controller != null) return;
        this.pz_Clock_Controller = gameObject.GetComponentInParent<Pz_Clock_Controller>();
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = gameObject.GetComponent<Animator>();
    }
    protected virtual void OnMouseDown()
    {
        this.animator.SetTrigger("Onlick");
        if(this.pz_Clock_Controller._pz_Clock.isClock)
        {
            this.IsOpen = true;
        }
    }

    protected void OpenClock()
    {
        if(this.CanOpen)
        {
            if(IsOpen)
            {
                this.pz_Clock_Controller._pz_Clock.animator.SetTrigger("isOpen");
                this.CanOpen = false;
            }
        }
        
    }

    private void ChangeDataBool()
    {
        if(!this.isBoolChange)
        {
            this.IsOpen = this.loadDataController._LoadPuzzel.IsPuzzelClock;
            this.isBoolChange = true;
        }
    }   

    private void SaveData()
    {
        if(!this.dataController._dataDoor.isDataSaved && this.dataController._dataCheckArea.isPlayer)
        {
            this.dataSaveManager._PuzzelDataNew.IsPuzzelClock = this.IsOpen;
        }
    }
}