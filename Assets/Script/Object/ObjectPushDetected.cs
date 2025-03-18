using UnityEngine;

public class ObjectPushDetected : NewMonoBehaviour
{
    [Header("ObjectPushDetected")]
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsGround;
    public bool pushDetected;
    
    private void Update() {
        this.checkCanPush();
    }
    protected virtual void checkCanPush()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, whatIsGround);
        pushDetected = colliders.Length > 0;
    }
    protected virtual void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}