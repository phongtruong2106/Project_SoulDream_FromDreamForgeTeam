using UnityEngine;

public class ObjectCheckStain : NewMonoBehaviour
{
    [SerializeField] private  PlayerControler playerControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    private void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = gameObject.GetComponentInParent<PlayerControler>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stairs")
        {
          //  this.playerControler._objectMovement.isStrainCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Stairs")
        {
           // this.playerControler._objectMovement.isStrainCheck = false;F
        }
    }
}