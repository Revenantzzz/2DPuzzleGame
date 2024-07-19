using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTree : CanInteractObj
{
    public static FinalTree Instance;
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
        if(!PlayerController.Instance.HasAxe)
        {
            return;
        }
        base.Interacted();
    }
    public override void InteractComplete()
    {
        base.InteractComplete();
        Time.timeScale = 0f;
        GameManager.Instance.LevelComplete();
    }
}
