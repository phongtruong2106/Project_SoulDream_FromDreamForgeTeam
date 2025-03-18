using UnityEngine;

public class SFX_AttackEnemy : SoundMain
{
    public void sfx_AtkEnemy1()
    {
        if(this._Source != null && !_Source.isPlaying)
        {  
            this._Source.PlayOneShot(this.soundController._soundManager._sO_SFXAttackEnemy.audioClip);  
        }
        
    }
}