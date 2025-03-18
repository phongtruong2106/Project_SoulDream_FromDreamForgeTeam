using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : NewMonoBehaviour
{
    [Header("Player Controller")]
    public static PlayerControler instance;
    [SerializeField] protected ObjectMovement objectMovement;
    public ObjectMovement _objectMovement => objectMovement;
    [SerializeField] protected ObjectMoveFoward objectMoveFoward;
    public ObjectMoveFoward _objectMoveFoward => objectMoveFoward;
    [SerializeField] protected ObjectLedgeClimb objectLedgeClimb;
    public ObjectLedgeClimb _objectLedgeClimb => objectLedgeClimb;
    [SerializeField] protected ObjectLedgeDetection objectLedgeDetection;
    public ObjectLedgeDetection _objectLedgeDetection => objectLedgeDetection;
    [SerializeField] protected ObjectPushDetected objectPushDetected;
    public ObjectPushDetected _objectPushDetected => objectPushDetected;
    [SerializeField] protected Inventory inventory;
    public Inventory _inventory => inventory;
    [SerializeField] protected ObjectClimbingStairs objectClimbingStairs;
    public ObjectClimbingStairs _objectClimbingStairs => objectClimbingStairs;
    [SerializeField] protected ObjectStairsDetected objectStairsDetected;
    public ObjectStairsDetected _objectStairsDetected => objectStairsDetected;
    [SerializeField] protected Animator animator;
    public Animator _animator => animator;   
    [SerializeField] protected ObjectCrouch objectCrouch;
    public ObjectCrouch _objectCrouch => objectCrouch;
    [SerializeField] protected ObjectDie objectDie;
    public ObjectDie _objectDie => objectDie;
    [SerializeField] protected CharacterController characterController;
    public CharacterController _characterController => characterController;
    [SerializeField] protected PlayerSoundController playerSoundController;
    public PlayerSoundController _playerSoundController => playerSoundController;
    [SerializeField] private SoundController soundController;
    public SoundController _soundController => soundController;
    [SerializeField] protected CheckController checkController;
    public CheckController _CheckController => checkController;
    [SerializeField] protected ItemEventNew itemEventNew;
    public ItemEventNew _itemEventNew => itemEventNew;
  
    protected override void Awake()
    {
        base.Awake();
        if(PlayerControler.instance != null) Debug.LogError("Only 1 GameControler allow to ");
        PlayerControler.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectMovement();
        this.LoadObjectLedgeClimb();
        this.LoadObjectLedgeDetection();
        this.LoadObjectPushDetected();
        this.LoadObjectMoveFoward();
        this.LoadInventory();
        this.LoadObjectClimbingStairs();
        this.LoadObjectStairsDetected();
        this.LoadAnimator();
        this.LoadObjectCrouch();
        this.LoadPlayerSoundController();
        this.LoadSoundController();
        this.LoadCheckController();
        this.LoadItemEventNew();    
    }

    private void LoadItemEventNew()
    {
        if(this.itemEventNew != null) return;
        this.itemEventNew = gameObject.GetComponentInParent<ItemEventNew>();
    }
    private void LoadCheckController()
    {
        if(this.checkController != null) return;
        this.checkController = FindAnyObjectByType<CheckController>();
    }
    private void LoadSoundController()
    {
        if(this.soundController != null) return;
        this.soundController = FindAnyObjectByType<SoundController>();
    }
    private void LoadPlayerSoundController()
    {
        if(this.playerSoundController != null) return;
        this.playerSoundController = gameObject.GetComponentInChildren<PlayerSoundController>();
    }
    protected virtual void LoadObjectMovement()
    {
        if(this.objectMovement != null) return;
        this.objectMovement = gameObject.GetComponentInChildren<ObjectMovement>();
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = gameObject.GetComponentInChildren<Animator>();
        
    }
    protected virtual void LoadObjectMoveFoward()
    {
        if(this.objectMoveFoward != null) return;
        this.objectMoveFoward = gameObject.GetComponentInChildren<ObjectMoveFoward>();
    }

    protected virtual void LoadObjectLedgeClimb()
    {
        if(this.objectLedgeClimb != null) return;
        this.objectLedgeClimb = gameObject.GetComponentInChildren<ObjectLedgeClimb>();
    }

    protected virtual void LoadObjectLedgeDetection()
    {
        if(this.objectLedgeDetection!= null) return;
        this.objectLedgeDetection = gameObject.GetComponentInChildren<ObjectLedgeDetection>();
    }

    protected virtual void LoadObjectPushDetected()
    {
        if(this.objectPushDetected != null) return;
        this.objectPushDetected = gameObject.GetComponentInChildren<ObjectPushDetected>();
    }

    protected virtual void LoadObjectCrouch()
    {
        if(this.objectCrouch != null) return;
        this.objectCrouch = gameObject.GetComponentInChildren<ObjectCrouch>();
    }
    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = FindAnyObjectByType<Inventory>();
    }
    protected virtual void LoadObjectClimbingStairs()
    {
        if(this.objectClimbingStairs != null) return;
        this.objectClimbingStairs = FindAnyObjectByType<ObjectClimbingStairs>();
    }
    protected virtual void LoadObjectStairsDetected()
    {
        if(this.objectStairsDetected != null) return;
        this.objectStairsDetected  = FindAnyObjectByType<ObjectStairsDetected>();
    }
}