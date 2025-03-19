using UnityEngine;

public class KeyItemData : DataGame
{
   // private bool isChange;
    private void Update() {
        this.IsLoadData();
    }
    protected override void Start()
    {
        base.Start();
     //   this.isChange = false;
    }

    private void IsLoadData()
    {
        if(dataSaveManager._DoorDataNew.IsDoor1)
        {
            this.gameObject.SetActive(false);
        }
    }
}