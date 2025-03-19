using UnityEngine;

public class EventDoor : NewMonoBehaviour
{
    [SerializeField] protected DoorController doorController;

    protected void Update()
    {
        this.IsOpenDoor();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDoorController();
    }
    protected virtual void LoadDoorController()
    {
        if(this.doorController != null) return;
        this.doorController = gameObject.GetComponentInParent<DoorController>();
    }
 
    protected virtual void IsOpenDoor()
    {
        if(this.doorController._KeyHolder.isOpen) 
        {
            this.doorController._CheckDoorEnemy.gameObject.SetActive(false);
        }
    }
}