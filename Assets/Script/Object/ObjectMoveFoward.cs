using UnityEngine;

public class ObjectMoveFoward : ObjectMovement
{
    [Header("ObjectMoveFoward")]
    [SerializeField] protected CharacterController controller;
    public CharacterController _characterController => controller;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] private SO_ObjMoveFoward sO_ObjMoveFoward;
    private float inputMagnitude;
    protected bool isFlipped = false;
    protected Vector3 previousMoveDirection;
    public bool isInput = true;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterController();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
    }
    protected virtual void LoadCharacterController()
    {
        if(this.controller != null) return;
        this.controller = transform.parent.GetComponent<CharacterController>();
       
    }

    private void Update() {
        this.Move();
        this.IsMove();
        this.CheckCanDetected();
        this.ChangedAnimation();    

    }

    public virtual void IsMove()
    {
        if(moveX == 0 && moveZ == 0) 
        {
            isMovel = false;
        }
        else
        {
            isMovel = true;
        }
    }
    

    protected virtual void Move()
    {
        if(this.isInput)
        {
            isStrain = Physics.CheckSphere(transform.position, groundCheckDistance, strainMask);
            if(!this.isStrain)
            {
                isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
            }            
            if(isStrain && velocity.y < 0 || isGrounded && velocity.y < 0)
            {
                velocity.y = -4f;
            }
            moveX = Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01f ? 0f : Input.GetAxis("Horizontal");
            moveZ = Mathf.Abs(Input.GetAxis("Vertical")) < 0.01f ? 0f : Input.GetAxis("Vertical");
            inputMagnitude = Mathf.Clamp01(moveDirection.magnitude) / 2;
            moveDirection = new Vector3(moveX, 0, moveZ);
            if(isMove)
            {
                if(isGrounded || this.isStrain)
                {
                    if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                    {   
                        Walk();
                    }
                    else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                    {
                        if(!this.isStrain)
                        {
                            Run();
                            inputMagnitude *= 6f; 
                        }
                        
                    }

                    moveDirection *= moveSpeed;  
                    isGrounded = true;
                }
                if(this.controller != null)
                {
                    controller.Move(moveDirection * Time.deltaTime);
                    velocity.y += gravity *  Time.deltaTime;
                    controller.Move(velocity * Time.deltaTime);
                }
                
                this.HandleRotation();
            }
        }
    }
    private void ChangedAnimation()
    {
        if (this.isGrounded)
        {
            playerControler._animator.SetTrigger("Land");
            playerControler._animator.SetFloat("Speed", inputMagnitude, 0.1f, Time.deltaTime);
        }
        else
        {
            playerControler._animator.SetBool("isMoving", false);
        }

        if (moveDirection == Vector3.zero) 
        {
            Idle();
            playerControler._animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }
    }

    protected virtual void Run()
    {
        moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, Time.deltaTime * sO_ObjMoveFoward.acceleration);  
    }
    protected virtual void Idle()
    {
        inputMagnitude = 0;
        moveSpeed = 0;
        playerControler._animator.SetBool("isMoving", false);
    }
    protected virtual void Walk()
    {
        moveSpeed = walkSpeed;
    }
    protected virtual void HandleRotation()
    {
        Vector3 positionToLookAT;
        positionToLookAT.x = moveDirection.x;
        positionToLookAT.y = 0.0f;
        positionToLookAT.z = moveDirection.z;
        Quaternion currentRotation = transform.parent.rotation;
        if(moveX != 0 || moveZ != 0)
        {
            playerControler._animator.SetBool("isMoving", true);
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAT);
            transform.parent.rotation  =  Quaternion.Slerp(currentRotation, targetRotation, sO_ObjMoveFoward.rotationSpeed * Time.deltaTime);
        }
    }
    protected virtual void CheckCanDetected()
    {
        if(moveDirection.x != 0 || moveDirection.z != 0)
        {
            playerControler._objectLedgeDetection.canDetected = false;
        }
    }
    public virtual bool IsRunning()
    {
        return inputMagnitude > 0.7f && Input.GetKey(KeyCode.LeftShift);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckDistance);
    }
}