using UnityEngine;

public class CameraTriggerForPuzzel : Zoom
{
    protected virtual void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            cameraController.zoom = zoom;
            cameraController.xOffset = xoffset;
            cameraController.yOffset = yOffset;
            cameraController.followSpeed = followSpeed;
            cameraController.xRosOffset = this.xRosOffset;
            cameraController.yRosOffset = this.yRosOffset;
            if(this.targetPoint != null)
            {
                cameraController.targetDefaul = this.targetPoint;
            }
            else
            {
                cameraController.targetDefaul = cameraController.targetPlayer;
            }
             
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
              cameraController.zoom = cameraController._defaultZoom;
            cameraController.xOffset = cameraController.defaultxOffset;
            cameraController.yOffset = cameraController.defaultyOffset;
            cameraController.followSpeed = cameraController.defaulFollowSpeed;
            cameraController.targetDefaul = cameraController.targetPlayer;
            cameraController.xRosOffset = 0;
            cameraController.yRosOffset = 0;
             
        }
    }

}