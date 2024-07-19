using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundSO soundSO;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlayerController.Instance.OnMoving += Instance_OnMoving;
        PlayerController.Instance.OnCutting += Instance_OnCutting;
        PlayerController.Instance.OnPicking += Instance_OnPicking;
    }

    private void Instance_OnPicking()
    {
        audioSource.clip = soundSO.pickClips[0];
        audioSource.Play();
    }

    private void Instance_OnCutting()
    {
        audioSource.clip = soundSO.cutClips[0];
        audioSource.Play();
    }

    private void Instance_OnMoving()
    {
        audioSource.clip = soundSO.moveClips[0];
        audioSource.Play();
    }
    private void OnDisable()
    {
        PlayerController.Instance.OnMoving -= Instance_OnMoving;
        PlayerController.Instance.OnCutting -= Instance_OnCutting;
        PlayerController.Instance.OnPicking -= Instance_OnPicking;
    }
}
