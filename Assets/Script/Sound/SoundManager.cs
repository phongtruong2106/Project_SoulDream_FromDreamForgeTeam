using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : NewMonoBehaviour
{
    [SerializeField] protected SO_SFXATKPlayer sO_SFXATKPlayer;
    public SO_SFXATKPlayer _sO_SFXATKPlayer  => sO_SFXATKPlayer;
    [SerializeField] protected SO_SFXFlipBook sO_SFXFlipBook;
    public SO_SFXFlipBook _SFXFlipBook => sO_SFXFlipBook;
    [SerializeField] protected SO_SFXJump sO_SFXJump;
    public SO_SFXJump _SFXJump => sO_SFXJump;
    [SerializeField] protected SO_SFXkey sO_SFXkey;
    public SO_SFXkey _SFXkey => sO_SFXkey;
    [SerializeField] protected SO_SFXOPENDOOR sO_SFXOPENDOOR;
    public SO_SFXOPENDOOR _SFXOPENDOOR => sO_SFXOPENDOOR;
    [SerializeField] protected SO_SoundFootStep sO_SoundFootStep;
    public SO_SoundFootStep _SFXsoundFootSteep => sO_SoundFootStep;
    [SerializeField] protected SO_SoundBackground sO_SoundBackground;
    public SO_SoundBackground _SFXsoundBackground => sO_SoundBackground;
    [SerializeField] protected SO_Door sO_Door;
    public SO_Door _SO_Door => sO_Door;
    [SerializeField] protected SO_StepFootEnemy sO_StepFootEnemy;
    public SO_StepFootEnemy _SO_StepFootEnemy => sO_StepFootEnemy;
    [SerializeField] protected SO_SFXAttackEnemy sO_SFXAttackEnemy;
    public SO_SFXAttackEnemy _sO_SFXAttackEnemy => sO_SFXAttackEnemy;
    
}
