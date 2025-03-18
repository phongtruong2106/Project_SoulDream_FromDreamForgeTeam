using UnityEngine;

public class DoorAnim2 : DataGame
{
    [SerializeField] protected PZ_Door pZ_Door;
    [SerializeField] protected PZR2_Controller pZR2_Controller;
    public bool isOpen;
    public bool IsChange;
    private bool isBoolChange;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPZDoor();
    }

    private void LoadPZDoor()
    {
        if(this.pZ_Door != null) return;
        this.pZ_Door = gameObject.GetComponentInParent<PZ_Door>();
    }
    public void OpenDoor()
    {
        this.pZR2_Controller._Animator.SetBool("isOpen", true);

    }
    public void PlaySound()
    {
        pZ_Door._sFX_Door.sfx_Door();
    }

    
    private void ChangeBool()
    {
        if(!isBoolChange)
        {
            this.isOpen = this.loadDataController._LoadDoor.Door1;
            this.isBoolChange = true;
        }
        
    }
    public void SaveData()
    {
        if(IsChange)
        {
            this.dataSaveManager._DoorDataNew.IsDoor2 = this.isOpen;
            this.IsChange = false;
        }  
    }
}