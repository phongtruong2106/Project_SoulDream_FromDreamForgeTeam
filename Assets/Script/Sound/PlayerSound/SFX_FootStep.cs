using UnityEngine;

public class SFX_FootStep : SoundMain
{
    public void sfx_FootStepWoodFloor()
    {
        if(this._Source != null && !_Source.isPlaying)
        {
            if(this.playerControler._objectMovement.isGrounded)
            {
                int randomIndex = Random.Range(0, this.soundController._soundManager._SFXsoundFootSteep.AC_FS_WoodFloor.Count);
                AudioClip selectedClip = this.soundController._soundManager._SFXsoundFootSteep.AC_FS_WoodFloor[randomIndex];
                this._Source.PlayOneShot(selectedClip);
            }
           
        }
        
    }
    public void sfx_FootStepRunWoodFloor()
    {
        if(this._Source != null)
        {
            if(this.playerControler._objectMovement.isGrounded)
            {
                 int randomIndex = Random.Range(0, this.soundController._soundManager._SFXsoundFootSteep.AC_FS_WoodFloor.Count);
                AudioClip selectedClip = this.soundController._soundManager._SFXsoundFootSteep.AC_FS_WoodFloor[randomIndex];
                this._Source.PlayOneShot(selectedClip);
            }
           
        }
        
    }
}