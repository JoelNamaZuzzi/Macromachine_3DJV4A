using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundsData
{
    public bool isMusic =true;
    public bool isSound =true;
    public float musicVol=1.0f;
    public float soundVol=1.0f;

    public SoundsData(SoundManager SM)
    {
        isMusic = SM.musicPlay;
        isSound = SM.soundPlay;
        musicVol = SM.musicVolume;
        soundVol = SM.soundVolume;
    }
}
