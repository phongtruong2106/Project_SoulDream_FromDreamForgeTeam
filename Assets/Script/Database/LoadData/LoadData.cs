using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : FilePath
{
    [SerializeField] protected DataManager dataManager;
    
    public bool IsDataNull;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataManager();
    }
    protected virtual void LoadDataManager()
    {
        if(this.dataManager != null) return;
        this.dataManager = gameObject.GetComponentInParent<DataManager>();
    }
    protected override void Start()
    {
        base.Start();
        this.LoadPositionDataLoadSetBool();
    }
    public Vector3 LoadPositionData()
    {
        
        if (File.Exists(positionFilePath))
        {
            string json = File.ReadAllText(positionFilePath);
            PositionData data = JsonUtility.FromJson<PositionData>(json);
            Vector3 loadedPosition = new Vector3(data.X, data.Y, data.Z);
            if(data != null || loadedPosition != null)
            {
                this.dataManager._DataIsLoaded._playerControler.transform.position = loadedPosition;
                Debug.Log($"Position data loaded: {data.X}, {data.Y}, {data.Z}");
                return new Vector3(data.X, data.Y, data.Z);
            }
            else
            {
                return Vector3.zero;
            }
        }
        else
        {
            return Vector3.zero;
        }
    }
    public string LoadSceneData()
    {
        if (File.Exists(sceneFilePath))
        {
            string json = File.ReadAllText(sceneFilePath);
            SceneData data = JsonUtility.FromJson<SceneData>(json);
            SceneManager.LoadScene(data.SceneName);
            return data.SceneName;
        }
        else
        {
            return string.Empty;
        }
    }
    public PuzzelData LoadPuzzelData()
    {
        if (File.Exists(puzzelFilePath))
        {
            string json = File.ReadAllText(puzzelFilePath);
            PuzzelData puzzelData = JsonUtility.FromJson<PuzzelData>(json);
            if(puzzelData != null)
            {
                Debug.Log($"Loaded puzzel data:\n" +
                        $"Piano: {puzzelData.isPuzzelPiano}, " +
                        $"LockBox: {puzzelData.isPuzzelLockBox}, " +
                        $"WaterGlass: {puzzelData.isWaterGlass}, " +
                        $"PotSteam: {puzzelData.isPuzzelPotSteam}, " +
                        $"Clock: {puzzelData.isPuzzelClock}, " +
                        $"Ear: {puzzelData.isPuzzelEar}");
                return puzzelData;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    public CutSceneData LoadCutSceneData()
    {
        if (File.Exists(CutScenesFilePath))
        {
            string json = File.ReadAllText(CutScenesFilePath);
            CutSceneData cutSceneData = JsonUtility.FromJson<CutSceneData>(json);
            if(cutSceneData != null)
            {
                Debug.Log($"Loaded cutscene data:\n" +
                      $"CutScene1: {cutSceneData.CutScene1}, " +
                      $"CutScene2: {cutSceneData.CutScene2}, " +
                      $"CutScene3: {cutSceneData.CutScene3}");

                return cutSceneData;
            }
            else
            {
                return null;
            }
            
        }
        else
        {
            return null;
        }
    }

    public DoorData LoadDoorData()
    {
        if (File.Exists(DoorFilePath))
        {
            string json = File.ReadAllText(DoorFilePath);
            DoorData doorData = JsonUtility.FromJson<DoorData>(json);
             if (doorData != null)
            {
                Debug.Log($"Loaded door data:\n" +
                        $"Door1: {doorData.Door1}, " +
                        $"Door2: {doorData.Door2}");
                return doorData;
            }
            else
            {
                return null;
            }
            
        }
        else
        {
            return null;
        }
    }
    public DialogueData LoadDialogueData()
    {
        if (File.Exists(DialogueFilePath))
        {
            string json = File.ReadAllText(DialogueFilePath);
            DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(json);
            if (dialogueData != null)
            {
                Debug.Log($"Loaded dialogue data:\n" +
                            $"Door1: {dialogueData.Dialogue_1}, " );
                return dialogueData;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
    public LanguageData LoadLanguageData()
    {
       if (File.Exists(LanguageFilePath))
        {
            string json = File.ReadAllText(LanguageFilePath);
            LanguageData languageData = JsonUtility.FromJson<LanguageData>(json);
            if (languageData != null)
            {
                Debug.Log($"Loaded door data:\n" +
                        $"IsEN: {languageData.isEN}, " +
                        $"ISVN: {languageData.isVN}");
                return languageData;
            }
            else
            {
                return null;
            }
            
        }
        else
        {
            return null;
        }
    }
    public void LoadPositionDataLoadSetBool()
    {
         if (File.Exists(positionFilePath))
        {
            string json = File.ReadAllText(positionFilePath);
            if (string.IsNullOrEmpty(json))
            {
                IsDataNull = true;
            }
            else
            {
                IsDataNull = false;
            }
        }
    }


   
}
