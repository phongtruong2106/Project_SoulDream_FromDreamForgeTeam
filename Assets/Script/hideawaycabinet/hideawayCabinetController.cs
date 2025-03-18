using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideawayCabinetController : NewMonoBehaviour
{
    [SerializeField] protected CheckPlayer checkPlayer;
    public CheckPlayer _checkPlayer => checkPlayer;
    [SerializeField] private Animator animator;
    public Animator _animator => animator;
    [SerializeField] protected UIController uIController;
    public UIController _uIController => uIController;
    [SerializeField] protected EventAnimationCabinet eventAnimationCabinet;
    public EventAnimationCabinet _eventAnimationCabinet => eventAnimationCabinet;
    [SerializeField] protected CheckPlayerInSite checkPlayerInSite;
    public CheckPlayerInSite _checkPlayerInSite => checkPlayerInSite;

    protected override void Start()
    {
        base.Start();
        this.checkPlayer = gameObject.GetComponentInChildren<CheckPlayer>();
        this.checkPlayerInSite = gameObject.GetComponentInChildren<CheckPlayerInSite>();
    }
    protected void Update()
    {
        this.checkPlayer = gameObject.GetComponentInChildren<CheckPlayer>();
        this.checkPlayerInSite = gameObject.GetComponentInChildren<CheckPlayerInSite>();
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadUIController();
        this.LoadEventAnimationCabinet();
    }
    protected virtual void LoadEventAnimationCabinet()
    {
        if(this.eventAnimationCabinet != null) return;
        this.eventAnimationCabinet = transform.parent.GetComponent<EventAnimationCabinet>();
        Debug.Log(transform.name + ": LoadEventAnimationCabinet()", gameObject);
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    }
}
