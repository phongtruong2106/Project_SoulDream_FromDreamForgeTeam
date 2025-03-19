using UnityEngine;

public class PZR2_Controller : NewMonoBehaviour
{
    [SerializeField] protected PZ_SteamPot pZ_SteamPot;
    public PZ_SteamPot _pz_SteamPot => pZ_SteamPot;
    [SerializeField] protected Animator animator;
    public Animator _Animator => animator;
    [SerializeField] protected PZ_Door pZ_Door;
    public PZ_Door _pZ_Door => pZ_Door;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPZDoor();
        this.LoadPZSteamPot();
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = gameObject.GetComponentInChildren<Animator>();
    }

    protected virtual void LoadPZDoor()
    {
        if(this.pZ_SteamPot != null) return;
        this.pZ_SteamPot = FindAnyObjectByType<PZ_SteamPot>();
    }
    protected virtual void LoadPZSteamPot()
    {
        if(this.pZ_Door != null) return;
        this.pZ_Door = gameObject.GetComponentInChildren<PZ_Door>();
    }
}