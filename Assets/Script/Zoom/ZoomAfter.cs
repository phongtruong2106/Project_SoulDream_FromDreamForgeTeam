using UnityEngine;

public class ZoomAfter : Zoom
{
    private void Update() {
        this.IsPickLockKey();
    }
    protected virtual void IsPickLockKey()
    {
        if(LockManager.Instance.isPickKey)
        {
            this.DefaultZoomTarget();
            LockManager.Instance.isPickKey = false;
        }
    }
}