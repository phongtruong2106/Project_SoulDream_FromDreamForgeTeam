using UnityEngine;

public class UI_Controller_Setting : NewMonoBehaviour
{
    [SerializeField] protected GameManagerB gameManagerB;
    public GameManagerB _gameManagerB => gameManagerB;
    [SerializeField] protected AudioMixerController audioMixerController;
    public AudioMixerController _AudioMixerController => audioMixerController;
    [SerializeField] protected VideoCutScene videoCutScene;
    public VideoCutScene _VideoCutScene => videoCutScene;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameManagerB();
        this.LoadAudioMixerController();
        this.LoadVideoCutScene();
    }

    private void LoadVideoCutScene()
    {
        if(this.videoCutScene != null) return;
        this.videoCutScene = FindAnyObjectByType<VideoCutScene>();  
    }
    private void LoadAudioMixerController()
    {
        if(this.audioMixerController != null) return;
        this.audioMixerController = FindAnyObjectByType<AudioMixerController>();
    }
    
    protected virtual void LoadGameManagerB()
    {
        if(this.gameManagerB != null) return;
        this.gameManagerB = FindAnyObjectByType<GameManagerB>();
    }
}