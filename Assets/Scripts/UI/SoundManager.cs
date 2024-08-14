using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundSO soundSO;
    [SerializeField] List<CanInteractObj> canInteractObjectList;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlayerController.Instance.OnMoving += PlaySoundOnMoving;
    }

    private void PlaySoundOnMoving(Vector2 dir)
    {
        audioSource.clip = soundSO.moveClips[0];
        audioSource.Play();
    }
    private void OnDisable()
    {
        PlayerController.Instance.OnMoving -= PlaySoundOnMoving;
    }
}
