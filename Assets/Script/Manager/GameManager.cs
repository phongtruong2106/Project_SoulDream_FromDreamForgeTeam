using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NewMonoBehaviour
{
    [SerializeField] protected HideMouse hideMouse;
    public HideMouse _hideMouse => hideMouse;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHideMouse();
    }

    protected virtual void LoadHideMouse()
    {
        if(this.hideMouse != null) return;
        this.hideMouse = GetComponentInChildren<HideMouse>();
        Debug.Log(transform.name + ": LoadHideMouse()", gameObject);
    }


}
