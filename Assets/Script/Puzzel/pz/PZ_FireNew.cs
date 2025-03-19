using UnityEngine;

public class PZ_FireNew : PuzzelNew
{
    [Header("Pz Fire")]
    protected Vector3 targetScale = new Vector3(0.53f, 0.53f, 0.53f);
    protected Vector3 initialScale = new Vector3(0.1f, 0.1f, 0.1f);
    protected float scaleDuration = 2f;
    private float currentScaleTime = 0f;
    [SerializeField] protected GameObject ObjectFire;
    public bool isFire = false;

    protected override void Update()
    {
        base.Update();
        this.PZFire();
    }


    protected virtual void PZFire()
    {
        if(this.isPuzzel)
        {
            this.isFire = true;
            // // this.ObjectFire.transform.localScale = Vector3.Lerp(this.transform.localScale, targetScale, scalingSpeed * Time.deltaTime);
            // if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
            // {       
            //     this.ObjectFire.transform.localScale = this.targetScale;
            //     this.isPuzzel = false;
            // }
            if (currentScaleTime < scaleDuration)
            {
                currentScaleTime += Time.deltaTime;
                float scaleProgress = currentScaleTime / scaleDuration;
                ObjectFire.transform.localScale = Vector3.Lerp(initialScale, targetScale, scaleProgress);
            }
        }
        
    }
}