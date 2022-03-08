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

    public void PlayMusic(AudioClip clip, AudioSource sauce)
    {
        sauce.clip = clip;
        sauce.Play();
    }
}
