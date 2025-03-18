using UnityEngine;

public class LoadDataUILanguage : LoadDataUI
{
    public bool isEN;
    public bool isVN;

    protected override void Start()
    {
        this.LoadData();
    }
    private void LoadData()
    {
        this.isVN = loadDataController._LoadDataLanguage.isVN;
        this.isEN = loadDataController._LoadDataLanguage.isEN;
    }
}