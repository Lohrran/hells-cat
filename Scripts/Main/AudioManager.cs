using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }
   

    void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy (gameObject);
			return;
		}

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        Play("Music");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source.mute = false;
            }

            else
            {
                s.source.mute = true;
            }
        }
    }

    public void PlayAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.mute = false;
        }
    }
}
