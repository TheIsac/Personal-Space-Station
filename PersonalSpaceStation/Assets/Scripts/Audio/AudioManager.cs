using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    void Awake() {
        FindAudioManager();
        InstantiateSounds();
    }

    /// <summary>
    /// If a audiomanager already exists in the scene, this one will be destroyed.
    /// </summary>
    void FindAudioManager()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Instantiates all the sounds in a foreach loop.
    /// </summary>
    void InstantiateSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            var newMixerGroup = s.mixerGroup;

            if (newMixerGroup == null)
            {
                newMixerGroup = mixerGroup;
            }

            s.source.outputAudioMixerGroup = newMixerGroup;
        }
    }

    /// <summary>
    /// This function is called from other scripts in order to play the sound clips.
    /// </summary>
    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        //s.source.spatialBlend = s.spatialBlend;

        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

}