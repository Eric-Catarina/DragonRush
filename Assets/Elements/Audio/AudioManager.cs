using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [Header("--- Audio Manager ---")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("--- Clips ---")]

    [SerializeField] public AudioClip[] musicClips;

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

    public void MuteMaster(){
        audioMixer.SetFloat("MasterVolume", -80);
    }
    public void UnmuteMaster(){
        audioMixer.SetFloat("MasterVolume", 0);
    }



}
