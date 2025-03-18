using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PZ_Mouse : NewMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text_Mouse;
    public TextMeshProUGUI _text_Mouse => text_Mouse;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMP();
    }
    protected virtual void LoadTextMP()
    {
        if(this.text_Mouse != null) return;
        this.text_Mouse = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }


}
