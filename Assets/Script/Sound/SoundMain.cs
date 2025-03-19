using UnityEngine;

public class SoundMain : NewMonoBehaviour
{
    [SerializeField] protected AudioSource source;
    public AudioSource _Source => source;
    
    [SerializeField] protected SoundController soundController;
    public SoundController _soundController => soundController;
    [SerializeField] protected PlayerControler playerControler;
    public PlayerControler PlayerControler => playerControler;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
        this.LoadSoundController();
        this.LoadPlayerController();
    }
    private void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
    }
    private void LoadSoundController()
    {
        if(this.soundController != null) return;
        this.soundController = FindAnyObjectByType<SoundController>();
    }
    private void LoadAudioSource()
    {
        if(this.source != null) return;
        this.source = gameObject.GetComponent<AudioSource>();
    }
}