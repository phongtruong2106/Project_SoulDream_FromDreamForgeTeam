using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_Set_Volume : SoundDataMain
{
    [SerializeField] private Slider slider1;
    [SerializeField] private UI_Controller_Setting uI_Controller_Setting;
    [SerializeField] private float volumeSetUp;
    public float volume;
    public float Sfx;
    public float music;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
        this.LoadUIControllerSetting();
    }

    protected override void Start()
    {
        this.LoadSavedVolume();
    }
    private void LoadUIControllerSetting()
    {
        if(this.uI_Controller_Setting != null) return;
        this.uI_Controller_Setting = FindAnyObjectByType<UI_Controller_Setting>();
    }

    private void LoadSlider()
    {
        if(this.slider1 != null) return;
        this.slider1 = gameObject.GetComponentInChildren<Slider>();
    }

    private void LoadSavedVolume()
    {
        float savedVolume = PlayerPrefsManager.LoadFloat(VolumeKey, defaultVolume);
        slider1.value = savedVolume;
        this.SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        volume = slider1.value;
        this.uI_Controller_Setting._AudioMixerController._audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        if(this.uI_Controller_Setting._VideoCutScene._VideoPlayer != null)
        {
            this.uI_Controller_Setting._VideoCutScene._VideoPlayer.SetDirectAudioVolume(0, volume);
        }
        
        PlayerPrefsManager.SaveFloat(VolumeKey, volume);
    }
    
    // public void SetSFXVolume()
    // {
    //     Sfx = slider2.value;
    //     this.uI_Controller_Setting._AudioMixerController._audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    //     PlayerPrefsManager.SaveFloat(sfxKey, Sfx);
    // }
} 