using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;


    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master_Volume", Mathf.Log10(volume)*20f);
    }


    public void SetSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("SoundFX_Volume", Mathf.Log10(volume) * 20f);
    }


    public void SetMusiqueVolume(float volume)
    {
        audioMixer.SetFloat("Musique_Volume", Mathf.Log10(volume) * 20f);
    }
}
