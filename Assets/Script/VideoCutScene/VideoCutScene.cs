using UnityEngine;
using UnityEngine.Video;

public class VideoCutScene : NewMonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    public VideoPlayer _VideoPlayer => videoPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVideoPlayer();
    }

    private void LoadVideoPlayer()
    {
        if(this.videoPlayer != null) return;
        this.videoPlayer = gameObject.GetComponent<VideoPlayer>();
    }
}