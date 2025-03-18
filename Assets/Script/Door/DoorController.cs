using UnityEngine;

public class DoorController : NewMonoBehaviour
{
    [SerializeField] protected Animator  animator;
    public Animator _animator => animator;
    [SerializeField] protected KeyHolder keyHolder;
    public KeyHolder _KeyHolder => keyHolder;
    [SerializeField] protected CheckDoorEnemy checkDoorEnemy;
    public CheckDoorEnemy _CheckDoorEnemy => checkDoorEnemy;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadKeyHolder();
        this.LoadCheckDoorEnemy();
    }
    protected virtual void LoadKeyHolder()
    {
        if(this.keyHolder != null) return;
        this.keyHolder = FindAnyObjectByType<KeyHolder>();
    }

    protected virtual void LoadCheckDoorEnemy()
    {
        if(this.checkDoorEnemy != null) return;
        this.checkDoorEnemy = gameObject.GetComponentInChildren<CheckDoorEnemy>();
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    }
    
}