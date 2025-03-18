using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackourSystems : NewMonoBehaviour
{
    [SerializeField] protected bool _isClimbObj;
    [SerializeField] protected bool _isActionState;
    [SerializeField] protected Vector3 _ObjPosition;
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected Animator animator;

    protected override void Start()
    {
        base.Start();

    }

    private void Update()
    {
        if(_isClimbObj)
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                StartCoroutine(ClimbAction());
            }
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Climb"))
        {
            animator.MatchTarget(_ObjPosition, transform.rotation, AvatarTarget.RightFoot, new MatchTargetWeightMask(new Vector3(0,1, 1), 0), 0.14f, 0.33f);
        }
    }

    IEnumerator ClimbAction()
    {
        animator.CrossFade("Climb", 0.2f);
        yield return null;

        _isActionState = true;
        animator.applyRootMotion = true;
        characterController.enabled = false;

        yield return new WaitForSeconds(animator.GetNextAnimatorStateInfo(0).length);

        _isActionState = false;
        animator.applyRootMotion = false;
        characterController.enabled = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.gameObject.transform.tag == "ClimbObj")
        {
            _isClimbObj = true;
            _ObjPosition = other.transform.gameObject.transform.GetComponent<Transform>().position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.gameObject.transform.tag == "ClimbObj")
        {
            _isClimbObj = false; 
        }
    }


}
