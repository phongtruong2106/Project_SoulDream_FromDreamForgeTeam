using UnityEngine;

public class LoadDoor : LoadDataParent
{
    public bool Door1;
    public bool Door2;
   // private bool isChange;

    protected override void Start()
    {
        base.Start();
        this.LoadDoorDataFromDataManager();
        
    }
    private void Update()
    {
        
    }
    protected virtual void LoadDoorDataFromDataManager()
    {
            DoorData doorData = this.dataManager._LoadData.LoadDoorData();
            if(doorData != null)
            {
                this.Door1 = doorData.Door1;
                this.Door2 = doorData.Door2;
                Debug.Log("Puzzel data loaded into LoadDoor.");
            }
    }
}