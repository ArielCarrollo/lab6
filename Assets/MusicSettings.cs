using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterAudio;
    [SerializeField] private Slider MusicAudio;
    [SerializeField] private Slider SFXAudio;
    [SerializeField] private AudioSettings audioSettings; 

    void Start()
    {
        MasterAudio.value = audioSettings.masterVolume;
        MusicAudio.value = audioSettings.musicVolume;
        SFXAudio.value = audioSettings.sfxVolume;
    }

    public void SetMasterVolume()
    {
        float volume = MasterAudio.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        audioSettings.masterVolume = volume;
    }

    public void SetMusicVolume()
    {
        float volume = MusicAudio.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        audioSettings.musicVolume = volume; 
    }

    public void SetSFXVolume()
    {
        float volume = SFXAudio.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        audioSettings.sfxVolume = volume; 
    }
}

