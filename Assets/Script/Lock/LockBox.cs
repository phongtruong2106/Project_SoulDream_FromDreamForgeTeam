using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBox : DataGame
{
    [SerializeField] protected Animator animator;
    [SerializeField] private bool isOpenBox = false;
    [SerializeField] private bool isBoolChange;
    //[SerializeField] private bool IsSave;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }
    protected override void Start()
    {
        this.isBoolChange = false;
      //  this.IsSave = true;
    }
    private void Update() {
        this.CheckAfterLockOpe();
        this.OpenBox();
        this.ChangeDataBool();
       //this.OpenBoxData();
         this.SaveData();
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
    }   
    protected virtual void CheckAfterLockOpe()
    {
        if(LockManager.Instance.isAfterOpenLock)
        {
            this.isOpenBox = true;
            //this.dataController._dataPuzzel.isPuzzelLockBox = true;
        }
    }

    protected virtual void OpenBox()
    {
        if(this.isOpenBox)
        {
            animator.SetTrigger("IsBoxOpen");
           // this.SaveData();
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
        if(!this.dataController._dataDoor.isDataSaved && this.dataController._dataCheckArea.isPlayer)
        {
            this.dataSaveManager._PuzzelDataNew.IsPuzzelLockBox = this.isOpenBox;   
           // this.IsSave = false;
        }
    }
}

