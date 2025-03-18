using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPuzzel : ZoomPressKey
{
    protected override void PressKeyZoom()
    {
        base.PressKeyZoom();
        if(isZone)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(this.pZ_BookCaseController != null)
                {
                    foreach (Light light in this.pZ_BookCaseController._lightlist)
                    {  
                        if(light != null)
                        {
                            light.enabled = false;
                        }
                    }
                }
                foreach (GameObject obj in objectsList)
                {
                    if (obj != null)
                    {
                        obj.SetActive(false);
                    }
                }
                this.DefaultZoomTarget();
                this.isPress = false;
                this.gameManager._hideMouse.isHide = false;
                this.object_Interact.IsClickObj = false;
                this.uIController._ui_PZ_Mouse.gameObject.SetActive(false);
                if(this.cameraTriggerForPuzzel != null)
                {
                    this.cameraTriggerForPuzzel.gameObject.SetActive(true);
                }
                
            }
        }
    }
}
