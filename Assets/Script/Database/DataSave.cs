using System.IO;
using UnityEngine;

public class DataSave : NewMonoBehaviour
{
  
    [SerializeField] protected DataController dataController;
    protected string filePath;
    [SerializeField] protected string FileSave;
    public bool isDataSaved = false;
    [SerializeField] protected DataSaveManager dataSaveManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataController();
        this.LoadDataSaveManager();
        
    }
    protected override void Start()
    {
        this.SetupDataFile();
    }
    protected virtual  void Update()
    {
        
    }
    private void LoadDataSaveManager()
    {
        if(this.dataSaveManager != null) return;
        this.dataSaveManager = FindAnyObjectByType<DataSaveManager>();
    }
    protected virtual void LoadDataController()
    {
        if (this.dataController != null) return;
        this.dataController = gameObject.GetComponentInParent<DataController>();
    }

    protected virtual void SaveData()
    {

    }
    protected virtual void SetupDataFile()
    {
        filePath = Path.Combine(Application.persistentDataPath, FileSave);
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }
}