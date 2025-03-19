using UnityEngine;

public class PlayerSoundController : NewMonoBehaviour
{
    [SerializeField] private SFX_FootStep sFX_FootStep;
    public SFX_FootStep _SFX_FootStep=> sFX_FootStep;
    [SerializeField] private SFX_Jump sFX_Jump;
    public SFX_Jump _SFX_Jump => sFX_Jump;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFootStepSound();
        this.LoadJumpSound();
    }

    private void LoadJumpSound()
    {
        if(this.sFX_Jump != null) return;
        this.sFX_Jump = gameObject.GetComponentInChildren<SFX_Jump>();
    }
    private void LoadFootStepSound()
    {
        if(this.sFX_FootStep != null) return;
        this.sFX_FootStep = gameObject.GetComponentInChildren<SFX_FootStep>();
    }
}