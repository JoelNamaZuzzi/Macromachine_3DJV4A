using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool musicPlay = true;
    public bool soundPlay = true;
    public static SoundManager Instance;
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
            sauce.volume = zique.priority;
            sauce.Play();
            
        }
    }
    
    public void PlaySoundEffect(SoundObjectClass sound, AudioSource sauce)
    {
        if (soundPlay&& !sauce.isPlaying)
        {
            sauce.clip = sound.mySound;
            sauce.volume = sound.priority;
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
}
