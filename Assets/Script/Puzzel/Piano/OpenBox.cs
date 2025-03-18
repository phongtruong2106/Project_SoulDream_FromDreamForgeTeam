using Unity.VisualScripting;
using UnityEngine;

public class OpenBox : DataGame
{
    private Animator animator;
    private Piano piano;
    private bool isOpenBox;
    [SerializeField]  private bool isBoolChange;
    private bool isChange;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPiano();
   
    }
    protected override void Start()
    {
        base.Start();
        this.isBoolChange = false;
        this.isChange = false;
    }
    private void Update() {
        this.IsOpenBox();
        this.Open();
        this.ChangeDataBool();  
    }
 
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
    }

    protected virtual void LoadPiano()
    {
        if(this.piano != null) return;
        this.piano = transform.parent.parent.GetComponent<Piano>();
    }


    public virtual void Open()
    {
        if(this.piano.IsPressed)
        {
            this.isOpenBox = true;
        }
       
    }
    protected virtual void IsOpenBox()
    {
        if(this.isOpenBox)
        {
            animator.SetTrigger("BoxOpen");
            this.SaveData();
        }
    }

    protected virtual void ChangeDataBool()
    {
        if(!this.isBoolChange)
        {
            this.isOpenBox = this.loadDataController._LoadPuzzel.IsPuzzelLockBox;
            this.isBoolChange = true;
        }
    }

    private void SaveData()
    {
        if(!this.isChange)
        {
            this.dataSaveManager._PuzzelDataNew.IsPuzzelPiano = isOpenBox;
            this.isChange = true;
        }
    }
}