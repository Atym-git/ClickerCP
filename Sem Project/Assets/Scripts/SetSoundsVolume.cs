using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetSoundsVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;

    private const int _volumeMultiplayer = 20;

    private const string _masterVolume = "MasterVolume";
    private const string _SFXVolume = "SoundFXVolume";
    private const string _musicVolume = "MusicVolume";

    public void SetMainVolume(float sliderValue)
    {
        mainMixer.SetFloat(_masterVolume, Mathf.Log10(sliderValue) * _volumeMultiplayer);
    }
    public void SetSoundFXVolume(float sliderValue)
    {
        mainMixer.SetFloat(_SFXVolume, Mathf.Log10(sliderValue) * _volumeMultiplayer);
    }
    public void SetMusicVolume(float sliderValue)
    {
        mainMixer.SetFloat(_musicVolume, Mathf.Log10(sliderValue) * _volumeMultiplayer);
    }
}
