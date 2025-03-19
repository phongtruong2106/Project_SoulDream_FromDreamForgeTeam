using UnityEngine;

public class EarItemData : DataGame
{
    protected void Update()
    {
        this.IsLoadData();
    }
    private void IsLoadData()
    {
        if(loadDataController._LoadPuzzel.IsPuzzelPotSteam)
        {
            this.gameObject.SetActive(false);
        }
    }
}