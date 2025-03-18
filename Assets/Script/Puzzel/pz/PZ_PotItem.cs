using UnityEngine;

public class PZ_PotItem : PuzzelNew
{
    public bool isPotItem = false;
    protected override void Update()
    {
        base.Update();
        this.IsPotItem();
    }

    protected virtual void IsPotItem()
    {
        if(isPuzzel)
        {
            isPotItem = true;
        }
    }
}