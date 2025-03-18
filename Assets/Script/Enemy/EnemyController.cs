using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : NewMonoBehaviour
{
    [SerializeField] protected  EnemyManager enemy;
    [SerializeField] protected EnemyCheckTouchPlayer enemyCheckTouchPlayer;
    public EnemyCheckTouchPlayer _enemyCheckTouchPlayer => enemyCheckTouchPlayer;
    [SerializeField] protected EnemyCheckPlayer enemyCheckPlayer;
    public EnemyCheckPlayer _enemyCheckPlayer => enemyCheckPlayer;
    public EnemyManager _enemy => enemy;
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement _enemyMovement => enemyMovement;
    [SerializeField] protected ObjectPickPlayer objectPickPlayer;
    public ObjectPickPlayer _objectPickPlayer => objectPickPlayer;
    [SerializeField] protected Animator animator;
    public Animator _animator => animator;   
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected PianoController pianoController;
    public PianoController PianoController => pianoController;
    [SerializeField] protected CheckEnemyMovement checkEnemyMovement;
    public CheckEnemyMovement _checkEnemyMovement => checkEnemyMovement;
    protected CheckEnemySitDown checkEnemySitDown;
    public CheckEnemySitDown _CheckEnemySitDown => checkEnemySitDown;
    [SerializeField] protected EnemyLookedPlayer enemyLookedPlayer;
    public EnemyLookedPlayer _enemyLookedPlayer => enemyLookedPlayer;
    //Update 8/2/2024
    [SerializeField] private EnemyAttack enemyAttack;
    public EnemyAttack _enemyAttack => enemyAttack;
    //Update 8/3/2024
    [SerializeField] protected EnemyTriggerAttack enemyTriggerAttack;
    public EnemyTriggerAttack _enemyTriggerAttack => enemyTriggerAttack;
    [SerializeField] protected EnemyEventAnimation enemyEventAnimation;
    public EnemyEventAnimation _enemyEventAnimation => enemyEventAnimation;    
    [SerializeField] protected CameraShake cameraShake;
    public CameraShake _cameraShake => cameraShake;
    [SerializeField] protected SoundController soundController;
    public SoundController _SoundController => soundController;
    [SerializeField] private SoundEnemyController soundEnemyController;
    public SoundEnemyController _SoundEnemyController => soundEnemyController;
    [SerializeField] protected CheckEnemyMovement_1 checkEnemyMovement_1;
    public CheckEnemyMovement_1 _CheckEnemyMovement_1 => checkEnemyMovement_1;
 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy();
        this.LoadEnemyMovement();
        this.LoadEnemyCheckPlayer();
        this.LoadEnemyCheckTouchPlayer();
        this.LoadObjectPickPlayer();
        this.LoadAnimation();
        this.LoadNavMeshAgent();
        //this.LoadPianoController();
       // this.LoadCheckEnemyMovement();
        this.LoadCheckEnemySitDown();
        this.LoadEnemyLookedPlayer();
        //Update 8/2/2024
        this.LoadEnemyAttack();
        //Update 8/3/2024
        this.LoadEnemyTriggerAttack();
        this.LoadEnemyEventAnimation();
        this.LoadCameraShake();
        this.LoadSoundEnemyController();
        this.LoadCheckEnemyMovementP1();

    }

    private void LoadCheckEnemyMovementP1()
    {
        if(this.checkEnemyMovement_1 != null) return;
        this.checkEnemyMovement_1 = FindAnyObjectByType<CheckEnemyMovement_1>();
    }

    private void LoadSoundEnemyController()
    {
        if(this.soundEnemyController != null) return;
        this.soundEnemyController = gameObject.GetComponentInChildren<SoundEnemyController>();
    }
    protected void Update()
    {
        checkEnemyMovement = GameObject.FindAnyObjectByType<CheckEnemyMovement>();
    }
    protected virtual void LoadPianoController()
    {
        if(this.pianoController != null) return;
        this.pianoController = FindAnyObjectByType<PianoController>();
    }
    protected virtual void LoadNavMeshAgent()
    {
        if(this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void LoadAnimation()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
    }

    protected virtual void LoadObjectPickPlayer()
    {
        if(this.objectPickPlayer != null) return;
        this.objectPickPlayer = transform.GetComponentInChildren<ObjectPickPlayer>();
    }

    protected virtual void LoadEnemy()
    {
        if(this.enemy != null) return;
        this.enemy = FindAnyObjectByType<EnemyManager>();
    }
    protected virtual void LoadEnemyCheckPlayer()
    {
        if(this.enemyCheckPlayer != null) return;
        this.enemyCheckPlayer = FindAnyObjectByType<EnemyCheckPlayer>();
    }

    protected virtual void LoadEnemyMovement()
    {
        if(this.enemyMovement != null) return;
        this.enemyMovement = transform.GetComponentInChildren<EnemyMovement>();
    }
    protected virtual void LoadEnemyCheckTouchPlayer()
    {
        if(this.enemyCheckTouchPlayer != null) return;
        this.enemyCheckTouchPlayer = FindAnyObjectByType<EnemyCheckTouchPlayer>();
    }

    protected virtual void LoadCheckEnemySitDown()
    {
        if(this.checkEnemySitDown != null) return;
        this.checkEnemySitDown = FindAnyObjectByType<CheckEnemySitDown>();
    }

    protected virtual void LoadEnemyLookedPlayer()
    {
        if(this.enemyLookedPlayer != null) return;
        this.enemyLookedPlayer = transform.GetComponentInChildren<EnemyLookedPlayer>();
    }

    //update 8/2/2024
      protected virtual void LoadEnemyAttack()
    {
        if(this.enemyAttack != null) return;
        this.enemyAttack = transform.GetComponentInChildren<EnemyAttack>();
    }

    protected virtual void LoadEnemyTriggerAttack()
    {
        if(this.enemyTriggerAttack != null) return;
        this.enemyTriggerAttack = transform.parent.GetComponentInChildren<EnemyTriggerAttack>();
    }

    protected virtual void LoadEnemyEventAnimation()
    {
        if(this.enemyEventAnimation != null) return;
        this.enemyEventAnimation = transform.parent.GetComponent<EnemyEventAnimation>();
    }

    protected virtual void LoadCameraShake()
    {
        if(this.cameraShake != null) return;
        this.cameraShake = FindAnyObjectByType<CameraShake>();
    }
}
