using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    

	public void SetVolume (float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }
}
