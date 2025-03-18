using UnityEngine;

public class ObjectCheckLiftPlayer : NewMonoBehaviour
{
    [SerializeField] protected bool isPlayer = false;
    public bool _isPlayer => isPlayer;

    protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) isPlayer = true;
        
    }

        
}