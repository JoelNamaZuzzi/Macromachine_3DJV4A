using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Sound", order = 1)]
public class SoundObjectClass : ScriptableObject
{
    public string objName = "Sound";
    public AudioClip mySound;
    public float priority;
}
