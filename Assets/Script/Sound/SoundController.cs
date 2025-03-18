using UnityEngine;

public class SoundController : NewMonoBehaviour
{   
    [SerializeField] protected SoundManager soundManager;
    public SoundManager _soundManager => soundManager;
    [SerializeField] protected AudioMixerController audioMixerController;
    public AudioMixerController _AudioMixerController => audioMixerController;
    [SerializeField] protected VideoCutScene videoCutScene;
    public VideoCutScene _VideoCutScene => videoCutScene;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundManager();   
        this.LoadAudioMixerController();
        this.LoadVideoCutScene();
    }
    private void LoadSoundManager()
    {
        if(this.soundManager != null)   return;
        this.soundManager = gameObject.GetComponentInChildren<SoundManager>();  
    }

    private void LoadVideoCutScene()
    {
        if(this.videoCutScene != null) return;
        this.videoCutScene = FindAnyObjectByType<VideoCutScene>();
    }
    private void LoadAudioMixerController()
    {
        if(this.audioMixerController != null) return;
        this.audioMixerController =  gameObject.GetComponentInChildren<AudioMixerController>();
    }
}