using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Btn_Setting_LanguageOption : UI_Setting
{
    [SerializeField] private List<string> languageOptions = new List<string>();
    public bool previousIsEN;
    public bool previousIsVN;

    protected override void Start()
    {
        base.Start();
        this.ResetValue();

        var languageSetting = this.uI_Btn_Setting_Selected._gameManagerB._changeLanguage._sO_UISetting;
        languageSetting.LoadFromPlayerPrefs();

        this.dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        this.dropdown.value = languageSetting.SelectedLanguageIndex;
        this.dropdown.RefreshShownValue();

        previousIsEN = languageSetting.IsEN;
        previousIsVN = languageSetting.IsVN;
    }

    private void Update()
    {
        var languageSetting = this.uI_Btn_Setting_Selected._gameManagerB._changeLanguage._sO_UISetting;

        if (previousIsEN != languageSetting.IsEN ||
            previousIsVN != languageSetting.IsVN)
        {
            previousIsEN = languageSetting.IsEN;
            previousIsVN = languageSetting.IsVN;
        }
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        if (this.dropdown == null) return;

        this.dropdown.options.Clear();
        this.languageOptions.Clear();
        this.languageOptions.Add("English");
        this.languageOptions.Add("Vietnamese");

        foreach (string option in languageOptions)
        {
            this.dropdown.options.Add(new TMP_Dropdown.OptionData(option));
        }

        this.dropdown.value = 0;
        this.dropdown.RefreshShownValue();
    }

    private void OnDropdownValueChanged(int selectedIndex)
    {
        var languageSetting = this.uI_Btn_Setting_Selected._gameManagerB._changeLanguage._sO_UISetting;
        languageSetting.SelectedLanguageIndex = selectedIndex;
        languageSetting.SaveToPlayerPrefs();
    }

    private void OnDestroy()
    {
        if (this.dropdown != null)
        {
            this.dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
        }
    }
}
