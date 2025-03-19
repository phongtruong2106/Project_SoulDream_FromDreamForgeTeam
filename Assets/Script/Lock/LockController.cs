using UnityEngine;

public class LockController : Zoom
{
    protected bool isOpenLock = false;
    private void Update() {
        this.IsOpenLock();
        this.ChangedTargetZoom();
    }

    protected virtual void IsOpenLock()
    {
        if(LockManager.Instance.isAfterOpenLock)
        {
            this.isOpenLock = true;
        }
    }

    protected virtual void ChangedTargetZoom()
    {
        if(isOpenLock)
        {
            this.ZoomTarget();
        }
        
    }
}