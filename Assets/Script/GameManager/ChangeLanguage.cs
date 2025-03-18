using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : NewMonoBehaviour
{
   [SerializeField] protected SO_UISetting sO_UISetting;
    public SO_UISetting _sO_UISetting => sO_UISetting;

    protected override void Start()
    {
        base.Start();
        this.sO_UISetting.LoadFromPlayerPrefs();
       // this.UpdateLanguage();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.sO_UISetting.SelectedLanguageIndex = 0; // English
        this.sO_UISetting.SaveToPlayerPrefs();
    }

    public void UpdateLanguage()
    {
        if (this.sO_UISetting.IsEN)
        {
            Debug.Log("Language set to English");
        }
        else if (this.sO_UISetting.IsVN)
        {
            Debug.Log("Language set to Vietnamese");
        }
    }
}
