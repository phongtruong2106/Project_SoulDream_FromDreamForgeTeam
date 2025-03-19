using Unity.VisualScripting;
using UnityEngine;

public class SoundEnemyController : NewMonoBehaviour
{
    [SerializeField] protected SFX_AttackEnemy sFX_AttackEnemy;
    public SFX_AttackEnemy _SFX_AttackEnemy => sFX_AttackEnemy;
    [SerializeField] protected SFX_StepFootEnemy sFX_StepFootEnemy;
    public SFX_StepFootEnemy _StepFootEnemy => sFX_StepFootEnemy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSFXAtkEnemy();
        this.LoadSFXStepFoot();
    }

    private void LoadSFXAtkEnemy()
    {
        if(this._SFX_AttackEnemy != null) return;
        this.sFX_AttackEnemy = gameObject.GetComponentInChildren<SFX_AttackEnemy>();    
    }

    private void LoadSFXStepFoot()
    {
        if(this.sFX_StepFootEnemy != null) return;
        this.sFX_StepFootEnemy = gameObject.GetComponentInChildren<SFX_StepFootEnemy>();
    }
}