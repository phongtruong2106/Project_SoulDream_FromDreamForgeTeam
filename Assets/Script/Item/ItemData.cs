using UnityEngine;

public class ItemData : NewMonoBehaviour
{
    [SerializeField] protected DataController dataController;
    [SerializeField] protected GameObject objItem;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataController();
    }
    private void Update()
    {
        this.DeleteItem();
    }
    protected virtual void LoadDataController()
    {
        if(this.dataController != null) return;
        this.dataController = FindAnyObjectByType<DataController>();
    }

    protected virtual void DeleteItem()
    {
        if(this.dataController._dataCheckArea.isPlayer)
        {
            if(this.objItem != null)
            {
                this.objItem.gameObject.SetActive(false);
            }
        }
    }
}