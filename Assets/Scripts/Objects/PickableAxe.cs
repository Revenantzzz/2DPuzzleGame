using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableAxe : CanInteractObj
{
    public override void Interacted()
    {
        PlayerController.Instance.HasAxe = true;
        base.Interacted();
    }
}
