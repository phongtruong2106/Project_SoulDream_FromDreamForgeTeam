using UnityEngine;

public class OpenCutSceneNewGame : OpenCutScenes
{
    protected override void Update()
    {
        base.Update();
        this.OpenCutScenes();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.TestText = "CutScenes";
    }
    private void OpenCutScenes()
    {
        if(this.dataManager._LoadData.IsDataNull)
        {
            if(!this.IsPlay)
            {
                 this.OpenCutScene();
                 this.uIController._uiCutScenes.gameObject.SetActive(true);
                 this.IsPlay = true;
            }
           
        }
    }
}