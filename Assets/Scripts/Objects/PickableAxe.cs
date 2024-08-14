using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableAxe : CanInteractObj, IPickableObject
{
    public override void Interacted()
    {
        PickedObject();
        PlaySound(soundSO.pickClips[0]);
        base.Interacted();
    }
    public void PickedObject()
    {
        PlayerController.Instance.AddPickableObject(this);
    }
}
