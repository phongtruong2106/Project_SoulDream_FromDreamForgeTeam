using UnityEngine;

public class LoadDataVolumePlayAble : SoundDataMain
{
    [SerializeField] protected SoundController soundController;
   

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundController();
    }

    protected override void Start()
    {
        base.Start();
        this.LoadData();
    }
    private void LoadSoundController()
    {
        if(this.soundController != null) return;
        this.soundController = gameObject.GetComponentInParent<SoundController>();
    }

    private void LoadData()
    {
        float savedVolume = PlayerPrefsManager.LoadFloat(VolumeKey, defaultVolume);
        this.soundController._AudioMixerController._audioMixer.SetFloat("Music", Mathf.Log10(savedVolume) * 20);
        this.soundController._VideoCutScene._VideoPlayer.SetDirectAudioVolume(0, savedVolume);
    }
}