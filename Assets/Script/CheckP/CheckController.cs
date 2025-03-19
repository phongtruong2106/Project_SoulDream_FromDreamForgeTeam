using UnityEngine;

public class CheckController : NewMonoBehaviour
{
    [SerializeField] protected CheckP checkP;
    public CheckP _checkP => checkP;
    [SerializeField] protected CheckP2 checkP2;
    public CheckP2 _checkP2 => checkP2;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCheckP();
        this.LoadCheckP2();
    }

    private void LoadCheckP()
    {
        if(this.checkP != null) return;
        this.checkP = gameObject.GetComponentInChildren<CheckP>();
    }

    private void LoadCheckP2()
    {
        if(this.checkP2 != null) return;
        this.checkP2 = gameObject.GetComponentInChildren<CheckP2>();
    }
}