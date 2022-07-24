using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool musicPlay = true;
    public bool soundPlay = true;
    public static SoundManager Instance;
    public float musicVolume=1.0f;
    public float soundVolume=1.0f;
    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }

    }

    public void PlayMusic(SoundObjectClass zique, AudioSource sauce)
    {
        if (musicPlay)
        {
            sauce.clip = zique.mySound;
            sauce.volume = zique.priority*musicVolume;
            sauce.Play();
            
        }
    }
    
    public void PlaySoundEffect(SoundObjectClass sound, AudioSource sauce)
    {
        if (soundPlay&& !sauce.isPlaying)
        {
            sauce.clip = sound.mySound;
            sauce.volume = sound.priority*soundVolume;
            sauce.Play();
            
        }
    }
    
    public void StopMusic(AudioSource sauce)
    {
        sauce.Stop();
    }
    public void StopSound(AudioSource sauce)
    {
        //Debug.Log("playing");
        sauce.Stop();
    }

    public void LoadSounds()
    {
        SoundsData data = SaveSounds.LoadSound();
        musicPlay = data.isMusic;
        soundPlay = data.isSound;
        musicVolume = data.musicVol;
        soundVolume = data.soundVol;
    }

    public void SaveTheSound()
    {
        SaveSounds.SaveSoundParam(this);
    }
}
