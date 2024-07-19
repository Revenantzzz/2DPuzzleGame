using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanInteractObj : MonoBehaviour
{
    [SerializeField]List<GameObject> gameObjectList = new List<GameObject>();
    private void Start()
    {
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
            yield return new WaitForSeconds(.5f);
        }      
        InteractComplete();
    }
    public virtual void InteractComplete()
    {
        this.gameObject.SetActive(false);
    }
}
