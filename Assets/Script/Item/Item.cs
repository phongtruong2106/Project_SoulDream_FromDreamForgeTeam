using UnityEngine;

public class Item : NewMonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    public ItemSO _itemSO => itemSO;
    protected ItemEvent itemEvent;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected Object_interact object_Interact;
    protected Rigidbody rg_Body;
    
    
    protected override void Start()
    {
        rg_Body = GetComponent<Rigidbody>();
        Physics.SyncTransforms();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemEvent();
        this.LoadInventory();
        this.LoadObjInteract();
    }

    protected void Update()
    {
       // this.PressToGrab();
        this.ChangeIskinematic();
        // this.GetItem();
    }
    protected virtual void LoadItemEvent()
    {
        if(this.itemEvent!= null) return;
        this.itemEvent = GetComponentInChildren<ItemEvent>();
    }
    protected virtual void LoadObjInteract()
    {
        if(this.object_Interact != null) return;
        this.object_Interact =  GameObject.FindAnyObjectByType<Object_interact>();
    }
    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = FindAnyObjectByType<Inventory>();
    }

    //get item inventory
    private void OnMouseDown()
    {
       this.inventory.AddItem(this);
    }


    protected virtual void ChangeIskinematic()
    {
        if(this.rg_Body != null)
        {
            if(!inventory.IsGrab)
            {
                rg_Body.isKinematic = false;
                rg_Body.AddForce(Vector3.down * 10f, ForceMode.Impulse);
            }
            else if(inventory.IsGrab)
            {
                rg_Body.isKinematic = true;
            }
        }
    }
}