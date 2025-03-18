using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoomPressKey : Zoom
{
    [Header("Zoom Press Key")]
    protected bool isZoom;
    [SerializeField] protected bool isZone;
    protected bool isPress;
    [SerializeField ] protected bool isHideUI;
    [SerializeField] protected GameObject uI_PressExit;
    [SerializeField] protected List<GameObject> objectsList;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected CameraTriggerForPuzzel cameraTriggerForPuzzel;
    [SerializeField] protected PZ_BookCaseController pZ_BookCaseController;

    private void Update() 
    {
        this.PressKeyZoom();
        this.HideUIPresskey();
        this.HideUI();
        this.LoadPZBookCaseController();
    }
    private void LoadPZBookCaseController()
    {
        if(this.pZ_BookCaseController != null) return;
        this.pZ_BookCaseController = gameObject.GetComponentInParent<PZ_BookCaseController>();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadCameraTriggerForPuzzel();
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = GameObject.FindAnyObjectByType<UIController>();
    }
    protected virtual void LoadCameraTriggerForPuzzel()
    {
        if(this.cameraTriggerForPuzzel != null) return;
        this.cameraTriggerForPuzzel = gameManager.GetComponentInChildren<CameraTriggerForPuzzel>();
    }
    protected override void Start()
    {
        base.Start();
        this.isZoom = false;
        this.isZone = false;
        this.isPress = true;
        foreach (GameObject obj in objectsList)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            this.isZone = true;
        }
        
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            this.isZone = false;
            this.isPress= false;
            this.DefaultZoomTarget();
            this.uI_PressExit.gameObject.SetActive(false);
            this.object_Interact.IsClickObj = false;
        }
        
    }

    protected virtual void PressKeyZoom()
    {   
        if(isZone)
        {
            if(Input.GetKey(KeyCode.F))
            {
                
                    this.ZoomTarget();
                    this.gameManager._hideMouse.isHide = true;
                    this.isPress = true;
                    this.uI_PressExit.gameObject.SetActive(true);
                    this.isHideUI = true;
                    if(this.pZ_BookCaseController != null)
                    {
                        foreach (Light light in this.pZ_BookCaseController._lightlist)
                        {  
                            if(light != null)
                            {
                            light.enabled = true;
                                Debug.Log($"Enabled light: {light.name}"); 
                            }
                            
                        }
                    }
                    if(this.cameraTriggerForPuzzel != null)
                    {
                        this.cameraTriggerForPuzzel.gameObject.SetActive(false);
                    }
                    foreach (GameObject obj in objectsList)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
            }           
        }   
    }
    protected virtual void HideUI()
    {
        if(isHideUI)
        {
            this.uIController._uI_PressButton.gameObject.SetActive(false);
        }
    }
    protected virtual void HideUIPresskey()
    {
        if(!this.isPress)
        {
            if(this.cameraTriggerForPuzzel != null)
            {
                this.cameraTriggerForPuzzel.gameObject.SetActive(true);
            }
            this.uIController._uI_PressButton.gameObject.SetActive(true);
            this.uI_PressExit.gameObject.SetActive(false);
            this.isHideUI = false;
            
        }
    }
}