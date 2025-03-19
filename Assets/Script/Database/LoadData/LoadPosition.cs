using UnityEngine;

public class LoadPosition : LoadDataParent
{
    protected override void Start()
    {
        if(this.dataManager != null)
        {
            this.dataManager._LoadData.LoadPositionData();
        }
    }
   
}