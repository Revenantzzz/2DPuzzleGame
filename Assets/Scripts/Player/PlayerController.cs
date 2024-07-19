using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] LayerMask canPushLayer;
    PlayerInput playerInput;
    float interactDistance = 1f;   
    CanPushObj canPushObj;
    RaycastHit2D hitCanPushObj;
    RaycastHit2D hitCanInteractObj;
    CanInteractObj canInteractObj;
    public bool HasAxe { get; set; }

    public event UnityAction<CanInteractObj> OnObjectInteract;
    public event UnityAction OnCutting;
    public event UnityAction OnMoving;
    public event UnityAction OnPicking;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();  
        Instance = this;
        HasAxe = false;
    }
    private void Start()
    {
        playerInput.OnPlayerMove += HandleMovement;
        playerInput.OnActionUndo += HandleUndo;
        playerInput.OnPlayerInteract += HandleInteract;
    }
    private void Update()
    {
        //CheckFinalTree();
    }
    public void HandleMovement(Vector2 movement)
    {
        RunPlayerCommand(movement);
    }
    public void HandleUndo()
    {
        CommandInvoker.UndoCommand();
    }
    public void HandleInteract()
    {
        if (canInteractObj != null)
        {          
            canInteractObj.Interacted();
            if(canInteractObj is FinalTree)
            {
                OnCutting?.Invoke();
                return;
            }
            OnPicking?.Invoke();
        }
    }
    public void Move(Vector2 direction, CanPushObj pushedObj)
    {
        if(pushedObj != null)
        {
            if(!Push(pushedObj, direction))
            {
                return;
            }
        }
        OnMoving?.Invoke();
        this.transform.position += ((Vector3)direction);
    }

    private bool Blocked(Vector2 direction)
    {
        canInteractObj = null;
        if(direction != Vector2.zero)
        {
            hitCanInteractObj = Physics2D.Raycast(transform.position, direction, interactDistance, obstacleLayer);
            if (hitCanInteractObj)
            {
                hitCanInteractObj.transform.TryGetComponent<CanInteractObj>(out canInteractObj);
                return true;
            }
        }  
        return false;
    }
    private void CheckCanPushObj(Vector2 direction)
    {
        hitCanPushObj = Physics2D.Raycast(transform.position, direction, interactDistance, canPushLayer);
        canPushObj = null;
        if (hitCanPushObj)
        {
            hitCanPushObj.transform.TryGetComponent<CanPushObj>(out canPushObj);
        }
    }
    private bool Push(CanPushObj pushedObj, Vector2 movement)
    {      
        if (pushedObj.Pushed(movement))
        {
            return true;
        }
        return false;
    }    
    private void RunPlayerCommand(Vector2 movement)
    {
        if (!Blocked(movement))
        {
            CheckCanPushObj(movement);
            ICommand command = new MoveCommand(this, movement, canPushObj);
            CommandInvoker.ExcuteCommand(command);
        }
    }
    private void CheckFinalTree()
    {
        if(HasAxe)
        {
            hitCanInteractObj = Physics2D.Raycast(transform.position, Vector2.right, interactDistance, obstacleLayer);
            if (hitCanInteractObj)
            {
                hitCanInteractObj.transform.TryGetComponent<FinalTree>(out FinalTree tree);
                canInteractObj = tree as CanInteractObj;
                OnObjectInteract?.Invoke(tree);
            }
        }
    }
}
