using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CanPushObj : MonoBehaviour
{
    private float interactDistance = 1f;
    [SerializeField] private LayerMask objLayer;

    private RaycastHit2D[] hit;

    public bool Pushed(Vector2 movement)
    {
        if(!Blocked(movement))
        {
            transform.position += (Vector3)movement;
            return true;
        }       
        return false;
    }
    private bool Blocked(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            hit = Physics2D.RaycastAll(transform.position, direction, interactDistance, objLayer);
            if (hit.Count() > 1)
            {
                return true;
            }
        }
        return false;
    }
}
