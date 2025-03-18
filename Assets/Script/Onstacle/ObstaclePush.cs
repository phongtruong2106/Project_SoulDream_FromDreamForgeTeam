using Unity.VisualScripting;
using UnityEngine;

public class ObstaclePush : NewMonoBehaviour
{
    [SerializeField] protected float forceMagnitude;
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool turn = false;
    [SerializeField] protected PlayerControler playerControler;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerControler", gameObject);
    }

    private void Update() {
        this.CheckRaycast();
        this.IsLayAnimation();
    }
    protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
    {
            Rigidbody rigidbody = hit.collider.attachedRigidbody;
            if(rigidbody != null)
            {
                if(turn == true)
                {
                    rigidbody.isKinematic = false;
                    Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                    forceDirection.y = 0;
                    forceDirection.Normalize();
                    rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
                    
                }
                else
                {
                    rigidbody.isKinematic = true;
                }
            }
        
    }

    protected virtual void CheckRaycast()
    {
        if(playerControler._objectPushDetected.pushDetected)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                turn = true;
                animator.SetBool("isPush", true);
            }
            this.CheckMove();
        }
        else
        {
            turn = false;
        }
    }

    protected virtual void IsLayAnimation()
    {
        if(turn == false)
        {
            animator.SetBool("isPush", false);
        }
    }
    protected virtual void CheckMove()
    {
        if (playerControler._objectMovement.isMovel == false || playerControler._objectMovement.isGrounded == false)
        {
            animator.SetBool("isPush", false);
            turn = false;   
        }
    }
}
