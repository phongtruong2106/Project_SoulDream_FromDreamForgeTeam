using UnityEngine;

public class LoadDataUIController : NewMonoBehaviour
{
    [SerializeField] protected LoadDataUILanguage loadDataUILanguage;
    public LoadDataUILanguage _loadDataUILanguage => loadDataUILanguage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataUILanguage();
    }

    private void LoadDataUILanguage()
    {
        if(this.loadDataUILanguage != null) return;
        this.loadDataUILanguage = gameObject.GetComponentInChildren<LoadDataUILanguage>();
    }
}