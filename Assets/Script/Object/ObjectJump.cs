using UnityEngine;

public class ObjectJump : NewMonoBehaviour
{
    [SerializeField] private PlayerControler playerControler;
    [SerializeField] private bool isJumping;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    [SerializeField] private SO_ObjJump sO_ObjJump;
    private float lastJumpTime = -2f;
    private float longJumpStartTime; 
    private bool isLongJumping;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    private void LoadPlayerController()
    {
        if (this.playerControler != null) return;
        this.playerControler = gameObject.GetComponentInParent<PlayerControler>();
    }

    protected override void Start()
    {
        base.Start();
        this.isJumping = false;
        this.isLongJumping = false;
    }

    private void Update()
    {
        this.Jump();
        this.IsGrounded();
        this.CheckLongJumpTimer();
    }

    protected virtual void Jump()
    {
        if (!playerControler._objectCrouch._isCrouch && !isJumping && Time.time - lastJumpTime >= sO_ObjJump.jumpCooldown)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (playerControler._objectMoveFoward.IsRunning())
                {         
                    LongJump();
                }
                else
                {
                    NormalJump();
                }
            }
        }
    }


    private void NormalJump()
    {
        this.playerControler._animator.SetBool("isJumping", true);
        this.playerControler._objectMoveFoward.velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        isJumping = true;
        lastJumpTime = Time.time;
        isLongJumping = false;
    }

    private void LongJump()
    {
        this.playerControler._animator.SetTrigger("isJumping");

        Vector3 longJumpDirection = playerControler._objectMoveFoward.moveDirection.normalized;
        this.playerControler._objectMoveFoward.velocity = new Vector3(
            longJumpDirection.x * sO_ObjJump.longJumpForce,
            Mathf.Sqrt(jumpHeight * -2 * gravity),
            longJumpDirection.z * sO_ObjJump.longJumpForce
        );
        isJumping = true;
        lastJumpTime = Time.time;
        isLongJumping = true;
        longJumpStartTime = Time.time; 
       
    }

    private void CheckLongJumpTimer()
    {
        if (isLongJumping && Time.time - longJumpStartTime >= sO_ObjJump.TimeJump)
        {
            Vector3 currentVelocity = this.playerControler._objectMoveFoward.velocity;
            this.playerControler._objectMoveFoward.velocity = new Vector3(0f, currentVelocity.y, 0f);
            isLongJumping = false;
        }
    }
    private void IsGrounded()
    {
        if (this.playerControler._objectMoveFoward.isGrounded)
        {
            this.playerControler._animator.SetBool("IsJumpDown", true);
            this.playerControler._animator.SetBool("isJumping", false);
            isJumping = false;
        }
        else if(!this.playerControler._objectMoveFoward.isGrounded)
        {
            this.playerControler._animator.SetBool("isJumping", true);
            this.playerControler._animator.SetBool("IsJumpDown", false);
            isJumping = true;
        }
    }

}
