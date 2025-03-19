using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
public class OpenCutScenes : NewMonoBehaviour
{
    [SerializeField] protected string TestText;
    [SerializeField] protected DataManager dataManager;
    [SerializeField] protected bool IsPlay;
    [SerializeField] protected VideoPlayer videoPlayer;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected VideoClip videoClip;
    [SerializeField] protected SO_CutScenes sO_CutScenes;
    
    protected override void Start()
    {
        this.IsPlay = false;
        videoPlayer.playOnAwake = false;
        this.videoPlayer.clip = sO_CutScenes.GetVideoClip();
        this.uIController._uiCutScenes.gameObject.SetActive(false);
         videoPlayer.loopPointReached += OnVideoEnd;

    }
    protected override void ResetValue()
    {
        base.ResetValue();
        
    }
    protected virtual void Update()
    {
     
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataManager();
        this.LoadUIController();
    }
    private void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }
    protected virtual void LoadDataManager()
    {
        if(this.dataManager != null) return;
        this.dataManager = FindAnyObjectByType<DataManager>();
    }
    public void OpenCutScene()
    {
        if(videoPlayer != null)
        {
            videoPlayer.Play();             
        }
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video đã kết thúc!");
        videoPlayer.playOnAwake = false;
         if (uIController != null && uIController._uiCutScenes != null)
        {
            uIController._uiCutScenes.gameObject.SetActive(false);
          //  this.IsPlay = false;
        }
    }
}