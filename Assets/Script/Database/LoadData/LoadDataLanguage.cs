using UnityEngine;

public class LoadDataLanguage : LoadDataParent
{
    public bool isVN;
    public bool isEN;

    protected override void Start()
    {
        base.Start();
        this.LoadLanguageDataManager();
    }

    private void LoadLanguageDataManager()
    {
        LanguageData languageData = this.dataManager._LoadData.LoadLanguageData();
        if(languageData != null)
        {
            this.isVN = languageData.isVN;
            this.isEN = languageData.isEN;
        }
    }

}