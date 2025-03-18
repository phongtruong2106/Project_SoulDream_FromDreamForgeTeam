using System.Collections;
using System.IO;
using UnityEngine;

public class DataCheckArea : DataGame
{
    [SerializeField] protected SO_dataSave sO_DataSave;
    public bool isPlayer = false;
    protected override void Start()
    {
        base.Start();
        this.DeletedObject();
    }
    private void Update(){
         StartCoroutine(DeactivateParentAfterDelay());
         this.DeletedObject();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
         if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
             this.isPlayer = false;
        }
    }

     private IEnumerator DeactivateParentAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        if (isPlayer)
        {
            this.sO_DataSave.IsCheck = true;
            transform.parent.parent.gameObject.SetActive(false);
        }
    }

    private void DeletedObject()
    {
        if(this.sO_DataSave.IsCheck)
        {
            Destroy(transform.parent.parent.gameObject);
        }
    }
}