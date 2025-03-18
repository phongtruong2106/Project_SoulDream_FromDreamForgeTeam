using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : NewMonoBehaviour
{
    [SerializeField] protected OpenCutSceneNewGame openCutSceneNewGame;
    public OpenCutSceneNewGame _openCutSceneNewGame => openCutSceneNewGame;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadOpenCutScenesNewGame();
    }
    private void LoadOpenCutScenesNewGame()
    {
        if(this._openCutSceneNewGame != null) return;
        this.openCutSceneNewGame = gameObject.GetComponentInChildren<OpenCutSceneNewGame>();
    }
}
