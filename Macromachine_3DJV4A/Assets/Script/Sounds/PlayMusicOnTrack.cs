using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnTrack : MonoBehaviour
{
    public AudioClip TrackClip;
    public AudioSource Sauce;

    private void Start()
    {
        if (SoundManager.Instance.musicPlay == true)
        {
            Sauce.clip = TrackClip;
            Sauce.Play();
        }
    }
}
