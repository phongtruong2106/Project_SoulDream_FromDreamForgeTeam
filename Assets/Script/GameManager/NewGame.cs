using System;
using UnityEngine;


public class NewGame : LoadScenes
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.nameScene = "lv1";
    }

    public virtual void ResetData()
    {
        this.dataManager._ClearData.ClearDataSave();
    }
}