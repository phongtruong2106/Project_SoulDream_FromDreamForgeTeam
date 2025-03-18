using UnityEngine;

public class PZ_Holder : NewMonoBehaviour
{
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected UIController uIController;
    protected void Update()
    {
        this.OnClick();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
        this.LoadUIController();

    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController!= null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }
    protected virtual void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("PuzzelCheck"))
                {
                    Collider clickedCollider = hit.collider;
                    PZ_ItemTypeNew pzItemTypeNew = clickedCollider.GetComponent<PZ_ItemTypeNew>();
                    
                    if (pzItemTypeNew != null)
                    {
                        ItemCheck(clickedCollider);
                    }
                    else
                    {
                       // Debug.Log("No PZ_ItemTypeNew component found on clicked object.");
                    }
                }
                else
                {
                   // Debug.Log("Clicked object does not have the required tag.");
                }
            }
        }
    }

    protected virtual void ItemCheck(Collider collider)
    {
        PZ_ItemTypeNew pZ_ItemTypeNew = collider.GetComponent<PZ_ItemTypeNew>();
        if (pZ_ItemTypeNew != null)
        {
            if (playerControler._inventory.ItemsDictionary.ContainsKey(pZ_ItemTypeNew.GetKeyType()))
            {
                if(pZ_ItemTypeNew._puzzelNew.pos_Obj != null)
                {
                    playerControler._inventory.GetTranformItem(pZ_ItemTypeNew._puzzelNew.pos_Obj);  
                    playerControler._inventory.RemoveItem(); 
                }
                else
                {
                    playerControler._inventory.RemoveItemWithGameObject(pZ_ItemTypeNew.GetKeyType());
                }
                //playerControler._inventory.IsGrab = false;
                pZ_ItemTypeNew._puzzelNew.isPuzzel = true;
                Destroy(pZ_ItemTypeNew.gameObject);
            }
            else
            {
                pZ_ItemTypeNew.PZDialogue();
            }
        }
    }
}