using UnityEngine;

public class LoadCutScene : LoadDataParent
{
    public bool CutScene1;
    public bool CutScene2;
    public bool CutScene3;

    protected override void Start()
    {
        base.Start();
        this.LoadCutScenesDataFromManager();
    }

    protected virtual void LoadCutScenesDataFromManager()
    {
        CutSceneData cutSceneData = this.dataManager._LoadData.LoadCutSceneData();
        if(cutSceneData != null)
        {
            this.CutScene1 = cutSceneData.CutScene1;
            this.CutScene2 = cutSceneData.CutScene2;
            this.CutScene3 = cutSceneData.CutScene3;
             Debug.Log("CutScenes data loaded into LoadCutscenes.");
        }
    }
}