using Unity.Mathematics;
using UnityEngine;

public class CameraController : NewMonoBehaviour
{
    [SerializeField] public GameObject targetDefaul;
    [SerializeField] public GameObject targetPlayer;
    public GameObject _targetPlayer => targetPlayer;
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected Vector3 targetRotationAngles;
    [SerializeField] public float defaultZoom;
    public float _defaultZoom => defaultZoom;
    [SerializeField] public float zoom;
    [SerializeField] protected float zOffset;
    public float xOffset;
    public float yOffset;
    public float xRosOffset;
    public float yRosOffset;
    
    public float followSpeed = 1;
    public float defaultxOffset;
    public float defaultyOffset;
    public float defaulFollowSpeed = 1;

    [SerializeField] protected Quaternion targetRotation;
    protected override void Start()
    {
        base.Start();
        zoom = defaultZoom;
        xOffset = defaultxOffset;
        yOffset = defaultyOffset;
        followSpeed = defaulFollowSpeed;
        targetDefaul = targetPlayer;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.loadPlayerCharacter();
    }

    protected void Update()
    {
        this.Position();
        this.Rotation();
    }

    protected virtual void Position()
    {
        if(this.targetPlayer != null)
        {
            targetPosition = new Vector3(targetDefaul.transform.position.x + xOffset, targetDefaul.transform.position.y + yOffset, zoom);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        
    }

    protected virtual void Rotation()
    {
        if(this.targetPlayer != null)
        {
            targetRotation = Quaternion.Euler(targetDefaul.transform.rotation.x + xRosOffset, targetDefaul.transform.rotation.y + yRosOffset, targetDefaul.transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
    }
}