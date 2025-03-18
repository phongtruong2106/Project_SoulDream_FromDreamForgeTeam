using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataScenes : DataSave
{
    public string NameScenes;
    protected override void Update()
    {
        this.SaveDataScenes();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSceneName();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.FileSave = "GameDataScenes.json";
    }
    private void LoadSceneName()
    {
        NameScenes = SceneManager.GetActiveScene().name;
    }

     protected virtual void SaveDataScenes()
    {
        if (this.dataController._dataCheckArea.isPlayer)
        {
            // Tạo đối tượng dữ liệu cảnh chứa tên của cảnh
            SceneData sceneData = new SceneData
            {
                SceneName = NameScenes
            };

            // Chuyển đổi đối tượng thành JSON
            string json = JsonUtility.ToJson(sceneData, true);
            File.WriteAllText(filePath, json);

            Debug.Log($"Scene data saved to {filePath}: {json}");
            isDataSaved = true;
        }
    }

}