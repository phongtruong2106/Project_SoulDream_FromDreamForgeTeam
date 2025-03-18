using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Inventory : NewMonoBehaviour
{
    public event EventHandler OnKeysChanged;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform itemHolder;
    [SerializeField] protected UIController uIController;
    private Dictionary<ItemType, Item> itemDictionary = new Dictionary<ItemType, Item>();
    public Dictionary<ItemType, Item> ItemsDictionary => itemDictionary;
    [SerializeField] private GameObject postionHandTargetGrabItem;
    private PlayerControler playerControler;
    [SerializeField] private Sprite image_null;
    public bool isGrab;
    public bool IsGrab => isGrab;
    private Item currentItemInSlot;
    protected bool isFull = false;
    
    private void Update()
    {
            this.PressToDrop();
            this.GrabItems();
            //this.LogItemCount();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadPlayerController();
    }

    private void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = gameObject.GetComponentInParent<PlayerControler>();
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController();", gameObject);
    }
    public void AddItem(Item newItem)
    {
            if (currentItemInSlot == null)
            {
                itemDictionary[newItem._itemSO.itemType] = newItem;
                newItem.transform.SetParent(itemHolder);
                uIController._uIGame._spriteItem.sprite = newItem._itemSO.image;
                //newItem.transform.position = new Vector3(postionHandTargetGrabItem.transform.position.x, postionHandTargetGrabItem.transform.position.y ,postionHandTargetGrabItem.transform.position.z);
                currentItemInSlot = newItem;
                isGrab = true;
            }
            else
            {
                Debug.Log("Cannot add item, inventory slot is already full");
            }
    }

   

    protected virtual void GrabItems()
    {
        if(this.isGrab)
        {
            if(currentItemInSlot != null)
            {
                Vector3 HandPosition = new Vector3(postionHandTargetGrabItem.transform.position.x, postionHandTargetGrabItem.transform.position.y ,postionHandTargetGrabItem.transform.position.z);
                this.currentItemInSlot.transform.position = HandPosition;
            }
        }
    }
    protected virtual void PressToDrop()
    {
        if(this.isGrab)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                this.DropCurrentItem();
            }
        }
    }

    
   public void RemoveItemWithGameObject(ItemType itemType)
    {
        if (itemDictionary.ContainsKey(itemType))
        {
            Item item = itemDictionary[itemType];
            this.playerControler._itemEventNew.isItem = false;
            if (item != null && item.gameObject != null)
            {
                Destroy(item.transform.gameObject);
            }
             
            ItemsDictionary.Remove(itemType);
            isGrab = false;
            uIController._uIGame._spriteItem.sprite = null;
            OnKeysChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public void DropCurrentItem()
    {
        if(currentItemInSlot != null)
        {
            itemDictionary.Remove(currentItemInSlot._itemSO.itemType);
            uIController._uIGame._spriteItem.sprite = image_null;
            currentItemInSlot.transform.SetParent(null);
            Vector3 dropPosition = postionHandTargetGrabItem.transform.position + postionHandTargetGrabItem.transform.forward * 1f;
            currentItemInSlot.transform.position = dropPosition;
            currentItemInSlot = null;
            OnKeysChanged?.Invoke(this, EventArgs.Empty);
            isGrab = false;
        }
    }
    public void RemoveItemInventory(ItemType itemType)
    {
        if (itemDictionary.ContainsKey(itemType))
        {
            Item item = itemDictionary[itemType];
            this.playerControler._itemEventNew.isItem = false;
            ItemsDictionary.Remove(itemType);
            uIController._uIGame._spriteItem.sprite = image_null;
            OnKeysChanged?.Invoke(this, EventArgs.Empty);
            this.isGrab = false;
        }
    }
    public void GetTranformItem(Transform transform)
    {
    
        this.currentItemInSlot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        uIController._uIGame._spriteItem.sprite = image_null;
        currentItemInSlot.transform.SetParent(null);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem()
    {
        itemDictionary.Remove(currentItemInSlot._itemSO.itemType);
        this.playerControler._itemEventNew.isItem = false;
        uIController._uIGame._spriteItem.sprite = image_null;
        currentItemInSlot.transform.SetParent(null);
        currentItemInSlot = null;
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
        this.isGrab = false;
    }
}