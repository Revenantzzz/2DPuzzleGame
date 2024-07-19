using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction<Vector2> OnPlayerMove ;
    public event UnityAction OnActionUndo;
    public event UnityAction OnPlayerInteract;

    public void OnMove(InputAction.CallbackContext context)
    {      
        if(context.started)
        {
            OnPlayerMove?.Invoke(context.ReadValue<Vector2>());
        }      
    }
    public void OnUndo(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnActionUndo?.Invoke();
        }          
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnPlayerInteract?.Invoke();
        }          
    }
}
