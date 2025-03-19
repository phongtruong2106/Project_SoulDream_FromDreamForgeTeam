using UnityEngine;

public class Pz_WaterNew : PuzzelNew
{
    [Header("PZ Water")]
    public bool IsWater = false;
    [SerializeField] protected ItemSO itemSO;
    [SerializeField] protected float fill;
    [SerializeField] protected float fillSpeed = 0.001f;
    [SerializeField] protected float maxFill = 1f;  
    [SerializeField] protected Renderer rend;
    [SerializeField] protected Item item;
    protected override void Update()
    {
        base.Update();
        this.PZWater();
        this.ScaleWater();
    }
    protected virtual void PZWater()
    {
        if(this.isPuzzel)
        {
            isPuzzel = true;
           // this.IsWaterPot = true;
            this.IsWater = true;
        }
    }

    protected virtual void ScaleWater()
    {
        if(this.IsWater)
        {
            this.item._itemSO.itemType = ItemType.glassWaterFull;
            this.item._itemSO.itemName = "GlassWaterFull";
            if (fill < maxFill)
            {
                fill += fillSpeed * Time.deltaTime;
                rend.material.SetFloat("_Fill", fill);
            }
            this.isPuzzel = false;
            this.IsWater = false;
        }
        
    }
}