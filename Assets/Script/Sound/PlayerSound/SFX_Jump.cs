using UnityEngine;

public class SFX_Jump : SoundMain
{
    public void sfx_Jump()
    {
        if(this._Source != null && !_Source.isPlaying)
        {
                 this._Source.PlayOneShot(this.soundController._soundManager._SFXJump.audioClip);  
        }
        
    }
}