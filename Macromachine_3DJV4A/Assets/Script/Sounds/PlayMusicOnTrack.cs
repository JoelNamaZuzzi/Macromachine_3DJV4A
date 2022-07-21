using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnTrack : MonoBehaviour
{
    public SoundObjectClass trackMusic;
    public AudioSource ZiqueSauce;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(trackMusic, ZiqueSauce);
    }
}
