using UnityEngine;

public class ItemEvent : NewMonoBehaviour
{
    [Header("Item Event")]
    [SerializeField] protected string textBox;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected ItemCheck itemCheck;
    [SerializeField] protected Object obj_ItemCheck;
    protected bool isChecktoGrab = false;
    public bool IsChecktoGrab => isChecktoGrab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadItemCheck();
        this.LoadUIController();
    }

    protected void Update()
    {
        //this.CheckIsPlayer();
    }

    protected virtual void LoadItemCheck()
    {
        if(this.itemCheck != null) return;
        this.itemCheck = GetComponentInChildren<ItemCheck>();
    }

    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = FindAnyObjectByType<Inventory>();
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }

    // protected virtual void CheckIsPlayer()
    // {
    //     if(!this.inventory.IsGrab)
    //     {
    //         if(this.itemCheck.isPlayer)
    //         {
    //             this.uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(true);
    //             this.uIController._uI_PressButtonItem._text_ObjPress.text = textBox;
    //             this.isChecktoGrab = true;
    //         }
    //         else if(!this.itemCheck.isPlayer)
    //         {
    //             this.uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(false);
    //             this.isChecktoGrab = false;
    //         }
    //     }
    //     else
    //     {
    //         this.uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(false);
    //     }
        
    }

 
