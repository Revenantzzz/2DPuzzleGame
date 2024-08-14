using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTree : CanInteractObj, ICompletingLevelObject
{
    public static FinalTree Instance;

    List<IPickableObject> PickableObjects => PlayerController.Instance.PickedObjectList;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public override void Interacted()
    {
        bool check = false;
        foreach(IPickableObject obj in PickableObjects)
        {
            if(obj is PickableAxe)
            {
                check = true;   
            }
        }
        if(!check)
        {
            return;
        }
        base.Interacted();
        PlaySound(soundSO.InteractClips[0]);
    }
    public override void CompleteInteract()
    {
        base.CompleteInteract();     
        CompleteLevel();
    }
    public void CompleteLevel()
    {
        GameManager.Instance.LevelComplete();
    }
}
