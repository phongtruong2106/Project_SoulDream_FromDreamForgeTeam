using UnityEngine;

public class ItemEventNew : NewMonoBehaviour
{
    [Header("Item Event")]
    [SerializeField] protected string textBox;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected Object obj_ItemCheck;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    public bool isChecktoGrab;
    public bool IsChecktoGrab => isChecktoGrab;
    public bool isItem;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadUIController();
        this.LoadPlayerController();
    }

    protected void Update()
    {
        this.CheckIsPlayer();
     //   this.ChangeIsItem();
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
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

    protected virtual void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            this.isItem = true;
            this.ItemCheck(other);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            this.isItem = false;
            this.uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(false);
        }
    }
    protected virtual void CheckIsPlayer()
    {
        if(!this.inventory.IsGrab)
        {
            if(this.isItem)
            {
                this.uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(true);
                this.Following();
                this.uIController._uI_PressButtonItem._text_ObjPress.text = textBox;
                this.isChecktoGrab = true;
            }
            else if(!this.isItem)
            {
                this.uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(false);
                this.isChecktoGrab = false;
            }
        }
        
    }

    protected virtual void Following()
    {
        if(this.target == null) return;
       this.uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
    protected virtual void ItemCheck(Collider collider)
    {
        if (Input.GetKey(KeyCode.H) && IsChecktoGrab)
        {
            Item Item = collider.GetComponent<Item>();        
            playerControler._inventory.AddItem(Item); 
        }
           
    }
}