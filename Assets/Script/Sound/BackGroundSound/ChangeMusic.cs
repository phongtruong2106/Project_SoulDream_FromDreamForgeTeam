using UnityEngine;

public class ChangeMusic : NewMonoBehaviour
{  
    [SerializeField] private bool isNervous;
    public bool _isNervous => isNervous;
    [SerializeField] private bool  isMystery;
    public bool _isMystery => isMystery;
    [SerializeField] private bool  isNormal;
    public bool _isNormal => isNormal;
    [SerializeField] private BackgroundSoundController backgroundSoundController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBGSoundController();
    }

    private void LoadBGSoundController()
    {
        if(this.backgroundSoundController != null) return;
        this.backgroundSoundController = gameObject.GetComponentInParent<BackgroundSoundController>();
    }

    private void Update()
    {
        this.ChangeState();
    }
    protected void ChangeState()
    {
        if(this.backgroundSoundController._DL_CheckController._DL_Notification.Notifition)
        {
            this.isNervous = true;
            this.isNormal = false;
        }
        else if(this.backgroundSoundController._checkEnemySitDown.isSitDown)
        {
            this.isNormal = true;
            this.isNervous = false;
            this.backgroundSoundController._DL_CheckController._DL_Notification.Notifition = false;
        }
        else if(this.backgroundSoundController._pZ_SteamPot.isPos)
        {
            this.isNormal = false;
            this.isMystery = true;
        }
        else if(!this.backgroundSoundController._pZ_SteamPot.isPos)
        {
            this.isNormal = true;
            this.isMystery = false;
        }

    }
}