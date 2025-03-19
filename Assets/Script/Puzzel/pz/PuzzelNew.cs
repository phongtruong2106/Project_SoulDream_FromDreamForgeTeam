using System;
using UnityEngine;

public class PuzzelNew : NewMonoBehaviour
{
    public bool isPuzzel;
    public Transform pos_Obj;
    [SerializeField] protected PlayerControler playerControler;
    public bool isPZItem;
     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();

    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
    }

    protected virtual void Update()
    {
        //

    }
}