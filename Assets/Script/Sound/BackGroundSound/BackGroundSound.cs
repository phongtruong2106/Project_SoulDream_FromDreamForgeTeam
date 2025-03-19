using System.Collections;
using UnityEngine;

public class BackGroundSound : SoundMain
{
    [SerializeField] private float playDuration = 67f;     // Thời gian phát nhạc bình thường
    [SerializeField] private float playNervous = 50f;      // Thời gian phát nhạc hồi hộp
    [SerializeField] private float pauseDuration = 60f;    // Thời gian im lặng
    [SerializeField] private float delayBeforeStart = 75f; // Thời gian chờ trước khi bắt đầu
    [SerializeField] private float fadeDuration = 2f;      // Thời gian chuyển đổi âm lượng
    [SerializeField] private float defaultVolume;    
    [SerializeField] private float mysteryPlayDuration = 360f; // Thời gian phát nhạc huyền bí
    [SerializeField] private BackgroundSoundController backgroundSoundController;

    [HideInInspector] public bool isAttacking = false;

    private Coroutine backgroundSoundCoroutine;

    public bool isNervous;
    public bool isMystery;
    public bool isNormal;

    private const string VolumeKey = "Volume"; // Key dùng để load volume từ PlayerPrefs

    protected override void Start()
    {
        base.Start();
        LoadVolumeFromSetting(); // Load âm lượng từ PlayerPrefs
        source.volume = 0;
        StartCoroutine(StartBackgroundSoundAfterDelay());
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBGSoundController();
    }

    private void LoadBGSoundController()
    {
        if (this.backgroundSoundController != null) return;
        this.backgroundSoundController = gameObject.GetComponentInParent<BackgroundSoundController>();
    }

    /// <summary>
    /// Load âm lượng từ PlayerPrefs
    /// </summary>
    private void LoadVolumeFromSetting()
    {
        float savedVolume = PlayerPrefsManager.LoadFloat(VolumeKey, defaultVolume);
        defaultVolume = savedVolume; // Cập nhật lại defaultVolume để fadeIn/fadeOut dùng
    }

    private IEnumerator StartBackgroundSoundAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        PlaySoundLoop();
    }

    private void PlaySoundLoop()
    {
        if (backgroundSoundCoroutine == null)
        {
            backgroundSoundCoroutine = StartCoroutine(PlayBackgroundSoundCoroutine());
        }
    }

    private IEnumerator PlayBackgroundSoundCoroutine()
    {
        while (true)
        {
            if (!isAttacking && source != null)
            {
                if (this.backgroundSoundController._changeMusic._isNervous) // Nhạc hồi hộp
                {
                    yield return PlaySound(this.soundController._soundManager._SFXsoundBackground.Sound_Background2, playNervous);
                }
                else if (this.backgroundSoundController._changeMusic._isMystery) // Nhạc huyền bí
                {
                    yield return PlaySound(this.soundController._soundManager._SFXsoundBackground.Sound_Background3, mysteryPlayDuration);
                }
                else if (this.backgroundSoundController._changeMusic._isNormal) // Nhạc bình thường
                {
                    yield return PlaySound(this.soundController._soundManager._SFXsoundBackground.Sound_Background1, playDuration);
                }
                else // Nếu không có trạng thái nào, giữ im lặng
                {
                    yield return new WaitForSeconds(pauseDuration);
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator PlaySound(AudioClip clip, float duration)
    {
        source.clip = clip;
        source.volume = 0;
        source.Play();
        yield return StartCoroutine(FadeIn()); 
        yield return new WaitForSeconds(duration - fadeDuration);
        yield return StartCoroutine(FadeOut());
        source.Pause();
        yield return new WaitForSeconds(pauseDuration);
    }

    /// <summary>
    /// FadeIn từ 0 đến defaultVolume (theo volume của setting)
    /// </summary>
    private IEnumerator FadeIn()
    {
        float startVolume = source.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(startVolume, defaultVolume, t / fadeDuration);
            yield return null;
        }

        source.volume = defaultVolume;
    }

    /// <summary>
    /// FadeOut từ defaultVolume về 0
    /// </summary>
    private IEnumerator FadeOut()
    {
        float startVolume = source.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        source.volume = 0;
    }
}
