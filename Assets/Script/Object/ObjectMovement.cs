using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : NewMonoBehaviour
{
    
    [Header("Object Movement")]
    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 velocity;
    public bool isGrounded;
    [SerializeField] protected bool isStrain;
    public bool isGroundCheck;
    public bool isMove = true;
    public bool isMovel = true;

    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected LayerMask strainMask;
    [SerializeField] protected float gravity;
   
    protected float moveX;
    public float _moveX => moveX;
    protected float moveZ;
    public float _moveZ => moveZ;
    protected bool isCrouch = true;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.walkSpeed = 2;
        this.runSpeed = 7;
        this.isMove = true;
        this.groundCheckDistance = 0.2f;
        this.gravity = -9.81f;
    }

}
