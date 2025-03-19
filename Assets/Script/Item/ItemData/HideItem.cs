using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideItem : NewMonoBehaviour
{
    [SerializeField] protected LoadDataController loadDataController;
    public bool isBoolChange;
    protected override void Start()
    {
        base.Start();
        this.isBoolChange = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataController();
    }
    protected virtual void LoadDataController()
    {
        if(this.loadDataController != null) return;
        this.loadDataController = FindAnyObjectByType<LoadDataController>();
    }
    protected virtual void HideObj()
    {
        gameObject.SetActive(false);
    }
}
