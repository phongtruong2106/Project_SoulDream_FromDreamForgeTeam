using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzel : LoadDataParent
{
    public bool IsPuzzelPiano ;
    public bool IsPuzzelLockBox ;
    public bool IsWaterGlass;
    public bool IsPuzzelPotSteam;
    public bool IsPuzzelClock;
    public bool IsPuzzelEar;
    
    protected override void Start()
    {
        base.Start();
        this.LoadPuzzelDataFromDataManager();
    }
    protected virtual void Update()
    {
    }
    protected virtual void LoadPuzzelDataFromDataManager()
    {
        PuzzelData puzzelData = this.dataManager._LoadData.LoadPuzzelData();
        if (puzzelData != null)
        {
            this.IsPuzzelPiano = puzzelData.isPuzzelPiano;
            this.IsPuzzelLockBox = puzzelData.isPuzzelLockBox;
            this.IsWaterGlass = puzzelData.isWaterGlass;
            this.IsPuzzelPotSteam = puzzelData.isPuzzelPotSteam;
            this.IsPuzzelClock = puzzelData.isPuzzelClock;
            this.IsPuzzelEar = puzzelData.isPuzzelEar;

            Debug.Log("Puzzel data loaded into LoadPuzzel.");
        }
    }
}
