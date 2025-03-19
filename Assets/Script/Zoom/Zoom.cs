using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : NewMonoBehaviour
{
    [Header("Zoom")]
    [SerializeField] protected float zoom;
    [SerializeField] protected float xoffset;
    [SerializeField] protected float yOffset;
    [SerializeField] protected float xRosOffset;
    [SerializeField] protected float yRosOffset;
    [SerializeField] protected float followSpeed;
 
    [SerializeField] protected CameraController cameraController;
    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected GameObject targetPoint;
    [SerializeField] protected Object_interact object_Interact;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCameraController();
        this.LoadGameManager();
        this.LoadInteract();
    }

    protected virtual void LoadInteract()
    {
        if(this.object_Interact != null) return;
        this.object_Interact = FindAnyObjectByType<Object_interact>();
    }

    protected virtual void LoadCameraController()
    {
        if(this.cameraController != null) return;
        this.cameraController = FindAnyObjectByType<CameraController>();
    }
    protected virtual void LoadGameManager()
    {
        if(this.gameManager != null) return;
        this.gameManager = FindAnyObjectByType<GameManager>();
    }


    protected virtual void DefaultZoomTarget()
    {
        cameraController.zoom = cameraController._defaultZoom;
        cameraController.xOffset = cameraController.defaultxOffset;
        cameraController.yOffset = cameraController.defaultyOffset;
        cameraController.followSpeed = cameraController.defaulFollowSpeed;
        cameraController.targetDefaul = cameraController.targetPlayer;
        cameraController.xRosOffset = 0;
        cameraController.yRosOffset = 0;
    }
    protected virtual void ZoomTarget()
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
