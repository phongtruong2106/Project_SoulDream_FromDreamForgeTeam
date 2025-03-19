using UnityEngine;

public class Pz_TextBlood : DataGame
{
    [SerializeField] protected Renderer rend;
    [SerializeField] protected float IntAlpha = -10f; // Bắt đầu từ -10
    [SerializeField] protected float targetAlpha = -0.4f; // Kết thúc tại -0.4
    [SerializeField] protected float duration = 60f; // Thời gian thay đổi
    [SerializeField] protected PZ_SteamPot pZ_SteamPot;
    [SerializeField] protected GameObject Obj_SavePoint;
    private float elapsedTime = 0f;
    private bool isBoolChange;
    private bool isShow;
    private bool canShow;
    private bool isChange;

    protected override void Start()
    {
        base.Start();
        this.canShow = false;
        this.isChange = false;
        if(this.Obj_SavePoint != null)
        {
            this.Obj_SavePoint.gameObject.SetActive(false);
        }
    }

    protected void FixedUpdate()
    {
        this.StartHideTextBlood();
    }

    private void Update()
    {
        this.ChangeDataBool();
        this.ShowText();
    }

    protected virtual void StartHideTextBlood()
    {
        if (pZ_SteamPot.isPos)
        {
            HideTextFload();
            if(this.Obj_SavePoint != null)
            {
                this.Obj_SavePoint.gameObject.SetActive(true);
                this.pZ_SteamPot.hasChangedParticleFog = true;
            }
            
        }
    }

    protected virtual void HideTextFload()
    {
        if (elapsedTime < duration)
        {
            this.SaveData();
            elapsedTime += Time.fixedDeltaTime;
            IntAlpha = Mathf.Lerp(-10f, targetAlpha, elapsedTime / duration); 
            rend.material.SetFloat("_Contrast", IntAlpha);
        }
    }
    
    protected virtual void ShowText()
    {
        if (this.isShow)
        {
            if (!this.canShow)
            {
                rend.material.SetFloat("_Contrast", -10f);
                this.canShow = true;
            }
        }
    }

    private void ChangeDataBool()
    {
        if (!this.isBoolChange)
        {
            this.isShow = this.loadDataController._LoadPuzzel.IsPuzzelPotSteam;
            this.pZ_SteamPot.isPos = this.loadDataController._LoadPuzzel.IsPuzzelPotSteam;
            this.isBoolChange = true;
        }
    }

    private void SaveData()
    {
        if (!this.isChange)
        {
            this.dataSaveManager._PuzzelDataNew.IsPuzzelPotSteam = pZ_SteamPot.isPos;
            this.isChange = true;
        }
    }
}
