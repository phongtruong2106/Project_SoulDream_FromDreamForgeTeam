using UnityEngine;

public class EnemyLookedPlayer : Enemy
{
    [SerializeField] protected float viewDistance = 10.0f; 
    public float viewAngle = 45.0f; 
    [SerializeField] private Transform coneOrigin;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask detectionLayerMask;
    [SerializeField] private string playerTag = "Player"; 
    [SerializeField] protected Transform objPlayer;
    protected bool isLookedPlayer = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }
    protected override void Update()
    {
        this.CheckForPlayer();
        this.FollowPlayer();
    }
    private void CheckForPlayer()
    {
        isLookedPlayer = false; 
        Collider[] playersInRange = Physics.OverlapSphere(coneOrigin.position, viewDistance, playerLayerMask);
        foreach (var player in playersInRange)
        {
            if (player.CompareTag(playerTag))
            {
                Vector3 directionToPlayer = (player.transform.position - coneOrigin.position).normalized;
                float angleToPlayer = Vector3.Angle(coneOrigin.forward, directionToPlayer);

                if (angleToPlayer < viewAngle / 2)
                {
                    if (Physics.Raycast(coneOrigin.position, directionToPlayer, out RaycastHit hit, viewDistance, detectionLayerMask))
                    {
                        if (hit.collider.CompareTag(playerTag))
                        {
                            isLookedPlayer = true;
                        }
                    }
                }
            }
        }
    }
    protected virtual void FollowPlayer()
    {
        if(this.isLookedPlayer)
        {
            enemyController.PianoController._notificationPiano.IsNotification = false;
            enemyController._enemyMovement.objectPos = objPlayer;
            enemyController._enemyMovement.MoveTowardsPlayer();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Matrix4x4 cubeTransform = Matrix4x4.TRS(coneOrigin.position, coneOrigin.rotation, Vector3.one);
        Gizmos.matrix = cubeTransform;
        Gizmos.DrawFrustum(Vector3.zero, viewAngle, viewDistance, 0.0f, 1.0f);
    }
}