using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : UI
{
    [SerializeField] protected PlayerControler playerControler;
    protected override void Start()
    {
        base.Start();
        playerControler._inventory.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    protected virtual void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    
    protected override void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if(child == Template) continue;
            Destroy(child.gameObject);
        }
   
    }
}
