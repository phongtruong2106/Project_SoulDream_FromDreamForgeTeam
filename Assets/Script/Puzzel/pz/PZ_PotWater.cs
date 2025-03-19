using UnityEngine;

public class PZ_PotWater : PuzzelNew
{
    public bool IsWater = false;
    public bool IsWaterPot = false;
    [SerializeField] protected float fill;
    [SerializeField] protected float fillSpeed = 0.001f;
    [SerializeField] protected float maxFill = 1f;  
    [SerializeField] protected Renderer rend;

    protected override void Update()
    {
        this.isItem();
        this.ScaleWater();
    }
    protected virtual void isItem()
    {
        if(isPuzzel)
        {
            this.IsWaterPot = true;
            this.IsWater = true;
        }
    }
    protected virtual void ScaleWater()
    {
        if(this.IsWater)
        {
            if (fill < maxFill)
            {
                fill += fillSpeed * Time.deltaTime;
                rend.material.SetFloat("_Fill", fill);
            }
            this.isPuzzel = false;
           // this.IsWater = false;
        }
    }
}