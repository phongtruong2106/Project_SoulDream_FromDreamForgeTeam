using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : NewMonoBehaviour
{
    [SerializeField] protected String nameScene;
    [SerializeField] protected DataManager dataManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataManager();
    }
    protected virtual void LoadDataManager()
    {
        if(this.dataManager != null) return;
        this.dataManager = FindAnyObjectByType<DataManager>();
    }
    public virtual void LoadScene()
    {
        SceneManager.LoadScene(nameScene);
    }
}