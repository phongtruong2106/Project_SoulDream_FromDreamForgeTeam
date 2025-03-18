using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutSceneTimeLine : DataGame
{
    private bool isDataLoadChange;
    private bool isNewGame;
    private bool isFlagPlayCut;
    [SerializeField] private PlayableDirector playableDirector;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayableDirector();
    }
    protected override void Start()
    {
        base.Start();
        this.isDataLoadChange = true;
        this.isFlagPlayCut = true;
    }

    protected void Update()
    {
        this.ChangeData();
        this.RunCutScenesTimeLine();
    }

    private void LoadPlayableDirector()
    {
        if(this.playableDirector != null) return;
        this.playableDirector = gameObject.GetComponentInChildren<PlayableDirector>();
    }
    private void ChangeData()
    {
        if(this.isDataLoadChange)
        {
            this.isNewGame = this.loadDataController._LoadDoor.Door1;
            this.isDataLoadChange = false;
        }
    }

    private void RunCutScenesTimeLine()
    {
        if(this.isFlagPlayCut)
        {
            if(this.isNewGame)
            {
                this.playableDirector.Pause();
            }
            else
            {
                this.playableDirector.Play();
            }
            this.isFlagPlayCut = false;
        }
        
    }
}
