using UnityEngine;

public class Pz_Clock_Controller : NewMonoBehaviour
{
    [SerializeField] protected PZ_Clock pZ_Clock;
    public PZ_Clock _pz_Clock => pZ_Clock;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPZClock();
    }
    protected virtual void LoadPZClock()
    {
        if(this.pZ_Clock != null) return;
        this.pZ_Clock = gameObject.GetComponentInChildren<PZ_Clock>();
    }

}