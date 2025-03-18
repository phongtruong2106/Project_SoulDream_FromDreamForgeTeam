using UnityEngine;

public class SFX_StepFootEnemy : SoundMain
{
    public void sfx_StepFootEnemy1()
    {
        if (this.soundController._soundManager._SO_StepFootEnemy.stepFootEnemy1.Count > 0)
            {
                int randomIndex = Random.Range(0, this.soundController._soundManager._SO_StepFootEnemy.stepFootEnemy1.Count);
                AudioClip selectedClip = this.soundController._soundManager._SO_StepFootEnemy.stepFootEnemy1[randomIndex];
                this._Source.PlayOneShot(selectedClip);
            }
    }
    public void sfx_StepFootEnmey2()
    {
        if(this._Source != null && !_Source.isPlaying)
        {
            this._Source.PlayOneShot(this.soundController._soundManager._SO_StepFootEnemy.stepFootEnemy2);  
        }
        
    }
}