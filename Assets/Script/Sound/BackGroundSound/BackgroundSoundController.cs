using UnityEngine;

public class BackgroundSoundController : NewMonoBehaviour
{
    [SerializeField] protected BackGroundSound backGroundSound;
    public BackGroundSound _backGroundSound => backGroundSound;
    [SerializeField] protected ChangeMusic changeMusic;
    public ChangeMusic _changeMusic => changeMusic;
    
    [SerializeField] protected DL_CheckController  dL_CheckController;
    public DL_CheckController _DL_CheckController => dL_CheckController;
    [SerializeField] protected CheckEnemySitDown checkEnemySitDown;
    public CheckEnemySitDown _checkEnemySitDown => checkEnemySitDown;
    [SerializeField] protected PZ_SteamPot pZ_SteamPot;
    public PZ_SteamPot _pZ_SteamPot => pZ_SteamPot;

    protected override void LoadComponents()
    {
        base.LoadComponents(); 
        this.LoadBackgroundSound();
        this.LoadChangedMusic();
        this.LoadDLCheckController();
        this.LoadCheckEnemySitDown();
        this.LoadPZSteamPot();
    }

    private void LoadPZSteamPot()
    {
        if(this.pZ_SteamPot != null) return;
        this.pZ_SteamPot = FindAnyObjectByType<PZ_SteamPot>();
    }

    private void LoadCheckEnemySitDown()
    {
        if(this.checkEnemySitDown != null) return;
        this.checkEnemySitDown = FindAnyObjectByType<CheckEnemySitDown>();   
    }

    private void LoadDLCheckController()
    {
        if(this.dL_CheckController != null) return;
        this.dL_CheckController = FindAnyObjectByType<DL_CheckController>();
    }
    private void LoadBackgroundSound()
    {
        if(this.backGroundSound != null) return;
        this.backGroundSound = gameObject.GetComponentInChildren<BackGroundSound>();
    }

    private void LoadChangedMusic()
    {
        if(this.changeMusic != null) return;
        this.changeMusic = gameObject.GetComponentInChildren<ChangeMusic>();
    }
}