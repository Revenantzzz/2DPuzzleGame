using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CanInteractObj : MonoBehaviour
{
    [SerializeField]List<GameObject> gameObjectList = new List<GameObject>();
    [SerializeField] protected SoundSO soundSO;
    protected AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        this.gameObject.SetActive(true);
        foreach (GameObject obj in gameObjectList)
        {
            obj.SetActive(true);
        }
    }
    public virtual void Interacted()
    {
        StartCoroutine(Interacting());
    }
    IEnumerator Interacting()
    {
        foreach(GameObject obj in gameObjectList)
        {
            obj.SetActive(false);
            yield return new WaitForSeconds(.25f);
        }
        CompleteInteract();
    }
    public virtual void CompleteInteract()
    {
        this.gameObject.SetActive(false);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
