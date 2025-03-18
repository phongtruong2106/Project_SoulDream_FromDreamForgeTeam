using System.Collections;
using UnityEngine;

public class PZ_SteamPot : DataGame
{
    [SerializeField] protected ParticleSystem FogPS;
    [SerializeField] protected GameObject FogObj;
    [SerializeField] protected PZ_FireNew pZ_FireNew;
    [SerializeField] protected PZ_PotWater pZ_PotWater;
    [SerializeField] protected PZ_PotItem pZ_PotItem;
    [SerializeField] protected Notification notification;
    protected Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f);  // Full size target
    protected Vector3 initialScale = new Vector3(0f, 0f, 0f);  // Small initial size
    protected float scaleDuration = 20f;  // Time it takes to scale
    private float currentScaleTime = 0f;
    protected bool isFog = false;
    protected float startScaleX = 0.1f; 
    protected float targetScaleX = 36.3f;
    private float scaleXTime = 0f; // Track time for scale.x transition
    private float scaleXDuration = 10f; // Time to scale shape.x
    public bool isPos = false;
    private bool hasScaledFogObject = false;
    public bool hasChangedParticleFog = false;
    [SerializeField] protected GameObject Obj_SavePoint;
   // private bool isBoolChange;
   // private bool isChange;

    private void Update()
    {
        this.Pz_Steam();
      //  this.FogPosition();
    }
    protected override void Start()
    {
        base.Start();
        this.hasChangedParticleFog = false;
        this.hasScaledFogObject = false;
       // this.isChange = false;
      //  this.isBoolChange = false;
    }
    protected virtual void Pz_Steam()
    {  
        if(pZ_FireNew.isFire && pZ_PotWater.IsWaterPot && pZ_PotItem.isPotItem)
        { 
            if(!this.hasScaledFogObject)
            {
                this.ChangeFobSizeScale();
                this.ScaleFogObjectOverTime();
                this.ChangeParticleFog();
            }
        }
    }


    protected void ScaleFogObjectOverTime()
    {
        if(FogObj != null)
        {
                if (currentScaleTime < scaleDuration)
                {
                    currentScaleTime += Time.deltaTime;
                    float scaleProgress = currentScaleTime / scaleDuration;
                    FogObj.transform.localScale = Vector3.Lerp(initialScale, targetScale, scaleProgress);
                }            
        }
    }

    protected void ChangeParticleFog()
    {
        if (FogPS != null)
        {
                ParticleSystem.ForceOverLifetimeModule forceModule = FogPS.forceOverLifetime;
                ParticleSystem.ShapeModule shapeModule = FogPS.shape;
                float startForceY = 1.55f;
                float targetForceY = 6.49f;
                float startPositionY = 1.55f;
                float targetPositionY = 6.49f;
                float transitionDuration = 5f;
                if (currentScaleTime < transitionDuration)
                {
                    currentScaleTime += Time.deltaTime;
                    float progress = currentScaleTime / transitionDuration;
                    float scaleProgress = currentScaleTime / scaleDuration;
                    forceModule.y = new ParticleSystem.MinMaxCurve(Mathf.Lerp(startForceY, targetForceY, progress));
                    Vector3 shapePosition = shapeModule.position;
                    shapePosition.y = Mathf.Lerp(startPositionY, targetPositionY, progress);
                    shapeModule.position = shapePosition;
                    FogObj.transform.localScale = Vector3.Lerp(initialScale, targetScale, scaleProgress);
                    isFog = true;
                }
        }
    }

    protected virtual void ChangeFobSizeScale()
    {     
        if (isFog && FogPS != null)
        {   
            
                ParticleSystem.ShapeModule shapeModule = FogPS.shape;
                ParticleSystem.MainModule mainModule = FogPS.main;
                float startSizeX = 5f;  
                float targetSizeX = 25f;
                if (scaleXTime < scaleXDuration)
                {
                    scaleXTime += Time.deltaTime;
                    // Calculate the progress for the scaling
                    float scaleProgress = scaleXTime / scaleXDuration;
                    Vector3 shapeScale = shapeModule.scale;
                    shapeScale.x = Mathf.Lerp(startScaleX, targetScaleX, scaleProgress);
                    shapeModule.scale = shapeScale;
                    mainModule.startSizeX = Mathf.Lerp(startSizeX, targetSizeX, scaleProgress);
                    notification.IsNotification = true;
                    StartCoroutine(ChangePosAfterDelay(20f));
            }
        }
    }

    protected IEnumerator ChangePosAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ChangePos();
    }
    protected virtual void ChangePos()
    { 
        if(!this.hasChangedParticleFog)
        {
            ParticleSystem.ShapeModule shapeModule = FogPS.shape;
            float startPositionY = 1.55f;  
            float targetPositionY = 200f;   
            scaleXTime += Time.deltaTime;
            float scaleProgress = scaleXTime / scaleXDuration;
            Vector3 shapePosition = shapeModule.position;
            isPos = true;
            //this.SaveData();
            shapePosition.y = Mathf.Lerp(startPositionY, targetPositionY, scaleProgress);
            shapeModule.position = shapePosition;
            
            
            
        }
        this.hasScaledFogObject = true;
    }
    
}