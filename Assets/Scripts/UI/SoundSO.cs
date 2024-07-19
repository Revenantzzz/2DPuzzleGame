using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound SO")]
public class SoundSO : ScriptableObject 
{
    [Header("Move Sounds")]
    public List<AudioClip> moveClips;

    [Header("Pick Sounds")]
    public List<AudioClip> pickClips;

    [Header("Cut Sounds")]
    public List <AudioClip> cutClips;
}
