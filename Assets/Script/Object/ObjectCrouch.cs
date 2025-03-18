using UnityEngine;

public class ObjectCrouch : NewMonoBehaviour
{
    [SerializeField] protected bool isCrouch = false;
    public bool _isCrouch => isCrouch;
    protected PlayerControler playerControler;
    private float lastControlClickTime = 0f;
    public bool isPlayerInSite = false;
    private bool isCrounhChange;
    public bool isCanCround = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }
    protected override void Start()
    {
        base.Start();
        this.isCrounhChange = true;
    }

    private void Update() {
        this.CheckInput();
        this.Crouch();
        this.ChangHeightCC();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
    }

    protected virtual void Crouch()
    {
        if(this.isCrouch)
        {
            playerControler._animator.SetBool("IsCrouch", true);
            this.playerControler._objectMovement.runSpeed = 1;
            this.playerControler._objectMovement.walkSpeed = 1;
        }
        else
        {
            playerControler._animator.SetBool("IsCrouch", false);
            this.playerControler._objectMovement.runSpeed = 7;
            this.playerControler._objectMovement.walkSpeed = 4;
        }
    }

    protected virtual void CheckInput()
    {
        
        if(!isPlayerInSite)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                this.isCrouch = true;
                this.isCrounhChange = false;
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                this.isCrouch = false;
                this.isCrounhChange = false;
            }
            lastControlClickTime = Time.time;
        }
    }
        

    private void ChangHeightCC()
    {
        if(!this.isCrounhChange)
        {
            if(this.isCrouch)
            {
                this.playerControler._characterController.height = 1.44f;
                this.isCrounhChange = true;
                
            }
            else
            {
                this.playerControler._characterController.height = 1.49f;
                this.isCrounhChange = true;
            }
        }
        
    }
    
}