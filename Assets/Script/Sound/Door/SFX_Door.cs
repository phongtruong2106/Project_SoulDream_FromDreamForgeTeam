using UnityEngine;

public class SFX_Door : SoundMain
{
    public void sfx_Door()
    {
        if(this._Source != null && !_Source.isPlaying)
        {
            this._Source.PlayOneShot(this.soundController._soundManager._SO_Door.audioClip);  
        }
        
    }
}