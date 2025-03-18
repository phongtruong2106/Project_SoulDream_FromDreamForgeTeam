using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class KeyHolder : NewMonoBehaviour
{
    public static KeyHolder instance;
    public bool isOpen = false;
    private List<Key.KeyType> keyList;
    [SerializeField]private Camera mainCamera;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected PlayerControler playerControler;
    
    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
    }
    protected override void Awake()
    {
        base.Awake();
        keyList = new List<Key.KeyType>();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadPlayerController();
        

    }
    protected virtual void LoadUIController()
    {
        if(this.uIController!= null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }
    protected virtual void CheckForFKey(Collider collider)
    {
        if (Input.GetKey(KeyCode.F))
        {
            HandleFKeyPressed(collider);
        }
    }
    

    protected virtual void HandleFKeyPressed(Collider collider)
    {
        this.KeyDoor(collider);
    }
    protected virtual void OnTriggerStay(Collider other)
    {
        CheckForFKey(other);
    }    
    private void OnTriggerEnter(Collider other)
    {
        this.CheckKeyDoorOn(other);
    }

    private void OnTriggerExit(Collider other)
    {
        this.CheckKeyOut(other);
        this.CheckKeyDoorOut(other);
    }

    protected virtual void KeyDoor(Collider collider)
    {
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {    
            if (playerControler._inventory.ItemsDictionary.ContainsKey(keyDoor.GetKeyType()))
            {             
                keyDoor.OpenDoor();
                playerControler._inventory.RemoveItemWithGameObject(keyDoor.GetKeyType());
                this.isOpen = true;
                uIController._uI_PressButton.CloseObjPress();
                Destroy(keyDoor.gameObject);
            }
            else
            {
                uIController._dialogueNew.OpenDialogue();
            }
        }
    }
    protected virtual void CheckKeyOut(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if(key != null) 
        {
            this.UnHideObje();
        }
    }
    protected virtual void CheckKeyDoorOn(Collider collider)
    {
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {   
            uIController._uI_PressButton.OpenObjPress();
            uIController._uI_PressButton._text_ObjPress.text = "Press F to open";
        }
    }
    protected virtual void CheckKeyDoorOut(Collider collider)
    {
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
             uIController._uI_PressButton.CloseObjPress();
        }
    }

    protected virtual void HideObj()
    {
        uIController._uI_PressButton.OpenObjPress();
    }
    protected virtual void UnHideObje()
    {
        uIController._uI_PressButton.CloseObjPress();
    }
    
}   